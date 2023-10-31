using System.Collections.Generic;

namespace Core
{
    public interface INode
    {
        IEnumerable<INodeEdge> Edges { get; }
    }
    
    public interface INodeTag<T>
    {
        IEnumerable<T> Tags { get; }
        bool CompareTag(T tag);
    }
}