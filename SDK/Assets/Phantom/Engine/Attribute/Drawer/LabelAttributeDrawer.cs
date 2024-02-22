using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(LabelAttribute))]
    public class LabelAttributeDrawer : PhantomDrawerBase<LabelAttribute>
    {
        protected override void OnDrawer()
        {
            DrawerContent.text = DrawerAttribute.EventLabel;
            EditorGUI.LabelField(PhantomGUIExtension.Label(DrawerRect), DrawerContent);
            DrawerProperty.stringValue = EditorGUI.TextField(PhantomGUIExtension.Property(DrawerRect), DrawerProperty.stringValue);
        }
    }
}