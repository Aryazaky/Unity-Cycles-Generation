using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Nodes
{
    public class Node<T> : INode, INodeTag<T> where T : IComparable<T>
    {
        private readonly List<INodeEdge> edges = new();

        public Node(params T[] tags)
        {
            Tags = tags;
        }

        public void AddNeighbor(INodeEdge edge)
        {
            edges.Add(edge);
        }
        
        public IEnumerable<INodeEdge> Edges => edges;

        public IEnumerable<T> Tags { get; }
        
        public bool ContainsTag(T tag)
        {
            return Tags.Contains(tag);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var otherNode = (INode)obj;

            // Compare the type of the node
            if (GetType() != otherNode.GetType())
                return false;

            // Compare the number of edges
            if (Edges.Count() != otherNode.Edges.Count())
                return false;

            // Compare the type of each edge
            var myEdges = Edges.OrderBy(edge => edge.GetType().Name).ToList();
            var otherEdges = otherNode.Edges.OrderBy(edge => edge.GetType().Name).ToList();

            for (int i = 0; i < myEdges.Count; i++)
            {
                var myEdge = myEdges[i];
                var otherEdge = otherEdges[i];

                // Compare the type of edges and connected nodes
                if (myEdge.GetType() != otherEdge.GetType() ||
                    myEdge.NodeA.GetType() != otherEdge.NodeA.GetType() ||
                    myEdge.NodeB.GetType() != otherEdge.NodeB.GetType())
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            // Implementing GetHashCode is necessary when you override Equals
            // Define a suitable GetHashCode logic based on your equality criteria
            unchecked
            {
                int hash = GetType().GetHashCode();
                foreach (var edge in Edges)
                {
                    hash = (hash * 31) + edge.GetType().GetHashCode();
                }
                return hash;
            }
        }
    }
}