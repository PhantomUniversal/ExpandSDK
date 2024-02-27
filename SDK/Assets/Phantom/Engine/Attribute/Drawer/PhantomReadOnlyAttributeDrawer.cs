using UnityEditor;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(PhantomReadOnlyAttribute))]
    public class PhantomReadOnlyAttributeDrawer : PhantomDrawerBase<PhantomReadOnlyAttribute>
    {
        protected override void OnDrawer()
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(DrawerRect, DrawerProperty, DrawerContent, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}