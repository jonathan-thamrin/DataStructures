namespace DataStructures.Queue;

public interface IQueue<T> : IEnumerable<T>
{
    /// <summary>
    /// Removes and returns the object at the beginning of the IQueue&lt;T&gt;.
    /// </summary>
    /// <returns>The object that is removed from the beginning of the IQueue&lt;T&gt;.</returns>
    /// <exception cref="InvalidOperationException">The IQueue&lt;T&gt; is empty.</exception>
    public T Dequeue();
    
    /// <summary>
    /// Adds an object to the end of the IQueue&lt;T&gt;.
    /// </summary>
    /// <param name="item">The object to add to the IQueue&lt;T&gt;. The value can be null for reference types.</param>
    public void Enqueue(T item);

    /// <summary>
    /// Returns the object at the beginning of the IQueue&lt;T&gt; without removing it.
    /// </summary>
    /// <returns>The object at the beginning of the IQueue&lt;T&gt;.</returns>
    /// <exception cref="InvalidOperationException">The IQueue&lt;T&gt; is empty.</exception>
    public T Peek();

    /// <summary>
    /// Removes the object at the beginning of the IQueue&lt;T&gt;, and copies it to the result parameter.
    /// </summary>
    /// <param name="result">The removed object.</param>
    /// <returns><b>true</b> if the object is successfully removed; <b>false</b> if the IQueue&lt;T&gt; is empty.</returns>
    public bool TryDequeue(out T result);
    
    /// <summary>
    /// Returns a value that indicates whether there is an object at the beginning of the IQueue&lt;T&gt;, and if one is present, copies it to the result parameter. The object is not removed from the IQueue&lt;T&gt;.
    /// </summary>
    /// <param name="result">If present, the object at the beginning of the IQueue&lt;T&gt;; otherwise, the default value of T.</param>
    /// <returns><b>true</b> if there is an object at the beginning of the IQueue&lt;T&gt;; <b>false</b> if the IQueue&lt;T&gt; is empty.</returns>
    public bool TryPeek(out T result);

    /// <summary>
    /// Gets the number of elements contained in the IQueue&lt;T&gt;.
    /// </summary>
    /// <returns>The number of elements contained in the IQueue&lt;T&gt;.</returns>
    public int Count { get; }
}
