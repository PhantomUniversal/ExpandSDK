using UnityEditor;
using UnityEngine;

namespace PhantomCore
{
    public static class PhantomGUI
    {
        #region LABEL

        public static void Label(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            PhantomLabel(controlRect, text, PhantomGUIStyle.Label);
        }

        public static void BoldLabel(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            PhantomLabel(controlRect, text, PhantomGUIStyle.BoldLabel);
        }

        public static void CustomLabel(Rect rect, string text, GUIStyle style = null, bool repaint = false)
        {
            style ??= PhantomGUIStyle.Label;
            PhantomLabel(rect, text, style, repaint);
        }
        
        private static void PhantomLabel(Rect rect, string text, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.RepaintSpace(rect.height);
            }
            
            GUI.Label(rect, text, style);
        }
        
        #endregion
    }   
}