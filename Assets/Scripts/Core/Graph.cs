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

        public bool IsVertexInducedSubgraphOf(Graph other)
        {
            // Check if all nodes from this graph are present in the other graph
            if (nodes.All(node => other.nodes.Contains(node)))
            {
                // Check if all edges between nodes in this graph are also present in the other graph
                foreach (var node in nodes)
                {
                    foreach (var edge in node.Edges)
                    {
                        var otherNodeA = other.nodes.FirstOrDefault(n => n.Equals(edge.NodeA));
                        var otherNodeB = other.nodes.FirstOrDefault(n => n.Equals(edge.NodeB));
                    
                        // If the edge is not present in the other graph, return false
                        if (otherNodeA == null || otherNodeB == null ||
                            !otherNodeA.Edges.Any(e => e.GetOtherNode(otherNodeA).Equals(otherNodeB)))
                        {
                            return false;
                        }
                    }
                }

                // All nodes and edges are present in the other graph
                return true;
            }

            // Not all nodes are present in the other graph
            return false;
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