using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Utilities.VF3
{
    public class VF3State<T, TTag> where T : INode where TTag : IEquatable<TTag>
    {
        private readonly Graph<T> graph1;
        private readonly Graph<T> graph2;
        private PairSet<T> coreMapping = new PairSet<T>();
        private HashSet<T> nodeCandidates1;
        private HashSet<T> nodeCandidates2;

        public VF3State(Graph<T> graph1, Graph<T> graph2)
        {
            this.graph1 = graph1;
            this.graph2 = graph2;

            // Initialize nodeCandidates with all nodes initially
            nodeCandidates1 = new HashSet<T>(graph1);
            nodeCandidates2 = new HashSet<T>(graph2);
        }
        
        public bool IsGoal()
        {
            // Check if all nodes are mapped
            return !nodeCandidates1.Any() && !nodeCandidates2.Any();
        }

        public IEnumerable<VF3State<T, TTag>> GetSuccessors()
        {
            foreach (var node1 in nodeCandidates1)
            {
                foreach (var node2 in nodeCandidates2)
                {
                    if (IsFeasiblePair(node1, node2))
                    {
                        // Extend the mapping and create a new successor state
                        var successor = new VF3State<T, TTag>(graph1, graph2)
                        {
                            coreMapping = new PairSet<T>(coreMapping),
                            nodeCandidates1 = new HashSet<T>(nodeCandidates1),
                            nodeCandidates2 = new HashSet<T>(nodeCandidates2)
                        };

                        successor.coreMapping.Add(new Pair<T>(node1, node2));
                        successor.nodeCandidates1.Remove(node1);
                        successor.nodeCandidates2.Remove(node2);

                        yield return successor;
                    }
                }
            }
        }
        
        private bool IsFeasiblePair(INode node1, INode node2)
        {
            // Check structural constraints (e.g., degree, adjacency)
            if (!AreStructurallyFeasible(node1, node2))
                return false;

            // Check semantic constraints based on tags
            if (!AreSemanticallyFeasible(node1, node2))
                return false;

            // Additional checks and constraints can be added as needed

            return true;
        }

        private bool AreStructurallyFeasible(INode node1, INode node2)
        {
            // Check if the nodes have the same edge count
            return node1.Edges.Count() == node2.Edges.Count();
        }

        private bool AreSemanticallyFeasible(INode node1, INode node2)
        {
            // Check if the nodes have at least one common tag
            if (node1 is INodeTag<TTag> tag1 && node2 is INodeTag<TTag> tag2)
            {
                return tag1.Tags.Any(tag => tag2.ContainsTag(tag));
            }

            return false;
        }

    }
}