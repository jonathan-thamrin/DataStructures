namespace DataStructures.Solutions.LinkedList;

public class Node<T>
{
    public Node<T>? Left;
    public Node<T>? Right;
    public T Item;

    public Node(T item, Node<T>? left = null, Node<T>? right = null)
    {
        Item = item;
        Left = left;
        Right = right;
    }

    public void LinkLeft(Node<T> leftNode)
    {
        Left = leftNode;
        leftNode.Right = this;
    }
    
    public void LinkRight(Node<T> rightNode)
    {
        Right = rightNode;
        rightNode.Left = this;
    }
}