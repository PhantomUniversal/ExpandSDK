#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    // Base or Class
    public abstract class PhantomDrawerBase : PropertyDrawer
    {

        #region VARIABLE
        
        protected Rect DrawerRect;
        
        protected SerializedProperty DrawerProperty;
        
        protected GUIContent DrawerContent;
        
        #endregion

        
        
        #region HEIGHT

        private float DrawerHeight { get; set; } = 1;
        
        /// <summary>
        /// Custom size
        /// </summary>
        protected void SetHeight(float height)
        {
            DrawerHeight = height;
        }

        #endregion
        
        
        
        #region ABSTRACT

        protected abstract void OnDrawer();

        #endregion
        
        
        
        #region OVERRIDE
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            Debug.Log(position.height);
            DrawerRect = position;
            DrawerProperty = property;
            DrawerContent = label;
                
            OnDrawer();    
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return DrawerHeight;
        }

        #endregion
        
    }
    
    // Attribute
    public abstract class PhantomDrawerBase<T> : PropertyDrawer where T : PropertyAttribute
    {

        #region VARIABLE

        protected T DrawerAttribute;
        
        protected Rect DrawerRect;
        
        protected SerializedProperty DrawerProperty;
        
        protected GUIContent DrawerContent;
        
        #endregion

        
        
        #region HEIGHT

        private float DrawerHeight { get; set; } = 1;
        
        /// <summary>
        /// Custom size
        /// </summary>
        protected void SetHeight(float height)
        {
            DrawerHeight = height;
        }

        #endregion

        
        
        #region ABSTRACT

        protected abstract void OnDrawer();

        #endregion

        
        
        #region OVERRIDE
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            DrawerAttribute = attribute as T;
            if (DrawerAttribute is not null)
            {
                DrawerRect = position;
                DrawerProperty = property;
                DrawerContent = label;
                
                OnDrawer();    
            }
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return DrawerHeight;
        }

        #endregion
        
    }
}

#endif