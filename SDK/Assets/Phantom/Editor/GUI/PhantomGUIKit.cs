using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIKit
    {
        public static void Tool<T>() where T : PhantomGUITool
        {
            var window = EditorWindow.GetWindow<T>();
            window.titleContent = new GUIContent(PhantomGUIConfig.Tag + " " + window.DrawName);
            window.position = PhantomGUIHelper.ConfigurePlacement(window.DrawSize, window.DrawLocation);
            window.minSize = window.DrawSize;
            window.maxSize = window.DrawSize;
            window.ShowUtility();
            window.Focus();
        }
    }
}