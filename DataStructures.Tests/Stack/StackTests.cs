using System;
using DataStructures.Stack;
using DataStructures.Tests.GeneralTests;
using DataStructures.Tests.TestHelpers;
using Xunit;

namespace DataStructures.Tests.Stack;

public class StackTests : EnumerableTests
{
    private readonly IStack<int> _stack;

    // Change which implementation is tested by changing the instance passed into this()
    public StackTests() : this(new Exercises.Stack.Stack<int>()) { }

    #region Private Constructor

    private StackTests(IStack<int> stack) : base(stack)
    {
        _stack = stack;
    }

    #endregion
    
    #region Initialisation

    [Fact]
    public void NewStack_ReturnsEmptyStack()
    {
        Assert.Empty(_stack);
    }

    #endregion
    
    #region Enumeration

    [Fact]
    public void Enumeration_ReturnsElementsLIFOOrder()
    {
        Push(3);

        Assert.Collection(_stack,
            element => Assert.Equal(IntGenerator.Third, element),
            element => Assert.Equal(IntGenerator.Second, element),
            element => Assert.Equal(IntGenerator.First, element)
        );
    }

    #endregion

    #region Push

    [Fact]
    public void Push_AddsElementToStack()
    {
        _stack.Push(IntGenerator.First);

        Assert.Collection(_stack,
            element => Assert.Equal(IntGenerator.First, element)
        );
    }
    
    [Fact]
    public void Push_IncrementsCount()
    {
        Push(3);

        Assert.Equal(3, _stack.Count);
    }

    #endregion

    #region Pop

    [Fact]
    public void Pop_ReturnsTopElement()
    {
        Push(3);

        var result = _stack.Pop();
        
        Assert.Equal(IntGenerator.Third, result);
    }

    [Fact]
    public void Pop_RemovesTopElement()
    {
        Push(3);
        
        _stack.Pop();
        
        Assert.NotEqual(IntGenerator.Third, _stack.Pop());
    }
    
    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        void Action() => _stack.Pop();
        
        Assert.Throws<InvalidOperationException>(Action);
    }
    
    [Fact]
    public void Pop_DecrementsCount()
    {
        Push(3);

        _stack.Pop();

        Assert.Equal(2, _stack.Count);
    }

    #endregion

    #region Peek

    [Fact]
    public void Peek_ReturnsTopElement()
    {
        Push(3);

        var result = _stack.Peek();
        
        Assert.Equal(IntGenerator.Third, result);
    }
    
    [Fact]
    public void Peek_DoesNotRemoveElement()
    {
        Push(3);

        var firstPeekResult = _stack.Peek();
        var secondPeekResult = _stack.Peek();
        
        Assert.Equal(firstPeekResult, secondPeekResult);
    }

    [Fact]
    public void Peek_ThrowsException_WhenEmpty()
    {
        void Action() => _stack.Peek();
        
        Assert.Throws<InvalidOperationException>(Action);
    }

    #endregion

    #region TryPop

    [Fact]
    public void TryPop_AssignsOutParameter_WhenSuccessful()
    {
        Push(3);

        var success = _stack.TryPop(out var result);
        
        Assert.True(success);
        Assert.Equal(IntGenerator.Third, result);
    }
    
    [Fact]
    public void TryPop_AssignsDefaultOutParameter_WhenNotSuccessful()
    {
        var success = _stack.TryPop(out var result);
        
        Assert.False(success);
        Assert.Equal(default, result);
    }
    
    [Fact]
    public void TryPop_RemovesTopElement()
    {
        Push(3);

        _stack.TryPop(out _);
        _stack.TryPop(out var result);
        
        Assert.NotEqual(IntGenerator.Third, result);
    }

    [Fact]
    public void TryPop_ReturnsTrue_WhenNotEmpty()
    {
        Push(3);

        var success = _stack.TryPop(out _);
        
        Assert.True(success);
    }
    
    [Fact]
    public void TryPop_ReturnsFalse_WhenEmpty()
    {
        var success = _stack.TryPop(out _);
        
        Assert.False(success);
    }
    
    [Fact]
    public void TryPop_DecrementsCount_WhenSuccessful()
    {
        Push(3);

        _stack.TryPop(out _);
        
        Assert.Equal(2, _stack.Count);
    }

    #endregion

    #region TryPeek

    [Fact]
    public void TryPeek_AssignsOutParameter_WhenSuccessful()
    {
        Push(3);

        var success = _stack.TryPeek(out var result);
        
        Assert.True(success);
        Assert.Equal(IntGenerator.Third, result);
    }
    
    [Fact]
    public void TryPeek_AssignsDefaultOutParameter_WhenNotSuccessful()
    {
        var success = _stack.TryPeek(out var result);
        
        Assert.False(success);
        Assert.Equal(default, result);
    }
    
    [Fact]
    public void TryPeek_DoesNotRemovePeekedElement()
    {
        Push(3);

        _stack.TryPeek(out var firstPeekResult);
        _stack.TryPeek(out var secondPeekResult);

        Assert.Equal(firstPeekResult, secondPeekResult);
    }

    [Fact]
    public void TryPeek_ReturnsTrue_WhenNotEmpty()
    {
        Push(3);

        var success = _stack.TryPeek(out _);
        
        Assert.True(success);
    }
    
    [Fact]
    public void TryPeek_ReturnsFalse_WhenEmpty()
    {
        var success = _stack.TryPeek(out _);
        
        Assert.False(success);
    }

    #endregion
    
    #region Count

    [Fact]
    public void Count_ReturnsZero_WhenEmpty()
    {
        Assert.Equal(0, _stack.Count);
    }
    
    [Fact]
    public void Count_ReturnsNumberOfElements()
    {
        Push(3);
        
        Assert.Equal(3, _stack.Count);
    }

    #endregion

    private void Push(int count)
    {
        var generator = new IntGenerator(count);
        generator.MoveNext();
        var i = count;
        
        while (i > 0)
        {
            _stack.Push(generator.Current);
            generator.MoveNext();
            i--;
        }
    }
}