using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Edges;
using Core.Nodes;
using Scriptables;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GraphEditorWindow : EditorWindow
    {
        private PositionGraphScriptableBase graphScriptable;
        private List<NodeUI> wildNodes = new();

        [MenuItem("Window/CyclesGen/Graph Editor")]
        public static GraphEditorWindow OpenGraphEditorWindow()
        {
            return EditorWindow.GetWindow<GraphEditorWindow>("Graph Editor Window");
        }

        [UnityEditor.Callbacks.OnOpenAsset(1)]
        public static bool OnOpenGraph(int instanceID, int line)
        {
            var file = EditorUtility.InstanceIDToObject(instanceID) as PositionGraphScriptableBase;
            if (file != null)
            {
                var window = OpenGraphEditorWindow();
                window.graphScriptable = file;
                return true;
            }

            return false;
        }

        private void OnGUI()
        {
            if (graphScriptable != null)
            {
                int i = 0;
                foreach (var edge in graphScriptable.Edges)
                {
                    GUI.Label(new Rect(10, 10 + i, 1000, 20),
                        $"{edge} is connecting {edge.NodeA.Box} to {edge.NodeB.Box}");
                    i += 20;
                }

                HandleEvent(Event.current);

                PaintNodes();

                PaintEdges();
                
                Repaint();
            }
        }

        private void PaintNodes()
        {
            foreach (var node in graphScriptable.Edges.SelectMany(edge => edge.Nodes))  
            {
                node.Paint();
            }
        }

        private void PaintEdges()
        {
            
        }

        private void HandleEvent(Event e)
        {
            foreach (var node in graphScriptable.Edges.SelectMany(edge => edge.Nodes))
            {
                node.HandleEvent(e);
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 1)
                    {
                        OpenContextMenu(e.mousePosition);
                    }
                    break;
            }
        }

        private void OpenContextMenu(Vector2 mousePosition)
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Add Node"), false, () => OnAddNode(mousePosition));
            genericMenu.ShowAsContext();
        }

        private void OnAddNode(Vector2 mousePosition)
        {
            NodeUI newNodeUI = new NodeUI(mousePosition, new Vector2(100, 100), $"Node {wildNodes.Count}");
            wildNodes.Add(newNodeUI);
        }
    }
}