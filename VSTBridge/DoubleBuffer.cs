using System.Runtime.InteropServices;

namespace VSTBridge.Client;

public class DoubleBuffer<T>(int defaultCapacity) where T : unmanaged
{
    private List<T> _readList = new(defaultCapacity);
    private List<T> _writeList = new(defaultCapacity);
    private int _readPointer;

    public void Write(ReadOnlySpan<T> values)
    {
        _writeList.AddRange(values);
        if (_readList.Count > 0) return;
        Swap();
    }
    
    public int Read(Span<T> buffer)
    {
        var source = CollectionsMarshal.AsSpan(_readList)[_readPointer..];
        var count = Math.Min(source.Length, buffer.Length);
        source[..count].CopyTo(buffer);
        _readPointer += count;
        if (_readPointer < _readList.Count - 1) return count;
        _readPointer = 0;
        _readList.Clear();
        Swap();
        return count;
    }

    private void Swap() => (_readList, _writeList) = (_writeList, _readList);
}