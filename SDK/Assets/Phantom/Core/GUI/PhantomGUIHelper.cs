#if UNITY_EDITOR

using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIHelper
    {
        
        #region LAYOUT

        /// <summary>
        /// 
        /// </summary>
        public static readonly RectOffset LayoutOffset = new(0, 0, 0, 0);
        
        /// <summary>
        /// 
        /// </summary>
        public const float LayoutMargin = 20f;
        
        /// <summary>
        /// 
        /// </summary>
        public const float LayoutSpace = 10f;

        /// <summary>
        /// 
        /// </summary>
        public const float LayoutHeader = 30f;
        
        /// <summary>
        /// 
        /// </summary>
        public const float LayoutLabel = 80f;

        /// <summary>
        /// 
        /// </summary>
        public const float LayoutProperty = 20f;

        #endregion



        #region FONT

        /// <summary>
        /// 
        /// </summary>
        public const int FontSize = 12;
        
        #endregion



        #region TEXTURE

        public const int TextureSize = 1000;

        #endregion


    }
}

#endif