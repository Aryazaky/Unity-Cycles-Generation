using UnityEngine;

namespace Scriptables
{
    public abstract class GraphScriptableBase<TEdge, TNode, TTag> : UniqueTagsScriptableObject<TTag>
        where TEdge : EdgeScriptableBase<TNode, TTag>
        where TNode : NodeScriptableBase<TTag>
    {
        [SerializeField] private TEdge[] edges;
    }
}