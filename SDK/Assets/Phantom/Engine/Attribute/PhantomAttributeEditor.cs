using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace PhantomEngine
{
    [CustomEditor(typeof(Object), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class PhantomAttributeEditor : PhantomGUIEditor
    {

        private FieldInfo[] _eventFields;
        private PropertyInfo[] _eventProperty;
        
        
        private void OnEnable()
        {
            _eventFields = GetFields(target);
            _eventProperty = GetProperties(target);
        }

        protected override void OnInspector()
        {
            foreach (var field in _eventFields)
            {
                var attributes = (FoldoutGroupAttribute[])field.GetCustomAttributes(typeof(FoldoutGroupAttribute),true);
                foreach (var attribute in attributes)
                {
                    // 1. Group 별로 빼내기
                    // 2. 아래에 오브젝트 두기
                    PhantomGUI.FoldoutHeader(true, attribute.EventLabel);
                }
            }
            
            // foreach (var field in baseFields)
            // {

            // }
        }
        
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