using System.Collections;
using DataStructures.Queue;

namespace DataStructures.Solutions.Queue;

public class Queue<T> : IQueue<T>
{
    
    private readonly LinkedList.LinkedList<T> _queue = new();

    public IEnumerator<T> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => _queue.Count;
    
    public T Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException();
        
        var dequeuedItem = _queue[0];
        _queue.RemoveAt(0);
        
       return dequeuedItem;
    }

    public void Enqueue(T item)
    {
        _queue.Add(item);
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException();
        
        return _queue[0];
    }

    public bool TryDequeue(out T result)
    {
        try
        {
            result = Dequeue();
            return true;
        }
        catch (InvalidOperationException)
        {
            result = default!;
            return false;
        }
    }

    public bool TryPeek(out T result)
    {
        try
        { 
            result = Peek();
            return true;
        }
        catch (InvalidOperationException)
        {
            result = default!;
            return false;
        }
    }
}