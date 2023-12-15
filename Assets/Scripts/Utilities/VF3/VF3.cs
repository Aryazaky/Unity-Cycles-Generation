using System;
using System.Linq;
using Core;

namespace Utilities.VF3
{
    public class VF3<T, TTag> where T : INode where TTag : IEquatable<TTag>
    {
        public static bool IsIsomorphic(Graph<T> graph1, Graph<T> graph2)
        {
            VF3State<T, TTag> initialState = new VF3State<T, TTag>(graph1, graph2);
            return VF3Search(initialState);
        }

        private static bool VF3Search(VF3State<T, TTag> state)
        {
            if (state.IsGoal())
            {
                // Goal state found, graphs are isomorphic
                return true;
            }

            return state.GetSuccessors().Any(VF3Search);
        }
    }
}
