#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUI
    {
        
        // ==================================================
        // [ Draw ]
        // ==================================================
        public static void DrawBorderRect(Rect rect, Color color)
        {
            if (Event.current.type != EventType.Repaint)
                return;
            
            EditorGUI.DrawRect(PhantomGUIExtension.LeftLine(rect), color);
            EditorGUI.DrawRect(PhantomGUIExtension.RightLine(rect), color);
            EditorGUI.DrawRect(PhantomGUIExtension.TopLine(rect), color);
            EditorGUI.DrawRect(PhantomGUIExtension.BottomLine(rect), color);
        }

        public static void DrawSolidRect(Rect rect, Color color)
        {
            if (Event.current.type != EventType.Repaint)
                return;
            
            EditorGUI.DrawRect(rect, color);
        }
        
        
        // ==================================================
        // [ Layout ]
        // ==================================================
        public static Rect BeginGroupLayout(GUIStyle style = null, params GUILayoutOption[] options)
        {
            style ??= GUIStyle.none;
            return EditorGUILayout.BeginVertical(style, options);
        }

        public static void EndGroupLayout()
        {
            EditorGUILayout.EndVertical();
        }

        
        public static Rect BeginIndentLayout(GUIStyle style = null, params GUILayoutOption[] options)
        {
            EditorGUI.indentLevel++;
            style ??= GUIStyle.none;
            return EditorGUILayout.BeginVertical(style, options);
        }

        public static void EndIndentLayout()
        {
            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel--;
        }
        
        
        // ==================================================
        // [ Background ]
        // ==================================================
        public static void CustomBox(Rect rect)
        {
            GUI.Box(rect, "", GUI.skin.box);
        }

        private static void CustomHelpBox(Rect rect)
        {
            rect.x -= 2;
            rect.width += 4;
            
            GUI.Box(rect, "", EditorStyles.helpBox);
        }
        
        
        // ==================================================
        // [ Foldout ]
        // ==================================================
        public static bool Foldout(bool enable, string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            return InternalFoldout(controlRect, enable, text, PhantomGUIStyle.Foldout);
        }
        
        public static bool FoldoutHeader(bool enable, string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutHeader);
            return InternalFoldout(controlRect, enable, text, PhantomGUIStyle.FoldoutHeader);
        }

        public static bool CustomFoldout(Rect rect, bool enable, string text, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.Foldout;
            return InternalFoldout(rect, enable, text, style, false);
        }
        
        private static bool InternalFoldout(Rect rect, bool enable, string text, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.UpdateRepaint(rect.height);    
            }
         
            CustomHelpBox(rect);
            
            EditorGUI.indentLevel++;
            enable = EditorGUI.Foldout(rect, enable, text, true, style);
            EditorGUI.indentLevel--;
            return enable;
        }
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        public static void Label(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            InternalLabel(controlRect, text, PhantomGUIStyle.LeftBoldLabel);
        }

        public static void CustomLabel(Rect rect, string text, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.LeftBoldLabel;
            InternalLabel(rect, text, style, false);
        }

        private static void InternalLabel(Rect rect, string text, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.UpdateRepaint(rect.height);    
            }
            
            GUI.Label(rect, text, style);
        }
        
        
        // ==================================================
        // [ Text ]
        // ==================================================
        public static string Text(string text)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            return InternalText(controlRect, text, PhantomGUIStyle.LeftText);
        }

        public static string CustomText(Rect rect, string text, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.LeftText;
            return InternalText(rect, text, style, false);
        }

        private static string InternalText(Rect rect, string text, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.UpdateRepaint(rect.height);    
            }
            
            return GUI.TextField(rect, text, style);
        }
        
        
        // ==================================================
        // [ Popup ]
        // ==================================================
        public static int Popup(int select, string[] displayOptions)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            return InternalPopup(controlRect, select, displayOptions, PhantomGUIStyle.Popup);
        }
        
        public static int CustomPopup(Rect rect, int select, string[] displayOptions, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.Popup;
            return InternalPopup(rect, select, displayOptions, style, false);
        }

        private static int InternalPopup(Rect rect, int select, string[] displayOptions, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.UpdateRepaint(rect.height);    
            }
            
            return EditorGUI.Popup(rect, select, displayOptions, style);
        }
        
        
        // ==================================================
        // [ EnumPopup ]
        // ==================================================
        public static Enum EnumPopup(Enum popup)
        {
            Rect controlRect = EditorGUILayout.GetControlRect(false, PhantomGUIHelper.LayoutProperty);
            return InternalEnumPopup(controlRect, popup, PhantomGUIStyle.Popup);
        }

        public static Enum CustomEnumPopup(Rect rect, Enum popup, GUIStyle style = null)
        {
            style ??= PhantomGUIStyle.Popup;
            return InternalEnumPopup(rect, popup, style, false);
        }
        
        private static Enum InternalEnumPopup(Rect rect, Enum popup, GUIStyle style, bool repaint = true)
        {
            if (repaint)
            {
                PhantomGUIUtility.UpdateRepaint(rect.height);   
            }
            
            return EditorGUI.EnumPopup(rect, popup, style);
        }
        
    }
}

#endif