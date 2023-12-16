using UnityEngine;

namespace Scriptables
{
    public abstract class EdgeScriptableBase<TNode, TTag> : UniqueTagsScriptableObject<TTag>
        where TNode : NodeScriptableBase<TTag>
    {
        [SerializeField] private TNode nodeA;
        [SerializeField] private TNode nodeB;
        private TNode previousNodeA;
        private TNode previousNodeB;
        private void OnValidate()
        {
            if (nodeA != null && nodeB != null && nodeA.Equals(nodeB))
            {
                // Nodes are the same, revert to the previous state
                nodeA = previousNodeA;
                nodeB = previousNodeB;

                Debug.LogWarning("Nodes cannot reference the same object. Reverted to the previous state.");
            }

            // Update the previous state for the next OnValidate call
            previousNodeA = nodeA;
            previousNodeB = nodeB;
        }
    }

    public abstract class EdgeScriptableBase : ScriptableObject
    {
        [SerializeField] private NodeScriptableBase nodeA;
        [SerializeField] private NodeScriptableBase nodeB;
        private NodeScriptableBase previousNodeA;
        private NodeScriptableBase previousNodeB;
        private void OnValidate()
        {
            if (nodeA != null && nodeB != null && nodeA.Equals(nodeB))
            {
                // Nodes are the same, revert to the previous state
                nodeA = previousNodeA;
                nodeB = previousNodeB;

                Debug.LogWarning("Nodes cannot reference the same object. Reverted to the previous state.");
            }

            // Update the previous state for the next OnValidate call
            previousNodeA = nodeA;
            previousNodeB = nodeB;
        }
    }
}