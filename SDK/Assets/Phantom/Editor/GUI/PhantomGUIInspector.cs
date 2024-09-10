using UnityEditor;

namespace PhantomEditor
{
    public abstract class PhantomGUIInspector : Editor
    {
        protected abstract void DrawGUI();
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            
            DrawGUI();
            PhantomGUIRepaint.Repaint(this);
            
            if (!EditorGUI.EndChangeCheck())
                return;
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}