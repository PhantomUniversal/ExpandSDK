using System;
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

        #region SPACE

        public static void Space()
        {
            PhantomSpace(PhantomGUILayout.DefaultProperty);
        }

        public static void CustomSpace(float pixels)
        {
            PhantomSpace(pixels);
        }

        private static void PhantomSpace(float pixels)
        {
            EditorGUILayout.Space(pixels);
        }

        #endregion
        
        #region LABEL
        
        public static void Label(string text, bool bold = false, bool repaint = false)
        {
            var controlRect = EditorGUILayout.GetControlRect(false, PhantomGUILayout.DefaultProperty);
            var style = bold ? PhantomGUIStyle.BoldLabel : PhantomGUIStyle.Label;
            PhantomLabel(controlRect, text, style, repaint);
        }
        
        public static void CustomLabel(Rect rect, string text, GUIStyle style = null, bool repaint = false)
        {
            style ??= PhantomGUIStyle.Label;
            PhantomLabel(rect, text, style, repaint);
        }
        
        private static void PhantomLabel(Rect rect, string text, GUIStyle style, bool repaint)
        {
            if (repaint)
            {
                PhantomGUIUpdate.RepaintSpace(rect.height);
            }
            
            GUI.Label(rect, text, style);
        }
        
        #endregion

        #region BUTTON

        public static void Button(string text, Action action = null, bool bold = false)
        {
            var controlRect = EditorGUILayout.GetControlRect(false, PhantomGUILayout.DefaultProperty);
            var style = bold ? PhantomGUIStyle.BoldButton : PhantomGUIStyle.Button;
            PhantomButton(controlRect, text, action, style, true);
        }

        public static void CustomButton(string text, float width, float height, Action action = null, GUIStyle style = null, bool repaint = false)
        {
            var controlRect = EditorGUILayout.GetControlRect(false, height);
            controlRect.width = width;
            style ??= GUI.skin.button;
            PhantomButton(controlRect, text, action, style, repaint);
        }
        
        private static void PhantomButton(Rect rect, string text, Action action, GUIStyle style, bool repaint)
        {
            if (repaint)
            {
                PhantomGUIUpdate.RepaintSpace(rect.height);
            }
            
            if (GUI.Button(rect, text, style))
            {
                action?.Invoke();
            }
        }

        #endregion
    }   
}