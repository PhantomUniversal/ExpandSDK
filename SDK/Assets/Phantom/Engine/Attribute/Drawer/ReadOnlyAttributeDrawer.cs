using UnityEditor;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeDrawer : PhantomDrawerBase<ReadOnlyAttribute>
    {
        protected override void OnDrawer()
        {
            EditorGUI.BeginDisabledGroup(true);
            //EditorGUI.PropertyField(DrawerRect, DrawerProperty, DrawerContent, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}