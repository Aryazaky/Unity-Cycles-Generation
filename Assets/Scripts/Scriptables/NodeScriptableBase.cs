using UnityEngine;

namespace Scriptables
{
    public abstract class NodeScriptableBase<TTag> : UniqueTagsScriptableObject<TTag>
    {
    }

    public abstract class NodeScriptableBase : ScriptableObject
    {
        public void HandleEvent(Event e)
        {
            
        }
    }
}