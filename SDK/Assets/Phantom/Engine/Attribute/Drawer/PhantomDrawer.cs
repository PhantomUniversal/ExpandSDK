#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(PhantomAttribute))]
    public sealed class PhantomDrawer : PhantomDrawerBase<PhantomAttribute>
    {

        #region OVERRIDE

        protected override void OnDrawer()
        {
            DrawerContent.text = string.IsNullOrEmpty(DrawerAttribute.EventLabel) ? DrawerContent.text : DrawerAttribute.EventLabel;
            switch (DrawerProperty.propertyType)
            {
                case SerializedPropertyType.String:
                    DrawerProperty.stringValue =
                        EditorGUI.TextField(DrawerRect, DrawerContent, DrawerProperty.stringValue);                
                    break;
                // case SerializedPropertyType.Enum:
                //     DrawerProperty.intValue = PhantomGUI.CustomPopup(baseRect, DrawerProperty.intValue, DrawerProperty.enumDisplayNames);
                //     break;
            }
        }

        #endregion
        
    }
}

#endif