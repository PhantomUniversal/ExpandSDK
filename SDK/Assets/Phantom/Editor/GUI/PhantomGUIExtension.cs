using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIExtension
    {

        #region RECT

        /// <summary>
        /// Left rect
        /// </summary>
        public static Rect Left(Rect rect, float length = 1)
        {
            rect.width = length;
            return rect;
        }
        
        /// <summary>
        /// Right rect
        /// </summary>
        public static Rect Right(Rect rect, float length = 1)
        {
            rect.x += rect.width - length;
            rect.width = length;
            return rect;
        }
        
        /// <summary>
        /// Top rect
        /// </summary>
        public static Rect Top(Rect rect, float length = 1)
        {
            rect.height = length;
            return rect;
        }
        
        /// <summary>
        /// Bottom rect 
        /// </summary>
        public static Rect Bottom(Rect rect, float length = 1)
        {
            rect.y += rect.height - length;
            rect.height = length;
            return rect;
        }
        
        /// <summary>
        /// Window size resolution
        /// </summary>
        public static Rect Window(Vector2 size)
        {
            var position = EditorWindow.GetWindow<SceneView>().position;
            var x = position.x + (position.width - (size.x * 0.5f));
            var y = position.y;
            return new Rect(x, y, size.x, size.y);
        }

        #endregion
        
    }
}