using UnityEngine;
using VfLib;

namespace Tests
{
    public class NodeTest : MonoBehaviour
    {
        private void Start()
        {
            Graph graph = new Graph();
            var firstNodeId = graph.InsertNode("test");
            var secondNodeId = graph.InsertNode("tes again");
            graph.InsertEdge(firstNodeId, secondNodeId, "an edge");

            VfLib.FullMapping fullMapping = new FullMapping();
        }
    }
}