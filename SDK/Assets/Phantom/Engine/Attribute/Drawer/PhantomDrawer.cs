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
            SetHeight(PhantomGUIHelper.Property);
            GUI.enabled = DrawerAttribute.EventStatus != PhantomAttributeStatus.ReadOnly;
            
            if (DrawerAttribute.EventStatus != PhantomAttributeStatus.Full)
            {
                string baseLabel = string.IsNullOrEmpty(DrawerAttribute.EventLabel) ? DrawerContent.text : DrawerAttribute.EventLabel;
                PhantomGUI.CustomLabel(PhantomGUIExtension.Label(DrawerRect), baseLabel);
            }

            Rect baseRect = DrawerAttribute.EventStatus == PhantomAttributeStatus.Full ? DrawerRect : PhantomGUIExtension.Property(DrawerRect);
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