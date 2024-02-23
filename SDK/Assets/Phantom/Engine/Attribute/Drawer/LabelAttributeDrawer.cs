using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelAttributeDrawerTemp : PhantomDrawerBase<LabelAttribute>
    {
        protected override void OnDrawer()
        {
            EditorGUI.PropertyField(DrawerRect, DrawerProperty, DrawerContent);
        }
    }
    
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelAttributeDrawer : PhantomDrawerBase<LabelAttribute>
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        
        protected override void OnDrawer()
        {
            
            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(DrawerRect, DrawerProperty, DrawerContent, true);
            EditorGUI.indentLevel--;
        }
    }
}