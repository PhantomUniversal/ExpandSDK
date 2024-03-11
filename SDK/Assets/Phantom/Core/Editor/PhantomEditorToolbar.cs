#if UNITY_EDITOR

using System.Reflection;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace PhantomEditor
{
    [InitializeOnLoad]
    public static class PhantomEditorToolbar
    {
        static PhantomEditorToolbar()
        {
            EditorApplication.update += OnUpdate;
            EditorApplication.update += OnToolbar;
        }
        
        #region VARIABLE

        private static bool toolbarSetup;
        private static ScriptableObject toolbar;

        #endregion
        
        
        
        #region LIFECYCLE

        private static void OnUpdate()
        {
            // Addressable setup check
            if (!AddressableAssetSettingsDefaultObject.SettingsExists)
            {                                                                                                                                                  
                toolbarSetup = true;
                return;
            }

            // Setting setup check
            if (!PhantomEditor.IsSetting)
            {
                toolbarSetup = true;
                return;
            }

            toolbarSetup = false;
        }
        
        private static void OnToolbar()
        {
            if (toolbar is not null) 
                return;
            
            var toolbars =  Resources.FindObjectsOfTypeAll(typeof(Editor).Assembly.GetType(PhantomEditorHelper.Assembly));
            toolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;

            if (toolbar is null)
                return;
                
            FieldInfo root = toolbar.GetType().GetField(PhantomEditorHelper.Root, PhantomEditorHelper.Flags);
            if(root is null)
                return;
            
            VisualElement toolbarVisual = root.GetValue(toolbar) as VisualElement;
            VisualElement toolbarZone = toolbarVisual.Q(PhantomEditorHelper.Zone);
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
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(PhantomGUIHelper.LayoutMargin);
            
            if (toolbarSetup)
            {
                if (GUILayout.Button(PhantomGUIResource.EditorIcon(ImportIcon), PhantomGUIStyle.BoldButton, PhantomEditorOption.Import))
                {
                    Import();
                }
            }
            else
            {
                if (GUILayout.Button(PhantomGUIResource.EditorIcon(PublishIcon), PhantomGUIStyle.BoldButton, PhantomEditorOption.Publish))
                {
                    Publish();
                }

                if (GUILayout.Button(PhantomGUIResource.EditorIcon(EtcIcon), PhantomGUIStyle.BoldButton, PhantomEditorOption.Etc))
                {
                    Etc();
                }
            }
            
            EditorGUILayout.EndHorizontal();
        }
        
        #endregion



        #region FUNCTION

        // ==================================================
        // [ Import ]
        // ==================================================
        private const string ImportIcon = "import.png";
        
        private static void Import()
        {
            if (!AddressableAssetSettingsDefaultObject.SettingsExists) // Addressable setting default object is null check
            {
                AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder,
                    AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);

                UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
            }
            
            if (!PhantomEditor.IsSetting)
            {
                PhantomEditor.SettingBind();
            }
        }
        
        
        // ==================================================
        // [ Publish ]
        // ==================================================
        private const string PublishIcon = "publish.png";
        
        private static void Publish()
        {
            // Build + Addressable
        }

        
        // ==================================================
        // [ Etc ]
        // ==================================================
        private const string EtcIcon = "etc.png";
        
        private static void Etc()
        {
            PhantomEditorMenu.Package();
        }

        
        #endregion
        
    }
}

#endif