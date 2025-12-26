using System.Runtime.InteropServices;

namespace Console;
/* #TODO Implement Support for the following
   #TODO foreach
   #TODO var
   #TODO Resize?
   #TODO basic string operations
   #TODO comparison logic and arithmetic logic
   #TODO conversions to strings or char[] or collection types
   #TODO move semantics?, value and ref semantics?, generics?
*/
public unsafe class C : IDisposable {
    private char* _ptr;
    private int _length;
    private int _byteSize;
    private int _size;
    
    public int Length  => _length;
    public int ByteSize => _byteSize;
    public int Size => _size;
    public C(string str) {

       
        _ptr = ToCharPtr(str);
        _length = Functions.GetCharPtrLength(_ptr);
    }

   
    public C(char* ptr) {
        
        
        _ptr = ptr;
        _length = Functions.GetCharPtrLength(_ptr);
    }

    public C(C  other) {
        
        if (other._ptr != null) {
            _length = other._length;
            _byteSize = other.ByteSize;
            _size = other._size;
            _ptr = (char*)NativeMemory.Alloc((UIntPtr)(_length + 1) * sizeof(char));
            for (int i = 0; i < _length; i++) {
                _ptr[i] = other[i];
            }
            
            _ptr[_length] = '\0';
                
            
        }
    }

    
    public void Dispose() {
        if (_ptr != null) {
            
            NativeMemory.Free(_ptr);

            _ptr = null;
        }
    }
    
    
    
    public static implicit operator char*(C a) {
        return a._ptr;
    }
    public static implicit operator char[](C a) {
        return a.ToString().ToCharArray();
    }
   
    public static implicit operator C(string str) {
        return new C(str) ;
    }
    public static implicit operator C(char* str) {
        return new C(str) ;
    }
    
    

    
   


    public  char this[int index] {
        get =>  _ptr[index];
        set {
            _ptr[index] = value;
            if (_ptr[index] is '\0') {
                _length = Functions.GetCharPtrLength(_ptr);
            }

            if (index > _length) {
                throw new IndexOutOfRangeException();

            }
        } 
    }

    private char* ToCharPtr( string str) {

         
        _byteSize = (str.Length + 1) * sizeof(char);
        _size = str.Length + 1;
        char* ptr = (char*)NativeMemory.Alloc((UIntPtr)(str.Length+ 1) * sizeof(char));
        for (int i = 0; i < str.Length; i++) {
            ptr[i] = str[i];
        }
        ptr[str.Length] = '\0';
          
        
        return ptr;
    }

    public void Reverse() {
        int left = 0;
        int right = _length - 1;
        while (left < right) {
            (_ptr[left], _ptr[right]) = (_ptr[right], _ptr[left]);
            left++;
            right--;
        }

    }

    public string Substring(int startIndex) {
        string result = "";
        for (int i = startIndex; i < _length; i++) {
            result += _ptr[i];
        }
        return result;
    }
    public string Substring(int startIndex, int length) {
        string result = "";
        for (int i = startIndex; i <= length; i++) {
            result += _ptr[i];
        }
        return result;
    }

    public  override string ToString() {
        
        return new string(_ptr, 0, _length);
    }
    
}

