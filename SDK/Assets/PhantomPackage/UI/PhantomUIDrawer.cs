#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEngine.UI
{
    [CustomPropertyDrawer(typeof(PhantomUIConfig), true)]
    public sealed class PhantomUIConfigDrawer : PhantomDrawerBase
    {
        protected override void OnDrawer()
        {
            SetHeight(1);
            EditorGUILayout.PropertyField(DrawerProperty.FindPropertyRelative("type"));
            EditorGUILayout.PropertyField(DrawerProperty.FindPropertyRelative("uid"));
        }
    }
    
}

#endif