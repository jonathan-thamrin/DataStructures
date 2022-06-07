using System.Collections;

namespace DataStructures.Solutions.Stack;

public class StackEnumerator<T> : IEnumerator<T>
{
    private readonly LinkedList.LinkedList<T> _stack;
    private int _currentIndex;

    public StackEnumerator(LinkedList.LinkedList<T> stack)
    {
        _stack = stack;
        _currentIndex = _stack.Count;
    }
    
    public bool MoveNext()
    {
        --_currentIndex;
        
        return  _currentIndex >= 0;
    }

    public void Reset()
    {
        _currentIndex = _stack.Count;
    }

    object IEnumerator.Current => Current;

    public T Current => _stack[_currentIndex];

    public void Dispose() { }
}