#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    
    [CustomPropertyDrawer(typeof(PhantomEnumAttribute))]
    public class PhantomEnumDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            PhantomEnumAttribute baseAttribute = (PhantomEnumAttribute)attribute;
            if (property.propertyType == SerializedPropertyType.Enum)
            {
                bool enable = string.IsNullOrEmpty(baseAttribute.Label);
                position.x += enable ? position.x : PhantomGUIHelper.Label;
                position.width = enable ? position.width : position.width - PhantomGUIHelper.Label;
                position.height = PhantomGUIHelper.Content;
                
                property.intValue = EditorGUI.Popup(position, property.intValue, property.enumDisplayNames, PhantomGUIStyle.Popup);

                if (!enable)
                {
                    position.x -= PhantomGUIHelper.Label;
                    position.width = PhantomGUIHelper.Label;
                    position.height = PhantomGUIHelper.Content;
                    GUI.Label(position, baseAttribute.Label, PhantomGUIStyle.LeftBoldLabel);
                }
            }
            
            EditorGUI.EndProperty();
        }
    }
    
}

#endif