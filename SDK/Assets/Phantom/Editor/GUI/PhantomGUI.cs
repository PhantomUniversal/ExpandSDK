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
            var position = EditorGUILayout.GetControlRect(false, PhantomGUILayout.DefaultProperty);
            var style = bold ? PhantomGUIStyle.BoldLabel : PhantomGUIStyle.Label;
            PhantomLabel(position, text, style, repaint);
        }
        
        public static void CustomLabel(Rect position, string text, bool repaint = false, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.Label;
            PhantomLabel(position, text, style, repaint);
        }
        
        private static void PhantomLabel(Rect position, string text, GUIStyle style, bool repaint)
        {
            if (repaint)
            {
                PhantomGUIUpdate.RepaintSpace(position.height);
            }
            
            GUI.Label(position, text, style);
        }
        
        #endregion

        #region BUTTON
        // I think it is necessary to separate the buttons by type
        public static bool Button(string text, bool bold = false)
        {
            var position = EditorGUILayout.GetControlRect(false, PhantomGUILayout.DefaultProperty);
            var style = bold ? PhantomGUIStyle.BoldButton : PhantomGUIStyle.Button;
            var content = new GUIContent(text);
            return PhantomButton(position, content, style, true);
        }
        
        public static bool Button(Texture texture)
        {
            var position = EditorGUILayout.GetControlRect(false, PhantomGUILayout.DefaultProperty);
            var style = GUI.skin.button;
            var content = new GUIContent(texture);
            return PhantomButton(position, content,  style, false);
        }
        
        public static bool CustomButton(string text, float width, float height, bool repaint = false, GUIStyle style = null)
        {
            var position = EditorGUILayout.GetControlRect(false, GUILayout.Width(width), GUILayout.Height(height));
            style ??= GUI.skin.button;
            var content = new GUIContent(text);
            return PhantomButton(position, content, style, repaint);
        }
        
        public static bool CustomButton(Texture texture, float width, float height, bool repaint = false, GUIStyle style = null)
        {
            var position = EditorGUILayout.GetControlRect(false, GUILayout.Width(width), GUILayout.Height(height));
            style ??= GUI.skin.button;
            var content = new GUIContent(texture);
            return PhantomButton(position, content, style, repaint);
        }
        
        private static bool PhantomButton(Rect position, GUIContent content, GUIStyle style, bool repaint)
        {
            if (repaint)
            {
                PhantomGUIUpdate.RepaintSpace(position.height);
            }

            return GUI.Button(position, content, style);
        }
        
        #endregion
    }   
}