#if UNITY_EDITOR

using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUIResource
    {

        #region PATH
        
        /// <summary>
        /// Common resource path
        /// </summary>
        /// <param name="type">Resource type</param>
        /// <param name="file">Resource name</param>
        /// <param name="package">Method call path</param>
        /// <returns></returns>
        public static string BindPath(PhantomGUIResourceType type, string file, [CallerFilePath] string package = null)
        {
            if (type == PhantomGUIResourceType.None || string.IsNullOrEmpty(file))
                return string.Empty;

            return package is null ? string.Empty : CombinePath(package, $"{type.ToString()}/{file}");
        }

        private static string CombinePath(string packagePath, string resourcePath)
        {
            return packagePath.Contains(PhantomHelper.Identifier) 
                ? $"Package/{PhantomHelper.Identifier}/Resource/{resourcePath}" : $"{PhantomHelper.Resource}/{resourcePath}";
        }

        #endregion
        
        
        
        #region TEXTURE

        private const int TextureSize = 1000;
        
        public static Texture2D ColorTexture(Color color) => ColorTexture(TextureSize, TextureSize, color);
        
        /// <summary>
        /// Get rgba color texture
        /// </summary>
        /// <param name="width">Texture width</param>
        /// <param name="height">Texture height</param>
        /// <param name="color">RGBA</param>
        /// <returns></returns>
        public static Texture2D ColorTexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];

            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }
            
            Texture2D colorTexture = new Texture2D(width, height);

            colorTexture.SetPixels(pixels);
            colorTexture.Apply();

            return colorTexture;
        }

        #endregion



        #region ICON
        
        /// <summary>
        /// Get icon texture
        /// </summary>
        /// <param name="icon">Icon full name (contain extension)</param>
        /// <returns></returns>
        public static Texture2D EditorIcon(string icon)
        {
            return EditorGUIUtility.FindTexture(BindPath(PhantomGUIResourceType.Icon, icon));
        }
        
        #endregion
        
    }
}

#endif