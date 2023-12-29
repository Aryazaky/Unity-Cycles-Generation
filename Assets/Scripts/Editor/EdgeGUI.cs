using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Editor
{
    [Serializable]
    public class EdgeGUI
    {
        [SerializeField] private NodeGUI nodeA;
        [SerializeField] private NodeGUI nodeB;
        
        public EdgeGUI(NodeGUI nodeA, NodeGUI nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }

        public NodeGUI NodeA => nodeA;
        public NodeGUI NodeB => nodeB;
        public IEnumerable<NodeGUI> Nodes => Enumerable.Empty<NodeGUI>().Append(nodeA).Append(nodeB);

        public NodeGUI GetOtherNode(NodeGUI nodeGUI)
        {
            return Equals(nodeGUI, NodeA) // masih bimbang mau pakai Equals atau ReferenceEquals
                ? NodeB 
                : Equals(nodeGUI, NodeB) 
                    ? NodeA 
                    : null;
        }

        public bool Contains(NodeGUI nodeGUI)
        {
            return ReferenceEquals(nodeGUI, NodeA) || ReferenceEquals(nodeGUI, NodeB);
        }
    }
}