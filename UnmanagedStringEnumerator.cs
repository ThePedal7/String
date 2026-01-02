using System.Collections;

namespace Console;

public unsafe struct UnmanagedStringEnumerator : IEnumerator<char>
{
    private readonly char* _ptr;
    private readonly int _length;
    private int _index;

    public UnmanagedStringEnumerator(char* ptr, int length)
    {
        _ptr = ptr;
        _length = length;
        _index = -1;
    }

    public char Current => _ptr[_index];
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _index++;
        return _index < _length;
    }

    public void Reset()
    {
        _index = -1;
    }

    

    public void Dispose() { }
}
