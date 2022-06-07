using DataStructures.Tests.TestHelpers;

namespace DataStructures.Tests.GeneralTests;

public abstract partial class CollectionTests
{
    protected void AddElements(int count)
    {
        new IntGenerator(count).GenerateInto(_collection);
    }
}
