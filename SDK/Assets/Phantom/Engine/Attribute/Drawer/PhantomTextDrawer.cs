#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    [CustomPropertyDrawer(typeof(PhantomTextAttribute), true)]
    public class PhantomTextDrawer : PhantomDrawer<PhantomTextAttribute>
    {
        protected override void OnDrawer()
        {
            DrawerLabel = DrawerAttribute.Label;
            if (DrawerProperty.propertyType == SerializedPropertyType.String)
            {
                DrawerProperty.stringValue = GUI.TextField(DrawerRect, DrawerProperty.stringValue);
            }
        }
    }
}

#endif