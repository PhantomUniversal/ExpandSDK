using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomTool
    {
        public static void Window<T>(string toolTitle, Vector2 toolSize, PhantomEditorLocation toolLocation = PhantomEditorLocation.General) where T : EditorWindow
        {
            var window = EditorWindow.GetWindow<T>();
            window.titleContent = new GUIContent(toolTitle);
            window.position = ConfigurePlacement(toolSize, toolLocation);
            window.minSize = toolSize;
            window.maxSize = toolSize;
            window.ShowUtility();
            window.Focus();
        }
        
        private static Rect ConfigurePlacement(Vector2 size, PhantomEditorLocation location)
        {
            var screenLocation = GetScreenLocation(size, location);
            return new Rect(screenLocation, size);
        }

        private static Vector2 GetScreenLocation(Vector2 size, PhantomEditorLocation location)
        {
            return location switch
            {
                PhantomEditorLocation.General => PhantomToolHelper.Offset,
                PhantomEditorLocation.Center => new Vector2((Screen.currentResolution.width * 0.5f) - (size.x * 0.5f), PhantomToolHelper.Offset.y),
                _ => Vector2.zero
            };
        }
    }
}