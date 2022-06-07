using System.Collections;
using DataStructures.Stack;

namespace DataStructures.Exercises.Stack;

public class Stack<T> : IStack<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    
    public bool IsReadOnly { get; }
    
    public T Peek()
    {
        throw new NotImplementedException();
    }

    public T Pop()
    {
        throw new NotImplementedException();
    }

    public void Push(T item)
    {
        throw new NotImplementedException();
    }

    public bool TryPeek(out T result)
    {
        throw new NotImplementedException();
    }

    public bool TryPop(out T result)
    {
        throw new NotImplementedException();
    }
}
