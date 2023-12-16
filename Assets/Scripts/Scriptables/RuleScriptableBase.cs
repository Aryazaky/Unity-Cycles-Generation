using System;
using Core;
using Core.Nodes;
using UnityEngine;

namespace Scriptables
{
    public abstract class RuleScriptableBase<TGraph, TEdge, TNode, TTag> : ScriptableObject 
        where TGraph : GraphScriptableBase<TEdge, TNode, TTag> 
        where TEdge : EdgeScriptableBase<TNode, TTag> 
        where TNode : NodeScriptableBase<TTag>
    {
        [SerializeField] private TGraph from;
        [SerializeField] private TGraph to;

        public Graph<PositionNode> GetResultingGraph()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class RuleScriptableBase : ScriptableObject
    {
        [SerializeField] private GraphScriptableBase from;
        [SerializeField] private GraphScriptableBase to;
        
        public Graph<PositionNode> GetResultingGraph()
        {
            throw new NotImplementedException();
        }
    }
}