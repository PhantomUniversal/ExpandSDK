using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIUtility
    {
        public static void Tool<T>() where T : PhantomGUIWindow
        {
            var window = EditorWindow.GetWindow<T>();
            window.titleContent = new GUIContent(PhantomEditorConfig.PackageTag + " " + window.DrawName);
            window.position = PhantomGUIHelper.ConfigurePlacement(window.DrawSize, window.DrawLocation);
            window.minSize = window.DrawSize;
            window.maxSize = window.DrawSize;
            window.ShowUtility();
            window.Focus();
        }
    }
}