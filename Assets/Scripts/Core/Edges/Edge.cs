using Core.Nodes;
using UnityEngine.Serialization;

namespace Core.Edges
{
    public class Edge : INodeEdge
    {
        public Edge(INode nodeA, INode nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
        }

        public INode NodeA { get; }
        public INode NodeB { get; }
        public INode GetOtherNode(INode node)
        {
            return Equals(node, NodeA) // masih bimbang mau pakai Equals atau ReferenceEquals
                ? NodeB 
                : Equals(node, NodeB) 
                    ? NodeA 
                    : null;
        }

        /// <summary>
        /// Compares by reference
        /// </summary>
        public bool Contains(INode node)
        {
            return ReferenceEquals(node, NodeA) || ReferenceEquals(node, NodeB);
        }
    }
}