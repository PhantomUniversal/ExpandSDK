using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUIExtension
    {

        #region RECT

        // ==================================================
        // [ Line ]
        // ==================================================
        
        /// <summary>
        /// Left line rect
        /// </summary>
        public static Rect LeftLine(Rect rect, float length = 1)
        {
            rect.width = length;
            return rect;
        }
        
        /// <summary>
        /// Right line rect
        /// </summary>
        public static Rect RightLine(Rect rect, float length = 1)
        {
            rect.x += rect.width - length;
            rect.width = length;
            return rect;
        }
        
        /// <summary>
        /// Top rect
        /// </summary>
        public static Rect TopLine(Rect rect, float length = 1)
        {
            rect.height = length;
            return rect;
        }
        
        /// <summary>
        /// Bottom rect 
        /// </summary>
        public static Rect BottomLine(Rect rect, float length = 1)
        {
            rect.y += rect.height - length;
            rect.height = length;
            return rect;
        }
        
        
        // ==================================================
        // [ Window ]
        // ==================================================
        
        /// <summary>
        /// Window size resolution
        /// </summary>
        public static Rect WindowSize(Vector2 size)
        {
            var position = EditorWindow.GetWindow<SceneView>().position;
            var x = position.x + (position.width - (size.x * 0.5f));
            var y = position.y;
            return new Rect(x, y, size.x, size.y);
        }

        
        // ==================================================
        // [ GUI ]
        // ==================================================
        public static Rect Header(Rect rect)
        {
            return new Rect(rect.x, rect.y, rect.width, PhantomGUIHelper.Header);
        }
        
        public static Rect Label(Rect rect)
        {
            return new Rect(rect.x, rect.y, PhantomGUIHelper.Label, PhantomGUIHelper.Property);
        }

        public static Rect Property(Rect rect)
        {
            return new Rect(rect.x + PhantomGUIHelper.Label, rect.y, rect.width - PhantomGUIHelper.Label, rect.height);
        }
        
        
        #endregion
        
    }
}