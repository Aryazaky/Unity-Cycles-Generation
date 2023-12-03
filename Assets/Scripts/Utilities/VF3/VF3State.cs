using System.Collections.Generic;
using Core;

namespace Utilities.VF3
{
    public class VF3State<T> where T : INode
    {
        private readonly Graph graph1;
        private readonly Graph graph2;
        private PairSet<T> coreMapping = new PairSet<T>();
        private Dictionary<T, bool> nodeCandidates1 = new Dictionary<T, bool>();
        private Dictionary<T, bool> nodeCandidates2 = new Dictionary<T, bool>();

        public VF3State(Graph graph1, Graph graph2)
        {
            this.graph1 = graph1;
            this.graph2 = graph2;

            foreach (T node in graph1)
            {
                nodeCandidates1[node] = true;
            }

            foreach (T node in graph2)
            {
                nodeCandidates2[node] = true;
            }
        }
    }
}