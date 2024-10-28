using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public abstract class PhantomGUITool : EditorWindow
    {
        public abstract string DrawName { get; }
        public abstract Vector2 DrawSize { get; }
        
        
        protected abstract void DrawOpen();
        protected abstract void DrawClose();
        protected abstract void DrawGUI();
        
        
        private SerializedObject _serializedObject;
        
        private void OnEnable()
        {
            _serializedObject = new SerializedObject(this);
            DrawOpen();
        }

        private void OnDisable()
        {
            _serializedObject = null;
            DrawClose();
        }

        private void OnGUI()
        {
            _serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            
            DrawGUI();
            Repaint();
            
            if (EditorGUI.EndChangeCheck())
            {
                _serializedObject.ApplyModifiedProperties();    
            }
        }
    }
}