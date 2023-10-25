using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Graph
    {
        private readonly IEnumerable<INode> nodes;

        public Graph(IEnumerable<INode> nodes)
        {
            var nodeList = nodes.ToList();
            if (GraphUtils.AreAllNodesConnected(nodeList))
            {
                this.nodes = nodeList;
            }
            else throw new Exception("There is a lone island unconnected");
        }

        public bool Contains(Graph other)
        {
            // Use adjacency check
            throw new NotImplementedException();
        }
    }
    
    public static class GraphUtils
    {
        public static bool AreAllNodesConnected(List<INode> nodes)
        {
            if (!nodes.Any())
            {
                // No nodes to traverse
                return false;
            }
            // Create a set to keep track of visited nodes
            var visitedNodes = new HashSet<INode>();

            // Start DepthFirstSearch from the first node in the list
            DepthFirstSearch(nodes[0], visitedNodes);

            // If all nodes are visited, they are connected as one island
            return visitedNodes.Count == nodes.Count;
        }

        private static void DepthFirstSearch(INode node, ISet<INode> visitedNodes)
        {
            // Mark the current node as visited
            visitedNodes.Add(node);

            // Visit adjacent nodes
            foreach (var edge in node.Edges)
            {
                var adjacentNode = edge.GetOtherNode(node);
                if (!visitedNodes.Contains(adjacentNode))
                {
                    DepthFirstSearch(adjacentNode, visitedNodes);
                }
            }
        }
    }
}