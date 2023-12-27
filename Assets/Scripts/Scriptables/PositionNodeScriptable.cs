using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "New Node", menuName = "CyclesGen/Non Generic/Node With Position", order = 0)]
    public class PositionNodeScriptable : NodeScriptableBase
    {
        [SerializeField] private Vector3 position;

        public Vector3 Position => position;
    }
}