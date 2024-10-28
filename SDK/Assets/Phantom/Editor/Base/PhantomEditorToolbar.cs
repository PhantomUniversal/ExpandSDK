using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PhantomEditor
{
    [InitializeOnLoad]
    public sealed class PhantomEditorToolbar
    {
        private const BindingFlags InstanceNonPublic = BindingFlags.Instance | BindingFlags.NonPublic;
        private const string AssemblyType = "UnityEditor.Toolbar";
        private const string RootFieldName = "m_Root";
        private const string RightAlignClass = "ToolbarZoneRightAlign";
        
        private static ScriptableObject _toolbar;
        
        static PhantomEditorToolbar()
        {
            EditorApplication.update += OnUpdate;
        }
        
        private static void OnUpdate()
        {
            if (_toolbar is not null)
            {
                EditorApplication.update -= OnUpdate;
                return;
            }

            var toolbarType = typeof(Editor).Assembly.GetType(AssemblyType);
            var toolbars = Resources.FindObjectsOfTypeAll(toolbarType);
            if (toolbars.Length == 0)
                return;

            _toolbar = (ScriptableObject)toolbars[0];
            
            var toolbarRoot = _toolbar.GetType().GetField(RootFieldName, InstanceNonPublic);
            if(toolbarRoot is null)
                return;
            
            var toolbarVisual = toolbarRoot.GetValue(_toolbar) as VisualElement;
            if (toolbarVisual is null)
                return;
            
            var toolbarZone = toolbarVisual.Q(RightAlignClass);
            if(toolbarZone is null)
                return;
            
            var toolbarStyle = new VisualElement
            {
                style =
                {
                    flexGrow = 1,
                    flexDirection = FlexDirection.Row,
                }
            };

            var toolbarContainer = new IMGUIContainer
            {
                style = { top = -2 }
            };
            
            toolbarContainer.onGUIHandler += OnDrawer;
            toolbarStyle.Add(toolbarContainer);
            toolbarZone.Add(toolbarStyle);
            
            EditorApplication.update -= OnUpdate;
        }
        
        private static void OnDrawer()
        { 
            // PhantomGUI.BeginHorizontalLayout();
            // PhantomGUI.Space();
            //
            // var drawToolbarRect = PhantomGUILayout.ControlRect();
            //
            // drawToolbarRect.x = 20;
            // drawToolbarRect.width = 80f;
            // if (PhantomGUI.CustomButton(drawToolbarRect,  PhantomGUIResource.IconTexture("download.png")))
            // {
            //     
            // }
            //
            // drawToolbarRect.x += 80f;
            // drawToolbarRect.width = 20f;
            // if (PhantomGUI.CustomButton(drawToolbarRect, PhantomGUIResource.IconTexture("etc.png")))
            // {
            //     
            // }
            //
            // PhantomGUI.EndHorizontalLayout();
        }
    }
}