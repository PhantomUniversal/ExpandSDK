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
            EditorGUI.DrawRect(PhantomGUIExtension.Left(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.Right(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.Top(rect), Color.white);
            EditorGUI.DrawRect(PhantomGUIExtension.Bottom(rect), Color.white);
        }
        
        
        // ==================================================
        // [ Layout ]
        // ==================================================
        public static Rect BeginGroupLayout(params GUILayoutOption[] options) => BeginGroupLayout(false, options);
        
        public static Rect BeginGroupLayout(bool background = false, params GUILayoutOption[] options)
        {
            return background ? EditorGUILayout.BeginVertical(GUI.skin.box, options) : EditorGUILayout.BeginVertical(GUIStyle.none, options);
        }

        public static void EndGroupLayout()
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
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        public static void Label(string content)
        {
            Rect baseRect = EditorGUILayout.GetControlRect(false);
            GUI.Label(baseRect, content, PhantomGUIStyle.LeftBoldLabel);
        }
        
        
        // ==================================================
        // [ Popup ]
        // ==================================================
        public static Enum EnumPopup(Enum popup, string text) => EnumPopup(popup, new GUIContent(text));
        
        public static Enum EnumPopup(Enum popup, GUIContent content)
        {
            Rect baseRect = EditorGUILayout.GetControlRect(false);
            baseRect.x += content is null ? baseRect.x : PhantomGUIHelper.Label;
            baseRect.width = content is null ? baseRect.width : baseRect.width - PhantomGUIHelper.Label;
            baseRect.height = PhantomGUIHelper.Content;
            
            popup = EditorGUI.EnumPopup(baseRect, popup, PhantomGUIStyle.Popup);
            if (content is not null)
            {
                baseRect.x -= PhantomGUIHelper.Label;
                baseRect.width = PhantomGUIHelper.Label;
                baseRect.height = PhantomGUIHelper.Content;
                GUI.Label(baseRect, content, PhantomGUIStyle.LeftBoldLabel);
            }
            
            return popup;
        }
        
    }
}

#endif