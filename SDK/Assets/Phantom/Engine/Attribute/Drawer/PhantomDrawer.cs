#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    
    public abstract class PhantomDrawer<T> : PropertyDrawer where T : PropertyAttribute
    {
        protected abstract void OnDrawer();

        protected Rect DrawerRect;

        protected T DrawerAttribute;
        
        protected SerializedProperty DrawerProperty;
        
        protected string DrawerLabel;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            bool enable = string.IsNullOrEmpty(DrawerLabel);
            position.x += enable ? 0 : PhantomGUIHelper.Label;  
            position.width = enable ? position.width : position.width - PhantomGUIHelper.Label;
            position.height = PhantomGUIHelper.Content;
            DrawerRect = position;
            
            if (!enable)
            {
                position.x -= PhantomGUIHelper.Label;
                position.width = PhantomGUIHelper.Label;
                position.height = PhantomGUIHelper.Content;
                GUI.Label(position, DrawerLabel, PhantomGUIStyle.LeftBoldLabel);
            }

            DrawerAttribute = attribute as T;
            if (DrawerAttribute is not null)
            {
                DrawerProperty = property;
                OnDrawer();    
            }
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PhantomGUIHelper.Content;
        }
    }
}

#endif