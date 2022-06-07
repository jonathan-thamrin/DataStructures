using System;
using System.Collections.Generic;
using DataStructures.Tests.TestHelpers;
using Xunit;

namespace DataStructures.Tests.LinkedList;

public abstract class ListTests : GeneralTests.CollectionTests
{
    private readonly IList<int> _list;

    protected ListTests(IList<int> list) : base(list)
    {
        _list = list;
    }

    #region Propertry Indexer

    [InlineData(0, IntGenerator.First)]
    [InlineData(1, IntGenerator.Second)]
    [InlineData(2, IntGenerator.Third)]
    [Theory]
    public void Indexer_Get_ReturnsCorrectValue(int index, int expected)
    {
        AddElements(3);

        var actual = _list[index];
        
        Assert.Equal(expected, actual);
    }
    
    [InlineData(4)]
    [InlineData(42)]
    [InlineData(-42)]
    [Theory]
    public void Indexer_Set_SetsCorrectValue(int expected)
    {
        AddElements(3);
        
        _list[1] = expected;
        
        Assert.Equal(expected, _list[1]);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(5, 10)]
    public void Indexer_ThrowsException_WhenIndexIsOutOfRange_Positive(int collectionSize, int invalidIndex)
    {
        AddElements(collectionSize);

        void Action() => _list[invalidIndex] = 0;

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
    
    [Fact]
    public void Indexer_ThrowsException_WhenIndexIsOutOfRange_Negative()
    {
        AddElements(3);

        void Action() => _list[-1] = 0;

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    #endregion

    #region IndexOf

    [InlineData(IntGenerator.First, 0)]
    [InlineData(IntGenerator.Second, 1)]
    [InlineData(IntGenerator.Third, 2)]
    [Theory]
    public void IndexOf_ReturnsCorrectIndex_WhenElementIsFound(int item, int expected)
    {
        AddElements(3);

        var actual = _list.IndexOf(item);
        
        Assert.Equal(expected, actual);
    }
    
    [InlineData(IntGenerator.Second, -1)]
    [InlineData(IntGenerator.Third, -1)]
    [InlineData(IntGenerator.Fourth, -1)]
    [Theory]
    public void IndexOf_ReturnsNegativeOne_WhenElementIsNotFound(int item, int expected)
    {
        AddElements(1);

        var actual = _list.IndexOf(item);
        
        Assert.Equal(expected, actual);
    }

    #endregion

    #region Insert

    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [Theory]
    public void Insert_UpdatesCount_WhenElementIsInserted(int collectionSize, int expected)
    {
        AddElements(collectionSize);
        
        _list.Insert(1, IntGenerator.Fourth);
        
        Assert.Equal(expected, _list.Count);
    }
    
    [Fact]
    public void Insert_UpdatesCount_WhenElementIsInserted_WhenEmpty()
    {
        AddElements(0);
        
        _list.Insert(0, IntGenerator.Fourth);
        
        Assert.Equal(1, _list.Count);
    }
    
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [Theory]
    public void Insert_InsertsElementAtCorrectIndex(int index)
    {
        AddElements(3);
        
        _list.Insert(index, IntGenerator.Fourth);
        
        Assert.Equal(IntGenerator.Fourth, _list[index]);
    }
    
    [Fact]
    public void Insert_InsertsElementAtCorrectIndex_WhenEmpty()
    {
        _list.Insert(0, IntGenerator.First);
        
        Assert.Equal(IntGenerator.First, _list[0]);
    }
    
    [Fact]
    public void Insert_InsertsElementAtCorrectIndex_WhenIndexIsEqualToLength()
    {
        AddElements(3);
        
        _list.Insert(3, IntGenerator.Fourth);
        
        Assert.Equal(IntGenerator.Fourth, _list[3]);
    }
    
    [Fact]
    public void Insert_ThrowsException_WhenIndexIsOutOfRange_Positive()
    {
        AddElements(3);

        void Action() => _list.Insert(4, IntGenerator.Fourth);

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
    
    [Fact]
    public void Insert_ThrowsException_WhenIndexIsOutOfRange_Negative()
    {
        AddElements(3);

        void Action() => _list.Insert(-1, IntGenerator.Fourth);

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }

    #endregion

    #region RemoveAt

    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [Theory]
    public void RemoveAt_UpdatesCount_WhenElementIsRemoved(int collectionSize, int expected)
    {
        AddElements(collectionSize);
        
        _list.RemoveAt(1);
        
        Assert.Equal(expected, _list.Count);
    }
    
    [Fact]
    public void RemoveAt_ThrowsException_WhenIndexIsOutOfRange_Positive()
    {
        AddElements(3);

        void Action() => _list.RemoveAt(4);

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
    
    [Fact]
    public void RemoveAt_ThrowsException_WhenIndexIsOutOfRange_Negative()
    {
        AddElements(3);

        void Action() => _list.RemoveAt(-1);

        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
    
    [Fact]
    public void RemoveAt_RemovesElementAtCorrectIndex()
    {
        AddElements(3);
        
        _list.RemoveAt(1);
        
        Assert.Equal(IntGenerator.First, _list[0]);
        Assert.Equal(IntGenerator.Third, _list[1]);
    }
    
    [Fact]
    public void RemoveAt_RemovesLastElement()
    {
        AddElements(3);
        
        _list.RemoveAt(2);
        
        Assert.Equal(IntGenerator.First, _list[0]);
        Assert.Equal(IntGenerator.Second, _list[1]);
    }
    
    [Fact]
    public void RemoveAt_RemovesFirstElement()
    {
        AddElements(3);
        
        _list.RemoveAt(0);
        
        Assert.Equal(IntGenerator.Second, _list[0]);
        Assert.Equal(IntGenerator.Third, _list[1]);
    }

    #endregion
}
