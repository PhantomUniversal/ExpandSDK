#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEngine
{
    public abstract class PhantomGUIEditor : Editor
    {
        
        #region OVERRIDE
        
        protected abstract void OnInspector();

        #endregion



        #region LIFECYCLE

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            PhantomGUI.BeginGroupLayout();
            
            OnInspector();
            PhantomGUIUtility.Repaint(this);
            
            PhantomGUI.EndGroupLayout();
            
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);    
            }
        }

        #endregion
        
    }
    
}

#endif