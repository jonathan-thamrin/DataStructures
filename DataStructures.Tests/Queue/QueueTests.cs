using System;
using DataStructures.Queue;
using DataStructures.Tests.GeneralTests;
using DataStructures.Tests.TestHelpers;
using Xunit;

namespace DataStructures.Tests.Queue;

public class QueueTests : EnumerableTests
{

    private readonly IQueue<int> _queue;

    // Change which implementation is tested by changing the instance passed into this()
    public QueueTests() : this(new Exercises.Queue.Queue<int>()) { }

    #region Private Constructor

    private QueueTests(IQueue<int> queue) : base(queue)
    {
        _queue = queue;
    }

    #endregion
    
    #region Initialisation

    [Fact]
    public void NewQueue_ReturnsEmptyQueue()
    {
        Assert.Empty(_queue);
    }

    #endregion
    
    #region Enumeration

    [Fact]
    public void Enumeration_ReturnsElementsInFIFOOrder()
    {
        _queue.Enqueue(IntGenerator.First);
        _queue.Enqueue(IntGenerator.Second);
        _queue.Enqueue(IntGenerator.Third);
        
        Assert.Collection(_queue,
            element => Assert.Equal(IntGenerator.First, element),
            element => Assert.Equal(IntGenerator.Second, element),
            element => Assert.Equal(IntGenerator.Third, element)
        );
    }

    #endregion

    #region Enqueue

    [Fact]
    public void Enqueue_AddsElementToQueue()
    {
        _queue.Enqueue(IntGenerator.First);

        Assert.Collection(_queue,
            element => Assert.Equal(IntGenerator.First, element)
        );
    }
    
    [Fact]
    public void Enqueue_IncrementsCount()
    {
        Enqueue(3);

        Assert.Equal(3, _queue.Count);
    }

    #endregion

    #region Dequeue

    [Fact]
    public void Dequeue_ReturnsFirstElement()
    {
        Enqueue(3);

        var result = _queue.Dequeue();
        
        Assert.Equal(IntGenerator.First, result);
    }
    
    [Fact]
    public void Dequeue_RemovesFirstElement()
    {
        Enqueue(3);

        _queue.Dequeue();
        
        Assert.NotEqual(IntGenerator.First, _queue.Dequeue());
    }

    [Fact]
    public void Dequeue_ThrowsException_WhenQueueIsEmpty()
    {
        void Action() => _queue.Dequeue();
        
        Assert.Throws<InvalidOperationException>(Action);
    }
    
    [Fact]
    public void Dequeue_DecrementsCount()
    {
        Enqueue(3);

        _queue.Dequeue();
        
        Assert.Equal(2, _queue.Count);
    }
    
    #endregion

    #region Peek

    [Fact]
    public void Peek_ReturnsFirstElement()
    {
        Enqueue(3);

        var result = _queue.Peek();
        
        Assert.Equal(IntGenerator.First, result);
    }
    
    [Fact]
    public void Peek_DoesNotRemoveElement()
    {
        Enqueue(3);

        var firstPeekResult = _queue.Peek();
        var secondPeekResult = _queue.Peek();
        
        Assert.Equal(firstPeekResult, secondPeekResult);
    }

    [Fact]
    public void Peek_ThrowsException_WhenEmpty()
    {
        void Action() => _queue.Peek();
        
        Assert.Throws<InvalidOperationException>(Action);
    }

    #endregion

    #region TryDequeue

    [Fact]
    public void TryDequeue_AssignsOutParameter_WhenSuccessful()
    {
        Enqueue(3);

        var success = _queue.TryDequeue(out var result);
        
        Assert.True(success);
        Assert.Equal(IntGenerator.First, result);
    }
    
    [Fact]
    public void TryDequeue_AssignsDefaultOutParameter_WhenNotSuccessful()
    {
        var success = _queue.TryDequeue(out var result);
        
        Assert.False(success);
        Assert.Equal(default, result);
    }
    
    [Fact]
    public void TryDequeue_RemovesFirstElement()
    {
        Enqueue(3);

        _queue.TryDequeue(out _);
        _queue.TryDequeue(out var result);
        
        Assert.NotEqual(IntGenerator.First, result);
    }

    [Fact]
    public void TryDequeue_ReturnsTrue_WhenNotEmpty()
    {
        Enqueue(3);

        var success = _queue.TryDequeue(out _);
        
        Assert.True(success);
    }
    
    [Fact]
    public void TryDequeue_ReturnsFalse_WhenEmpty()
    {
        var success = _queue.TryDequeue(out _);
        
        Assert.False(success);
    }
    
    [Fact]
    public void TryDequeue_DecrementsCount_WhenSuccessful()
    {
        Enqueue(3);

        _queue.TryDequeue(out _);
        
        Assert.Equal(2, _queue.Count);
    }

    #endregion

    #region TryPeek

    [Fact]
    public void TryPeek_AssignsOutParameter_WhenSuccessful()
    {
        Enqueue(3);

        var success = _queue.TryPeek(out var result);
        
        Assert.True(success);
        Assert.Equal(IntGenerator.First, result);
    }
    
    [Fact]
    public void TryPeek_AssignsDefaultOutParameter_WhenNotSuccessful()
    {
        var success = _queue.TryPeek(out var result);
        
        Assert.False(success);
        Assert.Equal(default, result);
    }
    
    [Fact]
    public void TryPeek_DoesNotRemovePeekedElement()
    {
        Enqueue(3);

        _queue.TryPeek(out var firstPeekResult);
        _queue.TryPeek(out var secondPeekResult);

        Assert.Equal(firstPeekResult, secondPeekResult);
    }

    [Fact]
    public void TryPeek_ReturnsTrue_WhenNotEmpty()
    {
        Enqueue(3);

        var success = _queue.TryPeek(out _);
        
        Assert.True(success);
    }
    
    [Fact]
    public void TryPeek_ReturnsFalse_WhenEmpty()
    {
        var success = _queue.TryPeek(out _);
        
        Assert.False(success);
    }

    #endregion

    #region Count

    [Fact]
    public void Count_ReturnsZero_WhenEmpty()
    {
        Assert.Equal(0, _queue.Count);
    }
    
    [Fact]
    public void Count_ReturnsNumberOfElements()
    {
        Enqueue(3);
        
        Assert.Equal(3, _queue.Count);
    }

    #endregion

    private void Enqueue(int count)
    {
        var generator = new IntGenerator(count);
        generator.MoveNext();
        var i = count;
        
        while (i > 0)
        {
            _queue.Enqueue(generator.Current);
            generator.MoveNext();
            i--;
        }
    }
}