using UnityEngine;

namespace Scriptables
{
    public abstract class NodeScriptableBase<TTag> : NodeTagScriptable<TTag>
    {
    }

    public abstract class NodeScriptableBase : ScriptableObject
    {
    }
}