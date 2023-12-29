using System;
using Scriptables;
using UnityEngine;

namespace Editor
{
    [Serializable]
    public class NodeGUI
    {
        [SerializeField] private string guid;
        [SerializeField] private Rect box;
        [SerializeField] private string text;
        [SerializeField] private NodeTagScriptable<string> nodeData;

        public Rect Box => box;

        public string Text => text;

        public NodeGUI(Vector2 position, Vector2 size, string text)
        {
            box = new Rect(position, size);
            this.text = text;
        }

        public void Paint()
        {
            GUI.Box(box, text);
        }
        
        public void HandleEvent(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDrag:
                    if (box.Contains(e.mousePosition))
                    {
                        box.position += e.delta;
                    }
                    break;
            }
        }
    }
}