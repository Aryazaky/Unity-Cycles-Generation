using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Scriptables
{
    public abstract class UniqueTagsScriptableBase<TTag> : ScriptableObject, INodeTag<TTag>
    {
        [SerializeField] private TTag[] tags;
        
        public IEnumerable<TTag> Tags => tags.Distinct();
        public bool ContainsTag(TTag tag)
        {
            return tags.Contains(tag);
        }

        private void OnValidate()
        {
            if (tags == null)
            {
                Debug.LogWarning("Tags array is null. Impossible!");
                return;
            }

            HashSet<TTag> uniqueTags = new HashSet<TTag>();
            IEnumerable<TTag> duplicateTags = tags.Where(tag => !uniqueTags.Add(tag));

            foreach (var duplicateTag in duplicateTags)
            {
                Debug.LogWarning($"Duplicate tag found: {duplicateTag}");
            }
        }
    }

    public abstract class NodeTagScriptable<TTag> : UniqueTagsScriptableBase<TTag>
    {
    }

    public abstract class EdgeTagScriptable<TTag> : UniqueTagsScriptableBase<TTag>
    {
    }
}