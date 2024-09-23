using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public abstract class PhantomGUIWindow : EditorWindow
    {
        protected abstract void DrawGUI();
        
        public abstract string DrawName { get; }
        public abstract Vector2 DrawSize { get; }
        public abstract PhantomGUILocationType DrawLocation { get; }

        
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
            PhantomGUIUpdate.Repaint(this);

            if (EditorGUI.EndChangeCheck())
            {
                _serializedObject.ApplyModifiedProperties();    
            }
        }
    }
}