using System;
using UnityEditor;

namespace PhantomEditor
{
    public abstract class PhantomGUIInspector : Editor
    {
        protected abstract void DrawOpen();
        protected abstract void DrawGUI();
        protected abstract void DrawClose();

        
        public void OnEnable()
        {
            DrawOpen();
        }

        public void OnDisable()
        {
            DrawClose();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            DrawGUI();
            Repaint();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}