using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public sealed class PhantomGUIResource
    {
        public static Texture2D IconTexture(string iconName)
        {
            return EditorGUIUtility.FindTexture(PhantomEditorPath.ResourcePath(iconName, PhantomEditorResourceType.Icon));
        }
        
        public static Texture2D ColorTexture(int width, int height, Color color)
        {
            var pixelCount = width * height;
            var pixels = new Color[pixelCount];
            for (var i = 0; i < pixelCount; i++)
            {
                pixels[i] = color;
            }
            
            var textures = new Texture2D(width, height);
            textures.SetPixels(pixels);
            textures.wrapMode = TextureWrapMode.Clamp;
            textures.filterMode = FilterMode.Point;
            
            textures.Apply();
            return textures;
        }
    }
}