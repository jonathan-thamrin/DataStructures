using System.Collections;

namespace DataStructures.Exercises.LinkedList;

public class LinkedList<T> : IList<T>
{
    private Node<T> head { get; set; }
    private Node<T> tail { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
        
        // while next isn't null, yield return the node?
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        if (head == null)
        {
            head = new Node<T>(item);
            tail = head;
        }
        else
        {
            var node = new Node<T>(item);
            tail.Next = node;
            tail = node;
        }
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
    
    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}
