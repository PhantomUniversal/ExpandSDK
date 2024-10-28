using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIColor
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly Color BackgroundColor = EditorGUIUtility.isProSkin ? new Color(0.165f, 0.165f, 0.165f, 1.0f) : new Color(0.835f, 0.835f, 0.835f, 1f);
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Color LineColor = EditorGUIUtility.isProSkin ? new Color(0.6f, 0.6f, 0.6f, 1f) : new Color(0.4f, 0.4f, 0.4f, 1.0f);
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Color SelectedColor = new(0.361f, 0.224f, 1f, 1f);
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Color HeaderColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.06f) : new Color(1f, 1f, 1f, 0.26f);
    }
}