using System;
using System.Collections.Generic;

namespace Core
{
    public interface INode
    {
        IEnumerable<INodeEdge> Edges { get; }
    }
    
    public interface INodeTag<T> where T : IComparable<T>
    {
        IEnumerable<T> Tags { get; }
        bool ContainsTag(T tag);
    }
}