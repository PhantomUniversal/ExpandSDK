using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(PhantomLabelAttribute))]
    public class PhantomLabelAttributeDrawer : PhantomDrawerBase<PhantomLabelAttribute>
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        
        protected override void OnDrawer()
        {
            DrawerContent.text = DrawerAttribute.EventLabel;
            
            EditorGUIUtility.labelWidth = DrawerAttribute.EventOption;
            EditorGUI.PropertyField(DrawerRect, DrawerProperty, DrawerContent, true);
        }
    }
}