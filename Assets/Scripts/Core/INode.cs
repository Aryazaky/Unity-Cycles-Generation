using System.Collections.Generic;

namespace CyclesGen.Core
{
    public interface INode
    {
        IEnumerable<INodeEdge> Edges { get; }
    }
}