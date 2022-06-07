using System.Collections;

namespace DataStructures.Exercises.LinkedList;

public class LinkedListEnumerator<T> : IEnumerator<T>
{
    private LinkedList<T> _linkedList;
    private int currentIndex;
    private T currentItem;

    public LinkedListEnumerator(LinkedList<T> linkedList)
    {
        _linkedList = linkedList;
        currentIndex = -1;
        currentItem = default;
    }

    public bool MoveNext()
    {
        if (++currentIndex >= _linkedList.Count)
        {
            return false;
        }
        
        currentItem = _linkedList[currentIndex];
        
        return true;
    }

    public void Reset()
    {
        currentIndex = -1;
    }

    public T Current => currentItem;

    object IEnumerator.Current => Current;

    void IDisposable.Dispose() { }
}
