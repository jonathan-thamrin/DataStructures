using System.Collections.Generic;
using DataStructures.Tests.TestHelpers;
using Xunit;

namespace DataStructures.Tests.LinkedList;

public class LinkedListTests : ListTests
{
    private readonly IList<int> _linkedList;

    // Change which implementation is tested by changing the instance passed into this()
    public LinkedListTests() : this(new Exercises.LinkedList.LinkedList<int>()) { }

    #region Private Constructor

    private LinkedListTests(IList<int> list) : base(list)
    {
        _linkedList = list;
    }

    #endregion

    #region Initialisation

    [Fact]
    public void NewList_ReturnsEmptyList()
    {
        Assert.Empty(_linkedList);
    }

    #endregion
    
    #region Enumeration

    [Fact]
    public void Enumeration_ReturnsElementsInAddedOrder()
    {
        AddElements(3);
        
        Assert.Collection(_linkedList,
            element => Assert.Equal(IntGenerator.First, element),
            element => Assert.Equal(IntGenerator.Second, element),
            element => Assert.Equal(IntGenerator.Third, element)
        );
    }

    #endregion
}
