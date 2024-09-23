using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIColor
    {
        public static readonly Color Normal = EditorGUIUtility.isProSkin ? Color.white : Color.black;
        
        public static readonly Color Selected = new(0.5938f, 0.6172f, 0.9492f, 1f);

        public static readonly Color Disabled = new(0.8f, 0.8f, 0.8f, 1f);
    }
}