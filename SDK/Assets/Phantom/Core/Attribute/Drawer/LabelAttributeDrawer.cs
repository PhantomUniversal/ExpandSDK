#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using PhantomEngine;

namespace PhantomEditor
{
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public sealed class LabelAttributeDrawer : PhantomAttributeDrawer<LabelAttribute>
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PhantomGUIHelper.LayoutProperty;
        }
        
        protected override void OnDrawer()
        {
            baseContent.text = baseAttribute.attributeLabel;
            
            EditorGUIUtility.labelWidth = baseAttribute.attributeWidth;
            EditorGUI.PropertyField(baseRect, baseProperty, baseContent, true);
        }
    }
}

#endif