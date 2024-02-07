#if UNITY_EDITOR

using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PhantomEditor
{
    [InitializeOnLoad]
    public class PhantomToolbar : Editor
    {
        
        static PhantomToolbar()
        {
            EditorApplication.update += Update;
        }


        #region TOOLBAR

        private static ScriptableObject toolbar;
        
        private static void Update()
        {
            if (toolbar is null)
            {
                var toolbars =  Resources.FindObjectsOfTypeAll(typeof(Editor).Assembly.GetType(PhantomToolbarHelper.Assembly));
                toolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;
                return;
            }
            
            FieldInfo root = toolbar.GetType().GetField(PhantomToolbarHelper.Root, BindingFlags.NonPublic | BindingFlags.Instance);
            if(root is null)
                return;
            
            VisualElement toolbarVisual = root.GetValue(toolbar) as VisualElement;
            VisualElement toolbarZone = toolbarVisual.Q("ToolbarZoneRightAlign");
            VisualElement toolbarStyle = new VisualElement()
            {
                style =
                {
                    flexGrow = 1,
                    flexDirection = FlexDirection.Row,
                }
            };
            
            IMGUIContainer container = new IMGUIContainer();
            toolbarStyle.Add(container);
            toolbarZone.Add(toolbarStyle);
            
            container.onGUIHandler += GUI;
        }

        private static void GUI()
        {
            
        }
        
        #endregion
        
        
    }
}

#endif