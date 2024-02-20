#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUI
    {
        
        // ==================================================
        // [ Border ]
        // ==================================================
        public static void DrawBorderRect(Rect rect)
        {
            EditorGUI.DrawRect(PhantomGUIExtension.LeftLine(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.RightLine(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.TopLine(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.BottomLine(rect), Color.white);
        }
        
        
        // ==================================================
        // [ Layout ]
        // ==================================================
        public static Rect BeginLayout(params GUILayoutOption[] options) => BeginLayout(false, options);
        
        public static Rect BeginLayout(bool background = false, params GUILayoutOption[] options)
        {
            return background ? EditorGUILayout.BeginVertical(GUI.skin.box, options) : EditorGUILayout.BeginVertical(GUIStyle.none, options);
        }

        public static void EndLayout()
        {
            EditorGUILayout.EndVertical();
        }
        
        
        // ==================================================
        // [ Background ]
        // ==================================================
        public static void Background(Rect rect)
        {
            GUI.Box(rect, "", GUI.skin.box);
        }

        public static void BackgroundBox(Rect rect)
        {
            GUI.Box(rect, "", EditorStyles.helpBox);
        }
        
        
        // ==================================================
        // [ Foldout ]
        // ==================================================
        public static bool FoldoutHeader(bool enable, string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false);
            return FoldoutHeader(controlRect, enable, text);
        }

        public static bool FoldoutHeader(Rect rect, bool enable, string text)
        {
            enable = EditorGUI.BeginFoldoutHeaderGroup(rect, enable, text, PhantomGUIStyle.FoldoutHeader);
            BackgroundBox(rect);
            EditorGUI.EndFoldoutHeaderGroup();
            return enable;
        }
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        public static void Label(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false);
            CustomLabel(controlRect, text);
        }

        public static void CustomLabel(Rect rect, string text)
        {
            GUI.Label(rect, text, PhantomGUIStyle.LeftBoldLabel);
        }
        
        
        // ==================================================
        // [ Text ]
        // ==================================================
        public static string Text(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false);
            return CustomText(controlRect, text);
        }

        public static string CustomText(Rect rect, string text)
        {
            return GUI.TextField(rect, text, PhantomGUIStyle.Text);
        }
        
        
        // ==================================================
        // [ Popup ]
        // ==================================================
        public static int Popup(int select, string[] displayOptions)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false);
            return CustomPopup(controlRect, select, displayOptions);
        }
        
        public static int CustomPopup(Rect rect, int select, string[] displayOptions)
        {
            return EditorGUI.Popup(rect, select, displayOptions, PhantomGUIStyle.Popup);
        }
        
        
        // ==================================================
        // [ EnumPopup ] => Label 삭제
        // ==================================================
        public static Enum EnumPopup(Enum popup, string text) => EnumPopup(popup, new GUIContent(text));
        
        public static Enum EnumPopup(Enum popup, GUIContent content)
        {
            Rect baseRect = EditorGUILayout.GetControlRect(false);
            baseRect.x += content is null ? baseRect.x : PhantomGUIHelper.Label;
            baseRect.width = content is null ? baseRect.width : baseRect.width - PhantomGUIHelper.Label;
            baseRect.height = PhantomGUIHelper.Property;
            
            popup = EditorGUI.EnumPopup(baseRect, popup, PhantomGUIStyle.Popup);
            if (content is not null)
            {
                baseRect.x -= PhantomGUIHelper.Label;
                baseRect.width = PhantomGUIHelper.Label;
                baseRect.height = PhantomGUIHelper.Property;
                GUI.Label(baseRect, content, PhantomGUIStyle.LeftBoldLabel);
            }
            
            return popup;
        }
        
    }
}

#endif