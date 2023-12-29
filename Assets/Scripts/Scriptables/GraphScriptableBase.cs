using System.Collections.Generic;
using Core;
using Core.Edges;
using Editor;
using UnityEngine;

namespace Scriptables
{
    public abstract class GraphScriptableBase<TEdge, TNode, TTag> : ScriptableObject
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

    public abstract class PositionGraphScriptableBase : ScriptableObject
    {
        // TODO: Serialize the real edges, but unserialize the GUI. 
        // TODO: Auto generate GUI based on the real edges
        [SerializeField] private EdgeGUI[] edges;

        public IEnumerable<EdgeGUI> Edges => edges;
    }
}