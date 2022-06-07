using System.Collections;
using System.Diagnostics;

namespace DataStructures.Solutions.LinkedList;

public class LinkedList<T> : IList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator<T>(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        // List is empty
        if (_head == null)
        {
            _head = new Node<T>(item);
            _tail = _head;
        }
        else
        {
            var newNode = new Node<T>(item);
            newNode.Left = _tail;
            _tail!.Right = newNode;
            _tail = _tail.Right;
        }
        
        ++Count;
    }

    public void Clear()
    {
        _head = _tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        foreach (var currentItem in this)
        {
            if (currentItem.Equals(item))
                return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null!)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException(null, nameof(array));
        
        var insertIndex = arrayIndex;
        foreach (var item in this)
        {
            array[insertIndex] = item;
            insertIndex++;
        }
    }

    public bool Remove(T item)
    {
        var currentNode = _head;

        while (currentNode != null) 
        {
            if (currentNode.Item!.Equals(item))
            {
                _removeNode(currentNode);
                return true;
            }

            currentNode = currentNode.Right;
        }

        return false;
    }

    public int Count { get; private set; }
    
    public bool IsReadOnly => false;

    public int IndexOf(T item)
    {
        var currentNode = _head;
        var index = 0;
        
        while (currentNode != null && !currentNode.Item!.Equals(item))
        {
            currentNode = currentNode.Right;
            ++index;
        }

        return currentNode == null ? -1 : index;;
    }

    public void Insert(int index, T item)
    {
        var newNode = new Node<T>(item);
        
        if (index == 0)
        {
            _head?.LinkLeft(newNode);
            _head = newNode;
        }
        else
        {
            var prevNode = _traverse(index - 1);
            Debug.Assert(index > 0, "Inserting at index 0 should have a special case.");

            prevNode.Right?.LinkLeft(newNode);
            prevNode.LinkRight(newNode);
        }
        
        ++Count;
    }

    public void RemoveAt(int index)
    {
        _removeNode(_traverse(index));
    }

    public T this[int index]
    {
        get => _traverse(index).Item;
        set => _traverse(index).Item = value;
    }

    private Node<T> _traverse(int index, Node<T>? currentNode = null)
    {
        if (!(0 <= index && index < Count))
            throw new ArgumentOutOfRangeException(nameof(index));
        
        currentNode ??= _head;
        for (var _ = 0; _ < index; _++)
            currentNode = currentNode!.Right;
        
        return currentNode!;
    }

    private void _removeNode(Node<T> currentNode)
    {
        if (currentNode.Left == null)
        {
            _head = _head!.Right;
            if (_head != null) _head.Left = null;
        }
        else if (currentNode.Right == null)
        {
            _tail = _tail!.Left;
            if (_tail != null) _tail.Right = null;
        }
        else
        {
            Debug.Assert(currentNode.Left != null, "currentNode.Left != null");
            currentNode.Left.Right = currentNode.Right;
            Debug.Assert(currentNode.Right != null, "currentNode.Right != null");
            currentNode.Right.Left = currentNode.Left;
        }

        --Count;
    }
}