using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIFunction
    {
        public static void Tool<T>() where T : PhantomGUITool
        {
            var window = EditorWindow.GetWindow<T>();
            window.titleContent = new GUIContent(PhantomEditorConfig.PackageTag + " " + window.DrawName);
            
            var position = new Vector2((Screen.currentResolution.width - window.DrawSize.x) * 0.5f, 83f);
            window.position = new Rect(position, window.DrawSize);
            window.minSize = window.DrawSize;
            window.maxSize = window.DrawSize;
            window.ShowUtility();
            window.Focus(); 
        }
    }
}