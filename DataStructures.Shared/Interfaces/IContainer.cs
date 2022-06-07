using System.Collections;

namespace DataStructures.Interfaces;

public interface IContainer : ICollection
{
    /// <summary>
    /// Ensures that the capacity of this queue is at least the specified capacity. If the current capacity is less than capacity, it is successively increased to twice the current capacity until it is at least the specified capacity.
    /// </summary>
    /// <param name="capacity">The minimum capacity to ensure.</param>
    /// <returns>The new capacity of this queue.</returns>
    public int EnsureCapacity(int capacity);
    
    /// <summary>
    /// Sets the capacity to the actual number of elements in the IQueue&lt;T&gt;, if that number is less than 90 percent of current capacity.
    /// </summary>
    public void TrimExcess();
}