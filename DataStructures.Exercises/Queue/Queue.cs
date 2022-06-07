using System.Collections;
using DataStructures.Queue;

namespace DataStructures.Exercises.Queue;

public class Queue<T> : IQueue<T>
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
    
    public T Dequeue()
    {
        throw new NotImplementedException();
    }

    public void Enqueue(T item)
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public bool TryDequeue(out T result)
    {
        throw new NotImplementedException();
    }

    public bool TryPeek(out T result)
    {
        throw new NotImplementedException();
    }
}
