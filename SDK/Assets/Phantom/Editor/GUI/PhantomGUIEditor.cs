using UnityEditor;

namespace PhantomEditor
{
    
    public abstract class PhantomGUIEditor : Editor
    {

        #region OVERRIDE

        protected abstract void OnInspector();

        #endregion



        #region LIFECYCLE

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            PhantomGUIUtility.Repaint(this);
            OnInspector();
            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);    
            }
        }

        #endregion
        
    }
    
}