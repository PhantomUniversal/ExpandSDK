#if UNITY_EDITOR

using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using Object = System.Object;

namespace PhantomEngine
{
    [CustomEditor(typeof(Object), true, isFallback = true)]
    [CanEditMultipleObjects] // Object의 경우 다중 사용 예상
    public class PhantomAttributeEditor : PhantomGUIEditor
    {

        #region VARIABLE

        private List<SerializedProperty> _attributeProperties;

        private List<PhantomAttributeTable> _attributeTables;
        
        #endregion



        #region PROPERTY
        
        // IPhantomAttribute를 가지고 있는
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
                    FieldInfo propertyField = target.GetType().GetField(property.name, EditorFlags);
                    if (propertyField == null)
                        continue;

                    object[] propertyAttributes = propertyField.GetCustomAttributes(typeof(IPhantomAttribute),true);
                    if (propertyAttributes.Length > 0)
                    {
                        switch (propertyAttributes[0])
                        {
                            case PhantomFoldoutAttribute foldout:
                                SetAttribute(PhantomAttributeType.Foldout, foldout.EventLabel, property);
                                break;
                        }
                    }
                    else
                    {
                        SetAttribute(PhantomAttributeType.None, property.displayName, property);
                    }
                }
                
                //DrawAttribute();
            }
            else
            {
                DrawDefaultInspector();
            }
        }

        #endregion
        
        

        #region INSPECTOR
        
        // BUG => 추가시키는게 지속적으로 계속 추가되고 있음!
        
        private void SetAttribute(PhantomAttributeType type, string label, SerializedProperty property)
        {
            _attributeTables ??= new List<PhantomAttributeTable>();
            PhantomAttributeTable table = _attributeTables.Find(x => x.eventLabel == label);
            if (table is null)
            {
                _attributeTables.Add(new PhantomAttributeTable
                {
                    eventType = type,
                    eventEnable = false,
                    eventLabel = label,
                    eventProperties = new List<SerializedProperty>
                    {
                        property
                    }
                });
            }
            else
            {
                table.eventProperties.Add(property);
            }
        }

        // private void DrawAttribute()
        // {
        //     if (_attributeTables is null || _attributeTables.Count == 0)
        //         return;
        //     
        //     for (int i = 0; i < _attributeTables.Count; i++)
        //     {
        //         switch (_attributeTables[i].eventType)
        //         {
        //             case PhantomAttributeType.Foldout:
        //                 DrawFoldout(i);
        //                 break;
        //             default:
        //                 DrawProperty(i);
        //                 break;
        //         }
        //     }
        // }
        
        // private void DrawProperty(int index)
        // {
        //     foreach (var property in _attributeTables[index].eventProperties)
        //     {
        //         EditorGUILayout.PropertyField(property);
        //     }
        // }
        //
        // private void DrawFoldout(int index)
        // {
        //     _attributeTables[index].eventEnable = PhantomGUI.Foldout(_attributeTables[index].eventEnable, _attributeTables[index].eventLabel);
        //     if (!_attributeTables[index].eventEnable) 
        //         return;
        //     
        //     foreach (var property in _attributeTables[index].eventProperties)
        //     {
        //         EditorGUILayout.PropertyField(property);
        //     }
        // }
        
        #endregion
        
        
        
        #region UTILITY

        private const BindingFlags EditorFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly;
        
        private FieldInfo[] GetFields()
        {
            return target.GetType().GetFields(EditorFlags);
        }
        
        private PropertyInfo[] GetProperties()
        {
            return target.GetType().GetProperties(EditorFlags);
        }
        
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