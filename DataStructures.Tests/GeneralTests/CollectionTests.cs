using System;
using System.Collections.Generic;
using DataStructures.Tests.TestHelpers;
using Xunit;

namespace DataStructures.Tests.GeneralTests;

public abstract partial class CollectionTests : EnumerableTests
{
    private readonly ICollection<int> _collection;

    protected CollectionTests(ICollection<int> collection) : base(collection)
    {
        _collection = collection;
    }

    #region Count

    [Fact]
    public void Count_ReturnsZeroForEmptyList()
    {
        Assert.Equal(0, _collection.Count);
    }

    [InlineData(1)]
    [InlineData(7)]
    [InlineData(10)]
    [InlineData(42)]
    [InlineData(100)]
    [Theory]
    public void Count_ReturnsCorrectCount(int collectionSize)
    {
        AddElements(collectionSize);
        
        Assert.Equal(collectionSize, _collection.Count);
    }

    #endregion

    #region IsReadOnly

    // ReadOnly is not being tested.
    [Fact]
    public void IsReadOnly_ReturnsFalse()
    {
        Assert.False(_collection.IsReadOnly);
    }

    #endregion
    
    #region Add

    [Fact]
    public void Add_AddsElementToList()
    {
        AddElements(1);
        
        Assert.Single(_collection);
    }
    
    [Fact]
    public void Add_AddsMultipleElementsToList()
    {
        AddElements(3);

        Assert.Contains(_collection, element => element == IntGenerator.First);
        Assert.Contains(_collection, element => element == IntGenerator.Second);
        Assert.Contains(_collection, element => element == IntGenerator.Third);
    }

    #endregion

    #region Clear

    [InlineData(0)]
    [InlineData(1)]
    [InlineData(7)]
    [Theory]
    public void Clear_RemovesAllElementsFromList(int collectionSize)
    {
        AddElements(collectionSize);
        
        _collection.Clear();

        Assert.Empty(_collection);
    }
    
    [Fact]
    public void Clear_ResetsCountToZero()
    {
        AddElements(1);
        
        _collection.Clear();

        Assert.Equal(0, _collection.Count);
    }

    #endregion

    #region Contains

    [Fact]
    public void Contains_ReturnsFalseForEmptyList()
    {
        var exists = _collection.Contains(IntGenerator.First);
        
        Assert.False(exists);
    }
    
    [InlineData(1, IntGenerator.First)]
    [InlineData(7, IntGenerator.Fifth)]
    [Theory]
    public void Contains_ReturnsTrueForExistingElement(int collectionSize, int expectedElement)
    {
        AddElements(collectionSize);
        
        var exists = _collection.Contains(expectedElement);
        
        Assert.True(exists);
    }
    
    [Fact]
    public void Contains_ReturnsFalseForNonExistingElement()
    {
        AddElements(1);
        
        var exists = _collection.Contains(IntGenerator.Second);
        
        Assert.False(exists);
    }

    #endregion

    #region CopyTo

    [Fact]
    public void CopyTo_CopiesAllElementsToArray()
    {
        AddElements(3);
        
        var array = new int[3];
        _collection.CopyTo(array, 0);
        
        Assert.Contains(array, element => element == IntGenerator.First);
        Assert.Contains(array, element => element == IntGenerator.Second);
        Assert.Contains(array, element => element == IntGenerator.Third);
    }
    
    [Fact]
    public void CopyTo_CopiesAllElementsToArray_WithOffset()
    {
        AddElements(3);
        
        var array = new int[10];
        _collection.CopyTo(array, 4);
        
        Assert.Contains(array, element => element == IntGenerator.First);
        Assert.Contains(array, element => element == IntGenerator.Second);
        Assert.Contains(array, element => element == IntGenerator.Third);
    }
    
    [Fact]
    public void CopyTo_ThrowsException_WhenArrayIsNull()
    {
        void Action() => _collection.CopyTo(null!, 0);

        Assert.Throws<ArgumentNullException>(Action);
    }
    
    [Fact]
    public void CopyTo_ThrowsException_WhenArrayIsTooSmall()
    {
        AddElements(3);
        
        void Action() => _collection.CopyTo(new int[2], 0);

        Assert.Throws<ArgumentException>(Action);
    }
    
    [Fact]
    public void CopyTo_ThrowsException_WhenArrayIsTooSmall_WithOffset()
    {
        AddElements(3);
        
        void Action() => _collection.CopyTo(new int[10], 8);

        Assert.Throws<ArgumentException>(Action);
    }
    
    [Fact]
    public void CopyTo_ThrowsException_WhenOffsetIsNegative()
    {
        void Action() => _collection.CopyTo(new int[10], -1);

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    #endregion

    #region Remove

    [Fact]
    public void Remove_RemovesElement()
    {
        AddElements(3);
        
        _collection.Remove(IntGenerator.Second);
        
        Assert.DoesNotContain(_collection, element => element == IntGenerator.Second);
    }
    
    [Fact]
    public void Remove_DoesNotRemoveElement_WhenElementDoesNotExist()
    {
        AddElements(3);
        
        _collection.Remove(IntGenerator.Fourth);
        
        Assert.Contains(_collection, element => element == IntGenerator.First);
        Assert.Contains(_collection, element => element == IntGenerator.Second);
        Assert.Contains(_collection, element => element == IntGenerator.Third);
    }
    
    [Fact]
    public void Remove_DoesNotRemoveElement_WhenCollectionIsEmpty()
    {
        var removed = _collection.Remove(IntGenerator.Second);

        Assert.False(removed);
    }
    
    [Fact]
    public void Remove_ReturnsTrue_WhenElementWasRemoved()
    {
        AddElements(3);
        
        var removed = _collection.Remove(IntGenerator.Second);
        
        Assert.True(removed);
    }
    
    [Fact]
    public void Remove_ReturnsFalse_WhenElementWasNotFound()
    {
        AddElements(3);
        
        var removed = _collection.Remove(IntGenerator.Fifth);
        
        Assert.False(removed);
    }

    [Fact]
    public void Remove_DecrementsCount_WhenElementRemoved()
    {
        AddElements(3);
        
        _collection.Remove(IntGenerator.Second);
        
        Assert.Equal(2, _collection.Count);
    }
    
    [Fact]
    public void Remove_DoesNotDecrementCount_WhenElementNotRemoved()
    {
        AddElements(3);
        
        _collection.Remove(IntGenerator.Fifth);
        
        Assert.Equal(3, _collection.Count);
    }

    #endregion
}
