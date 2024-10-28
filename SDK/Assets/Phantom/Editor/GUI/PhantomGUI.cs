using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUI
    {
        #region LAYOUT

        public static Rect BeginVertical(params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginVertical(options);
        }
        public static void EndVertical()
        {
            EditorGUILayout.EndVertical();
        }
        
        public static Rect BeginHorizontal(params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginHorizontal(options);
        }
        public static void EndHorizontal()
        {
            EditorGUILayout.EndHorizontal();
        }

        #endregion
        
        #region GROUP

        public static Rect BeginGroup(string label, bool centerLabel = false, params GUILayoutOption[] options)
        {
            return string.IsNullOrEmpty(label) ? BeginGroup(options) : BeginGroup(new GUIContent(label), centerLabel, options);
        }
        
        public static Rect BeginGroup(GUIContent label, bool centerLabel = false, params GUILayoutOption[] options)
        {
            Rect rect = BeginGroup(options);
            if (label != null)
            {
                BeginHeader();
                float fieldWidth = EditorGUIUtility.fieldWidth;
                EditorGUIUtility.fieldWidth = 10f;
                var position = EditorGUILayout.GetControlRect(false);
                EditorGUIUtility.fieldWidth = fieldWidth;
                GUI.Label(position, label, centerLabel ? PhantomGUIStyle.BoldLabelCentered : PhantomGUIStyle.BoldLabel);
                EndHeader();
            }
            return rect;
        }

        public static Rect BeginGroup(params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginVertical(PhantomGUIStyle.Group, options);
        }
        
        public static void EndGroup()
        {
            EditorGUILayout.EndVertical();
        }
        
        #endregion

        #region HEADER

        public static Rect BeginHeader()
        {
            EditorGUILayout.Space(-3f);
            Rect rect = EditorGUILayout.BeginHorizontal(PhantomGUIStyle.GroupHeader, GUILayout.ExpandWidth(true));
            if (Event.current.type == EventType.Repaint)
            {
                rect.x -= 3f;
                rect.width += 6f;
                PhantomGUIHelper.PushColor(PhantomGUIColor.HeaderColor);
                GUI.DrawTexture(rect, Texture2D.whiteTexture);
                PhantomGUIHelper.PopColor();
                DrawBorderLine(rect, 0, 0, 0, 1, new Color(0.0f, 0.0f, 0.0f, 0.4f));
            }
            return rect;
        }

        public static void EndHeader()
        {
            EditorGUILayout.EndHorizontal();
        }

        #endregion
        
        #region DRAW
        
        public static void DrawBorderLine(Rect rect, int length, Color color)
        {
            DrawBorderLine(rect, length, length, length, length, color);
        }

        public static void DrawBorderLine(Rect rect, int left, int right, int top, int bottom, Color color)
        {
            if (Event.current.type != EventType.Repaint)
                return;

            if (left > 0)
            {
                DrawSolidRect(PhantomGUIExtension.LeftLine(rect, left), color);
            }
            if (right > 0)
            {
                DrawSolidRect(PhantomGUIExtension.RightLine(rect, right), color);
            }
            if (top > 0)
            {
                DrawSolidRect(PhantomGUIExtension.TopLine(rect, top), color);
            }
            if (bottom > 0)
            {
                DrawSolidRect(PhantomGUIExtension.BottomLine(rect, bottom), color);
            }
        }
        
        public static void DrawDividerLine(float location, float length = 1f)
        {
            var position = EditorGUILayout.GetControlRect(false, length);
            position.y = location;
            DrawSolidRect(position, PhantomGUIColor.LineColor);
        }
        
        public static void DrawSeparatorLine(float length = 1f)
        {
            var position = EditorGUILayout.GetControlRect(false, length);
            DrawSolidRect(position, PhantomGUIColor.LineColor);
        }
        
        public static void DrawSolidRect(Rect rect, Color color)
        {
            if(Event.current.type != EventType.Repaint)
                return;
            
            EditorGUI.DrawRect(rect, color);
        }
        
        #endregion
        
        #region SCROLL
        
        public static Vector2 BeginScroll(ScrollType scrollType, Vector2 scrollPosition, bool scrollbarUse = false, bool scrollbarAlwaysShow = true)
        {
            var horizontalStyle = scrollbarUse && scrollType == ScrollType.Horizontal ? GUI.skin.horizontalScrollbar : GUIStyle.none;
            var verticalStyle = scrollbarUse && scrollType == ScrollType.Vertical ? GUI.skin.verticalScrollbar : GUIStyle.none;
            var backgroundStyle = GUI.skin.scrollView;
            
            return EditorGUILayout.BeginScrollView(scrollPosition, scrollbarAlwaysShow, scrollbarAlwaysShow, horizontalStyle, verticalStyle, backgroundStyle);
        }
        
        public static void EndScroll()
        {
            EditorGUILayout.EndScrollView();
        }
        
        #endregion
        
        #region SPACE

        public static void Space(float value = 6f, bool expand = true)
        {
            GUILayoutUtility.GetRect(value, value, GUILayout.ExpandWidth(expand));   
        }

        #endregion

        #region PREFIX

        public static void Prefix(float prefix)
        {
            EditorGUIUtility.labelWidth = prefix;
        }

        #endregion
    }   
}