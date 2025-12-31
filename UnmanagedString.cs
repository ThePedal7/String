using System.Runtime.InteropServices;

public sealed unsafe class UnmanagedString : IDisposable{
    private char* _ptr;
    private int _capacity;
    private int _byteSize;
    private int _length;
    public char* Ptr => _ptr;
    public int Length => _length;
    public int Capacity => _capacity;
    public int ByteSize => _byteSize;
    //Buffer Allocation Constructor
    private UnmanagedString(int capacity) {
        _capacity = capacity;
        _byteSize = _capacity * sizeof(char);
        _ptr = (char*)NativeMemory.AllocZeroed((UIntPtr)_byteSize);
        
        _length = 0;
    }
    // Adds a managed string into Buffer
    private UnmanagedString(string str) : this(str.Length + 1) {
       _length = str.Length;
        fixed (char* ptr = str) {
            
            NativeMemory.Copy(ptr, _ptr, (UIntPtr)_length * sizeof(char));
            _ptr[_length] = '\0';
        }
    }
    //Copy Constructor
    public UnmanagedString(UnmanagedString other) : this(other._capacity) {
        _length = other.Length;
        NativeMemory.Copy(other._ptr, _ptr, (UIntPtr)_length * sizeof(char));
        _ptr[_length] = '\0';
    }
    //Move Constructor
    public UnmanagedString(ref UnmanagedString source)  {
        
        this._ptr = source.Ptr;
        _length = source.Length;
        _capacity = source.Capacity;
        _byteSize = source.ByteSize;
        
        source._ptr = null;
        source._length = 0;
        source._capacity = 0;
        source._byteSize = 0;

    }
    

    public void Dispose() {
        if(_ptr == null) return;
        
        NativeMemory.Free(_ptr);
        _length = 0;
        _byteSize = 0;
        _capacity = 0;
        _ptr = null;
    }

    public void Reverse() {
        char* left = _ptr;
        char* right = _ptr + _length - 1;

        while (left < right) {
           char temp = *left;
           *left = *right;
           *right = temp;
            left++;
            right--;
        }
    }

    public UnmanagedString SubString(int startIndex) {
        
        int newLength = _length - startIndex;
        UnmanagedString str = new UnmanagedString(newLength + 1);
        str._length = newLength;
        NativeMemory.Copy(_ptr + startIndex, str.Ptr, (UIntPtr)newLength * sizeof(char));
        str.Ptr[newLength] = '\0';
        return str;
    }
    
    public UnmanagedString SubString(int startIndex, int length) {
        UnmanagedString str = new UnmanagedString(length + 1);
        str._length = length;
        NativeMemory.Copy(_ptr + startIndex, str.Ptr, (UIntPtr)length * sizeof(char));
        str.Ptr[length] = '\0';
        return str;
    }
    public char[] ToCharArray() {
        return ToString().ToCharArray();
    }
    
   public static implicit operator UnmanagedString(string str) => new(str);
   
   public static implicit operator string(UnmanagedString str) => str.ToString();

   
   
   public  char this[int index] {
       get =>  _ptr[index];
       set => _ptr[index] = value;
   }
    public override string ToString() {
        if(Ptr == null) return "null";
        
        return new string(Ptr);
    }
}
