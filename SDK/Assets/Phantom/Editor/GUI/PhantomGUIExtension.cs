using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIExtension
    {
        #region LINE
        
        public static Rect LeftLine(Rect rect, float length = 1)
        {
            rect.width = length;
            return rect;
        }
        
        public static Rect RightLine(Rect rect, float length = 1)
        {
            rect.x += rect.width - length;
            rect.width = length;
            return rect;
        }
        
        public static Rect TopLine(Rect rect, float length = 1)
        {
            rect.height = length;
            return rect;
        }
        
        public static Rect BottomLine(Rect rect, float length = 1)
        {
            rect.y += rect.height - length;
            rect.height = length;
            return rect;
        }

        #endregion
    }
}