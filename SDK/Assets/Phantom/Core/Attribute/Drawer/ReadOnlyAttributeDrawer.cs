#if UNITY_EDITOR

using UnityEditor;
using PhantomEngine;

namespace PhantomEditor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public sealed class ReadOnlyAttributeDrawer : PhantomAttributeDrawer<ReadOnlyAttribute>
    {
        protected override void OnDrawer()
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(baseRect, baseProperty, baseContent, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}

#endif