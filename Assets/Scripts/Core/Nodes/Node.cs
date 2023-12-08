using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Nodes
{
    public class Node<T> : INode, INodeTag<T> where T : IComparable<T>
    {
        private readonly HashSet<INodeEdge<INode>> edges = new();

        public Node(params T[] tags)
        {
            Tags = tags;
        }

        public void AddNeighbor(INodeEdge<INode> edge)
        {
            if (edge.Contains(this))
            {
                // Check if there's an edge in the edges that has the same nodes
                var existingEdge = edges.FirstOrDefault(edgeInEdges =>
                    (Equals(edgeInEdges.NodeA, edge.NodeA) && Equals(edgeInEdges.NodeB, edge.NodeB)) ||
                    (Equals(edgeInEdges.NodeA, edge.NodeB) && Equals(edgeInEdges.NodeB, edge.NodeA)));

                if (existingEdge != null)
                {
                    // Replace the existing edge with the new one
                    edges.Remove(existingEdge);
                    edges.Add(edge);
                }
                else
                {
                    // Add the edge to the edges collection if no existing edge is found
                    edges.Add(edge);
                }
            }
            else
            {
                throw new Exception("Neighbors must be, well, neighbors. The edge doesn't contains this node");
            }
        }
        
        public IEnumerable<INodeEdge<INode>> Edges => edges;

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
            unchecked
            {
                int hash = GetType().GetHashCode();
                return Edges.Aggregate(hash, (current, edge) => (current * 31) + edge.GetType().GetHashCode());
            }
        }
    }
}