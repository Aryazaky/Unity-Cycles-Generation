using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class GraphUtils
    {
        public static bool AreAllNodesConnected<T>(List<T> nodes) where T : INode
        {
            if (!nodes.Any())
            {
                // No nodes to traverse
                return false;
            }
            // Create a set to keep track of visited nodes
            var visitedNodes = new HashSet<T>();

            // Start DepthFirstSearch from the first node in the list
            DepthFirstSearch(nodes[0], visitedNodes);

            // If all nodes are visited, they are connected as one island
            return visitedNodes.Count == nodes.Count;
        }

        private static void DepthFirstSearch<T>(T node, ISet<T> visitedNodes) where T : INode
        {
            // Mark the current node as visited
            visitedNodes.Add(node);

            // Visit adjacent nodes
            foreach (var edge in node.Edges)
            {
                INode adjacentNode = edge.GetOtherNode(node);

                // Check if adjacentNode is of type T before casting
                if (adjacentNode is T adjacentNodeAsT && !visitedNodes.Contains(adjacentNodeAsT))
                {
                    DepthFirstSearch(adjacentNodeAsT, visitedNodes);
                }
            }
        }
    }
}