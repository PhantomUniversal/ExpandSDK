#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEngine
{
    
    [CustomPropertyDrawer(typeof(PhantomPopupAttribute), true)]
    public class PhantomPopupDrawer : PhantomDrawer<PhantomPopupAttribute>
    {
        protected override void OnDrawer()
        {
            DrawerLabel = DrawerAttribute.Label;
            if (DrawerProperty.propertyType == SerializedPropertyType.Enum)
            {
                DrawerProperty.intValue = EditorGUI.Popup(DrawerRect, DrawerProperty.intValue, DrawerProperty.enumDisplayNames, PhantomGUIStyle.Popup);
            }
        }
    }
    
}

#endif