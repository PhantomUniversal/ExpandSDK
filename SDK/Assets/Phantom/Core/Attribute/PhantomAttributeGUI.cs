#if UNITY_EDITOR

using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using Object = System.Object;
using PhantomEngine;

namespace PhantomEditor
{
    [CustomEditor(typeof(Object), true, isFallback = true)]
    [CanEditMultipleObjects] // Object의 경우 다중 사용 예상
    public sealed class PhantomAttributeGUI : PhantomGUIEditor
    {
        
        #region VARIABLE

        /// <summary>
        /// Class all property
        /// </summary>
        private List<SerializedProperty> _attributeProperties;

        /// <summary>
        /// Attribute key = label, value = table
        /// </summary>
        private Dictionary<string, PhantomAttributeTable> _attributeTables;
        
        #endregion



        #region PROPERTY
        
        // Class exist attribute `IPhantomAttribute'
        private bool IsAttribute
        {
            get
            {
                FieldInfo[] fields = GetFields();
                foreach (var field in fields)
                {
                    IPhantomAttribute[] attribute = GetAttributes<IPhantomAttribute>(field);
                    return attribute.Length > 0;
                }
        
                return false;
            }
        }

        #endregion



        #region LIFECYCLE

        private void OnEnable()
        {
            GetSerializedProperties(ref _attributeProperties);
        }

        private void OnDisable()
        {
            if (_attributeProperties is null)
                return;
            
            _attributeProperties.Clear();
            _attributeProperties = null;
        }

        protected override void OnInspector()
        {
            if (IsAttribute)
            {
                foreach (var property in _attributeProperties)
                {
                    FieldInfo propertyField = target.GetType().GetField(property.name, PhantomAttributeHelper.Flags);
                    if (propertyField == null)
                        continue;

                    object[] propertyAttributes = propertyField.GetCustomAttributes(typeof(IPhantomAttribute),true);
                    if (propertyAttributes.Length > 0)
                    {
                        switch (propertyAttributes[0])
                        {
                            case FoldoutAttribute foldout:
                                SetAttribute(PhantomAttributeType.Foldout, foldout.attributeLabel, property);
                                break;
                        }
                    }
                    else
                    {
                        SetAttribute(PhantomAttributeType.None, property.displayName, property);
                    }
                }
                
                DrawAttribute();
            }
            else
            {
                DrawDefaultInspector();
            }
        }

        #endregion
        
        

        #region INSPECTOR
        
        private void SetAttribute(PhantomAttributeType type, string label, SerializedProperty property)
        {
            _attributeTables ??= new Dictionary<string, PhantomAttributeTable>();
            if (_attributeTables.ContainsKey(label))
            {
                if(!_attributeTables[label].eventProperties.Contains(property))
                    _attributeTables[label].eventProperties.Add(property);
            }
            else
            {
                _attributeTables.Add(label, new PhantomAttributeTable
                {
                    eventType = type,
                    eventEnable = false,
                    eventLabel = label,
                    eventProperties = new List<SerializedProperty>()
                    {
                        property
                    }
                });
            }
        }

        private void DrawAttribute()
        {
            if (_attributeTables is null || _attributeTables.Count == 0)
                return;

            foreach (var table in _attributeTables)
            {
                switch (table.Value.eventType)
                {
                    case PhantomAttributeType.Foldout:
                        DrawFoldout(table.Value);
                        break;
                    case PhantomAttributeType.None:
                        DrawProperty(table.Value);
                        break;
                }
            }
        }
        
        #endregion



        #region DRAWER

        private void DrawProperty(PhantomAttributeTable table)
        {
            foreach (var property in table.eventProperties)
            {
                EditorGUILayout.PropertyField(property);
            }
        }

        private void DrawFoldout(PhantomAttributeTable table)
        {
            table.eventEnable = PhantomGUI.Foldout(table.eventEnable, table.eventLabel);
            if (!table.eventEnable) 
                return;
            
            foreach (var property in table.eventProperties)
            {
                EditorGUILayout.PropertyField(property);
            }
        }

        #endregion
        
        
        
        #region UTILITY
        
        private FieldInfo[] GetFields()
        {
            return target.GetType().GetFields(PhantomAttributeHelper.Flags);
        }
        
        // private PropertyInfo[] GetProperties()
        // {
        //     return target.GetType().GetProperties(AttributeFlags);
        // }
        
        private void GetSerializedProperties(ref List<SerializedProperty> serializedProperties)
        {
            serializedProperties ??= new List<SerializedProperty>();
            serializedProperties.Clear();

            using var iterator = serializedObject.GetIterator();
            if (!iterator.NextVisible(true)) 
                return;
            
            do
            {
                serializedProperties.Add(serializedObject.FindProperty(iterator.name));
            }
            while (iterator.NextVisible(false));
        }
        
        private T[] GetAttributes<T>(FieldInfo baseField)
        { 
            return baseField.GetCustomAttributes(typeof(T),true) as T[];
        }
        
        #endregion

    }
}

#endif