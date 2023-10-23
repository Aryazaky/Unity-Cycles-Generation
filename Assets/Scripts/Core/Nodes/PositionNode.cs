using System.Collections.Generic;
using UnityEngine;

namespace Core.Nodes
{
    public class PositionNode : INode
    {
        private readonly Vector3 position;
        private readonly List<INodeEdge> edges = new();

        public PositionNode(Vector3 position)
        {
            this.position = position;
        }

        public void AddNeighbor(INodeEdge edge)
        {
            edges.Add(edge);
        }

        public IEnumerable<INodeEdge> Edges => edges;
    }
}
