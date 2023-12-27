using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    public abstract class GraphScriptableBase<TEdge, TNode, TTag> : UniqueTagsScriptableObject<TTag>
        where TEdge : EdgeScriptableBase<TNode, TTag>
        where TNode : NodeScriptableBase<TTag>
    {
        [SerializeField] private TEdge[] edges;
    }

    public abstract class GraphScriptableBase : ScriptableObject
    {
        [SerializeField] private EdgeScriptableBase[] edges;

        public IEnumerable<EdgeScriptableBase> Edges => edges;
    }
}