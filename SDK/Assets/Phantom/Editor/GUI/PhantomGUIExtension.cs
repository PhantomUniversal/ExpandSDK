using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIExtension
    {
        #region RECT
        
        public static (Rect Header, Rect Content, Rect Footer) WindowRect(Vector2 windowSize, float headerHeight, float footerHeight)
        {
            var headerRect = new Rect(0, 0, windowSize.x, headerHeight);
            var contentRect = new Rect(0, headerHeight, windowSize.x, windowSize.y - headerHeight - footerHeight);
            var footerRect = new Rect(0, windowSize.y - footerHeight, windowSize.x, footerHeight);
            return (Header: headerRect, Content: contentRect, Footer: footerRect);
        }

        public static Rect HeaderRect(Vector2 windowSize, float headerHeight)
        {
            var headerRect = new Rect(0, 0, windowSize.x, headerHeight);
            return headerRect;
        }

        public static Rect FooterRect(Vector2 windowSize, float footerHeight)
        {
            var footerRect = new Rect(0, windowSize.y - footerHeight, windowSize.x, footerHeight);
            return footerRect;
        }
        
        public static Rect MarginRect(Rect position, float margin)
        {
            return new Rect(position.x + margin, position.y + margin, 
                position.width - margin * 2, position.height - margin * 2);
        }
        
        public static Rect LabelRect(Rect position)
        {
            position.width = EditorGUIUtility.labelWidth;
            return position;
        }
        
        public static Rect PropertyRect(Rect position, bool label)
        {
            if (!label)
                return position;

            position.x += EditorGUIUtility.labelWidth;
            position.width -= EditorGUIUtility.labelWidth;
            return position;
        }
        
        #endregion
        
        #region LINE
        
        public static Rect LeftLine(Rect rect, float length)
        {
            rect.width = length;
            return rect;
        }
        
        public static Rect RightLine(Rect rect, float length)
        {
            rect.x += rect.width - length;
            rect.width = length;
            return rect;
        }
        
        public static Rect TopLine(Rect rect, float length)
        {
            rect.height = length;
            return rect;
        }
        
        public static Rect BottomLine(Rect rect, float length)
        {
            rect.y += rect.height - length;
            rect.height = length;
            return rect;
        }

        #endregion
    }
}