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
            PhantomGUIUpdate.Repaint(this);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}