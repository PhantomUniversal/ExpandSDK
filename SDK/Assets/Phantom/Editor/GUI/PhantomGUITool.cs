using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public abstract class PhantomGUITool : EditorWindow
    {
        protected abstract void DrawGUI();
        
        public abstract string DrawName { get; }
        public abstract Vector2 DrawSize { get; }
        public abstract PhantomGUILocation DrawLocation { get; }

        
        private SerializedObject _serializedObject;
        
        private void OnEnable()
        {
            _serializedObject = new SerializedObject(this);   
        }

        private void OnDisable()
        {
            _serializedObject = null;
        }

        private void OnGUI()
        {
            _serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            
            DrawGUI();
            PhantomGUIRepaint.Repaint(this);
            
            if (!EditorGUI.EndChangeCheck())
                return;
            
            _serializedObject.ApplyModifiedProperties();
        }
    }
}