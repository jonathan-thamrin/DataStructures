using System.Collections;

namespace DataStructures.Solutions.LinkedList;

public class LinkedListEnumerator<T> : IEnumerator<T>
{
    private readonly Node<T>? _head;
    private Node<T>? _currentNode;

    public LinkedListEnumerator(Node<T>? head)
    {
        _head = head;
    }
    
    public bool MoveNext()
    {
        _currentNode = _currentNode == null ? _head : _currentNode.Right;

        return  _currentNode != null;
    }

    public void Reset()
    {
        _currentNode = null;
    }

    public T Current => _currentNode.Item;

    object IEnumerator.Current => Current;

    public void Dispose() { }
}