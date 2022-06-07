using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Tests.TestHelpers;

public class IntGenerator : IEnumerator<int>
{
    public const int First = 1;
    public const int Second = 2;
    public const int Third = 3;
    public const int Fourth = 4;
    public const int Fifth = 5;

    private int _next;
    private readonly int _max;

    public IntGenerator(int max)
    {
        _max = max;
        Reset();
    }
    
    public void GenerateInto(ICollection<int> collection)
    {
        while (MoveNext())
        {
            collection.Add(Current);
        }
    }

    public bool MoveNext()
    {
        _next++;
        
        return _next <= _max;
    }

    public void Reset()
    {
        _next = 0;
    }

    public int Current => _next;

    object IEnumerator.Current => Current;
    
    public void Dispose()
    {
    }
}
