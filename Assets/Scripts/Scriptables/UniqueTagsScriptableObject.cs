using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scriptables
{
    public abstract class UniqueTagsScriptableObject<TTag> : ScriptableObject
    {
        [SerializeField] private TTag[] tags;
        
        public IEnumerable<TTag> Tags => tags.Distinct();

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
}