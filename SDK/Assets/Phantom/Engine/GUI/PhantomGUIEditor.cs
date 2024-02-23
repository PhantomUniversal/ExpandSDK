#if UNITY_EDITOR

using System.Reflection;
using UnityEditor;

namespace PhantomEngine
{
    public abstract class PhantomGUIEditor : Editor
    {
        
        #region OVERRIDE

        protected abstract void OnInspector();

        #endregion



        #region LIFECYCLE
        
        // Todo 특정 상속 클래스를 찾았을때 true, false
        
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



        #region UTILITY

        protected FieldInfo[] GetFields(object baseTarget)
        {
            if (baseTarget is null)
                return null;

            var baseType = baseTarget.GetType();
            return baseType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        protected PropertyInfo[] GetProperties(object baseTarget)
        {
            if (baseTarget is null)
                return null;

            var baseType = baseTarget.GetType();
            return baseType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }
        
        #endregion
        
    }
    
}

#endif