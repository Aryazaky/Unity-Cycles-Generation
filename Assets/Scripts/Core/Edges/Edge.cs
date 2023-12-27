using System;
using System.Collections.Generic;
using System.Linq;
using Core.Nodes;
using UnityEngine;
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

    [Serializable]
    public class SerializablePositionEdge
    {
        [SerializeField] private NodeUI nodeA;
        [SerializeField] private NodeUI nodeB;
        
        public SerializablePositionEdge(NodeUI nodeA, NodeUI nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }

        public NodeUI NodeA => nodeA;
        public NodeUI NodeB => nodeB;
        public IEnumerable<NodeUI> Nodes => Enumerable.Empty<NodeUI>().Append(nodeA).Append(nodeB);

        public NodeUI GetOtherNode(NodeUI nodeUI)
        {
            return Equals(nodeUI, NodeA) // masih bimbang mau pakai Equals atau ReferenceEquals
                ? NodeB 
                : Equals(nodeUI, NodeB) 
                    ? NodeA 
                    : null;
        }

        public bool Contains(NodeUI nodeUI)
        {
            return ReferenceEquals(nodeUI, NodeA) || ReferenceEquals(nodeUI, NodeB);
        }
    }
}