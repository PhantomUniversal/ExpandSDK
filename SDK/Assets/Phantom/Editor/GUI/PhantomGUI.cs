using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUI
    {
        #region LAYOUT

        public static Rect BeginVerticalLayout(GUIStyle style = null, params GUILayoutOption[] options)
        {
            style ??= GUIStyle.none;
            return EditorGUILayout.BeginVertical(style, options);
        }

        public static void EndVerticalLayout()
        {
            EditorGUILayout.EndVertical();
        }

        public static Rect BeginHorizontalLayout(GUIStyle style = null, params GUILayoutOption[] options)
        {
            style ??= GUIStyle.none;
            return EditorGUILayout.BeginHorizontal(style, options);
        }

        public static void EndHorizontalLayout()
        {
            EditorGUILayout.EndHorizontal();
        }

        #endregion
        
        #region LABEL

        public static void Label(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUILayout.Property);
            PhantomLabel(controlRect, text, PhantomGUIStyle.Label);
        }

        public static void BoldLabel(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUILayout.Property);
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
                PhantomGUIRepaint.RepaintSpace(rect.height);
            }
            
            GUI.Label(rect, text, style);
        }
        
        #endregion
    }   
}