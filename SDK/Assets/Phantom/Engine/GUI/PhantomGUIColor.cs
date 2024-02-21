#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUIColor
    {
        
        // ==================================================
        // [ Line ]
        // ==================================================
        public static readonly Color NormalLineColor = EditorGUIUtility.isProSkin ? new Color(0.1f, 0.1f, 0.1f, 1f) : new Color(0.338f, 0.338f, 0.338f, 1f);
        
        
        // ==================================================
        // [ Text ]
        // ==================================================
        public static readonly Color NormalTextColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 1f) : new Color(0.0f, 0.0f, 0.0f, 1f);
        
        public static readonly Color SelectTextColor = new(0.5938f, 0.6172f, 0.9492f, 1f);

    }
}

#endif