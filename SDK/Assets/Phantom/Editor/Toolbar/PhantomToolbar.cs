#if UNITY_EDITOR

using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PhantomEditor
{
    [InitializeOnLoad]
    public static class PhantomToolbar
    {
        static PhantomToolbar()
        {
            EditorApplication.update += OnUpdate;
            EditorApplication.update += OnToolbar;
        }

        
        #region VARIABLE

        private static bool _toolbarEnable;
        private static ScriptableObject _toolbar;

        #endregion
        
        
        
        #region LIFECYCLE

        private static void OnUpdate()
        {
            
        }
        
        private static void OnToolbar()
        {
            if (_toolbar is not null) 
                return;
            
            var toolbars =  Resources.FindObjectsOfTypeAll(typeof(Editor).Assembly.GetType(PhantomToolbarHelper.Assembly));
            _toolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;

            if (_toolbar is null)
                return;
                
            FieldInfo root = _toolbar.GetType().GetField(PhantomToolbarHelper.Root, BindingFlags.NonPublic | BindingFlags.Instance);
            if(root is null)
                return;
            
            VisualElement toolbarVisual = root.GetValue(_toolbar) as VisualElement;
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
            container.onGUIHandler += OnGUI;
            
            toolbarStyle.Add(container);
            toolbarZone.Add(toolbarStyle);


        }

        private static void OnGUI()
        {
            Rect baseRect = EditorGUILayout.BeginHorizontal();
            baseRect.x = PhantomGUIHelper.Margin;

            if (_toolbarEnable)
            {
                baseRect.width = PhantomGUIHelper.Content * 4;
                baseRect.height = PhantomGUIHelper.Content;

                // Import
                if (GUI.Button(baseRect, PhantomGUIResource.EditorIcon("import.png"), PhantomGUIStyle.BoldButton))
                {
                    Import();
                }
            }
            else
            {
                baseRect.width = PhantomGUIHelper.Content * 3;
                baseRect.height = PhantomGUIHelper.Content;

                // Build
                if (GUI.Button(baseRect, PhantomGUIResource.EditorIcon("publish.png"), PhantomGUIStyle.BoldButton))
                {
                    Publish();
                }

                baseRect.x += baseRect.width;
                baseRect.width = PhantomGUIHelper.Content;
                baseRect.height = PhantomGUIHelper.Content;
                
                // Etc(UI => Dropdown)
                if (GUI.Button(baseRect, PhantomGUIResource.EditorIcon("etc.png"), PhantomGUIStyle.BoldButton))
                {
                    Etc();
                }
            }
            
            EditorGUILayout.EndHorizontal();
        }
        
        #endregion



        #region FUNCTION

        private static void Import()
        {
            
        }
        
        private static void Publish()
        {

        }

        private static void Etc()
        {
            
        }
        
        #endregion
        
    }
}

#endif