namespace DataStructures.Exercises.LinkedList;

public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Item { get; set; }

    public Node(T item)
    {
        Item = item;
    }
}
