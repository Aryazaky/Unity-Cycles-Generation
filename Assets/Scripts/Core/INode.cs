using System.Collections.Generic;

namespace Core
{
    public interface INode
    {
        IEnumerable<INodeEdge> Edges { get; }
    }
}