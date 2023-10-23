using System.Collections.Generic;
using UnityEngine;

namespace CyclesGen.Core
{
    public class Node : INode
    {
        private readonly Vector3 position;
        private readonly List<INodeEdge> edges = new();

        public Node(Vector3 position)
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
