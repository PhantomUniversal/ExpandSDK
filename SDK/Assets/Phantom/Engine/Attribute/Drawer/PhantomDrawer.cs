#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(PhantomAttribute), true)]
    public sealed class PhantomDrawer : PhantomDrawerBase<PhantomAttribute>
    {

        #region OVERRIDE

        protected override void OnDrawer()
        {
            GUI.enabled = !DrawerAttribute.EventReadonly;

            bool enable = string.IsNullOrEmpty(DrawerAttribute.EventLabel); 
            if (!enable)
            {
                PhantomGUI.CustomLabel(PhantomGUIExtension.Label(DrawerRect), DrawerAttribute.EventLabel);
            }

            Rect baseRect = enable ? DrawerRect : PhantomGUIExtension.Property(DrawerRect);
            switch (DrawerProperty.propertyType)
            {
                case SerializedPropertyType.String:
                    DrawerProperty.stringValue = PhantomGUI.CustomText(baseRect, DrawerProperty.stringValue);                
                    break;
                case SerializedPropertyType.Enum:
                    DrawerProperty.intValue = PhantomGUI.CustomPopup(baseRect, DrawerProperty.intValue, DrawerProperty.enumDisplayNames);
                    break;
            }

            GUI.enabled = true;
        }

        #endregion
    }
}

#endif