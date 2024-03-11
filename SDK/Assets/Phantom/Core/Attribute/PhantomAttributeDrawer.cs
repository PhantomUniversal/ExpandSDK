#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    // Base or Class
    public abstract class PhantomAttributeDrawer : PropertyDrawer
    {

        #region VARIABLE
        
        protected Rect baseRect;
        
        protected SerializedProperty baseProperty;
        
        protected GUIContent baseContent;
        
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
            
            baseRect = position;
            baseProperty = property;
            baseContent = label;
                
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
    public abstract class PhantomAttributeDrawer<T> : PropertyDrawer where T : PropertyAttribute
    {

        #region VARIABLE

        protected T baseAttribute;
        
        protected Rect baseRect;
        
        protected SerializedProperty baseProperty;
        
        protected GUIContent baseContent;
        
        #endregion

        
        
        #region ABSTRACT

        protected abstract void OnDrawer();

        #endregion

        
        
        #region OVERRIDE
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            baseAttribute = attribute as T;
            if (baseAttribute is not null)
            {
                baseRect = position;
                baseProperty = property;
                baseContent = label;
                
                OnDrawer();    
            }
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PhantomGUIHelper.LayoutProperty;
        }

        #endregion
        
    }
}

#endif