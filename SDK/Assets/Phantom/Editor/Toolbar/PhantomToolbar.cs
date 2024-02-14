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
    public static class PhantomToolbar
    {
        static PhantomToolbar()
        {
            EditorApplication.update += OnUpdate;
            EditorApplication.update += OnToolbar;
        }


        #region CONST

        private const string ImportIcon = "import.png";

        private const string PublishIcon = "publish.png";

        private const string EtcIcon = "etc.png";
        
        #endregion



        #region READONLY
        
        private const float ImportLength = PhantomGUIHelper.Content * 4;
        
        private static readonly GUILayoutOption[] ImportOption 
            = { GUILayout.Width(ImportLength), GUILayout.Height(PhantomGUIHelper.Content) };
        
        
        private const float PublishLength = PhantomGUIHelper.Content * 3;
        
        private static readonly GUILayoutOption[] PublishOption 
            = { GUILayout.Width(PublishLength), GUILayout.Height(PhantomGUIHelper.Content) };
        
        
        private const float EtcLength = PhantomGUIHelper.Content;
        
        private static readonly GUILayoutOption[] EtcOption 
            = { GUILayout.Width(EtcLength), GUILayout.Height(PhantomGUIHelper.Content) };

        #endregion

        
        
        #region VARIABLE

        private static bool _toolbarEnable;
        private static ScriptableObject _toolbar;

        #endregion
        
        
        
        #region LIFECYCLE

        private static void OnUpdate()
        {
            if (!AddressableAssetSettingsDefaultObject.Settings)
            {
                _toolbarEnable = false;
                return;
            }

            if (!PhantomEditor.IsPhantomSetting)
            {
                _toolbarEnable = false;
                return;
            }

            _toolbarEnable = true;
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
            VisualElement toolbarZone = toolbarVisual.Q(PhantomToolbarHelper.Zone);
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
            EditorGUILayout.Space(PhantomGUIHelper.Margin);
            
            if (!_toolbarEnable)
            {
                // Import
                if (GUILayout.Button(PhantomGUIResource.EditorIcon(ImportIcon), PhantomGUIStyle.BoldButton, ImportOption))
                {
                    Import();
                }
            }
            else
            {
                if (GUILayout.Button(PhantomGUIResource.EditorIcon(PublishIcon), PhantomGUIStyle.BoldButton, PublishOption))
                {
                    Publish();
                }

                if (GUILayout.Button(PhantomGUIResource.EditorIcon(EtcIcon), PhantomGUIStyle.BoldButton, EtcOption))
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
            if (!AddressableAssetSettingsDefaultObject.SettingsExists)
            {
                AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder,
                    AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);

                UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
            }
            
            PhantomEditor.BindSetting();
        }
        
        private static void Publish()
        {
            
        }

        private static void Etc()
        {
            Rect lastRect = GUILayoutUtility.GetLastRect();
            lastRect.x += PhantomGUIHelper.Margin + PublishLength;
            lastRect.y += PhantomGUIHelper.Margin;
            
            GenericMenu menu = new GenericMenu();
            ProfileMenu(menu);
            menu.AddSeparator("");
            SettingMenu(menu);
            menu.DropDown(lastRect);
        }

        
        #endregion



        #region MENU

        private static void ProfileMenu(GenericMenu menu)
        {
            if (PhantomEditor.PhantomSetting.ProfileCount == 0)
            {
                menu.AddItem(new GUIContent("Profile"), false, () =>
                {
                    Debug.LogError("Profile does not exist. Please create a profile first.");
                    PhantomEditor.SelectSetting();
                });
                return;
            }
            
            for (var i = 0; i < PhantomEditor.PhantomSetting.ProfileCount; i++)
            {
                int index = i;
                string text = $"[{index}] ";
                text += string.IsNullOrEmpty(PhantomEditor.PhantomSetting.ProfileLabel(index)) ? "Empty profile" : PhantomEditor.PhantomSetting.ProfileLabel(index);
                menu.AddItem(new GUIContent($"Profile/{text}"), PhantomEditor.PhantomSetting.profileIndex == index,
                    () => { PhantomEditor.PhantomSetting.profileIndex = index; });  // Todo Index => Setting index 지정 
            }
        }

        private static void SettingMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Setting"), false, PhantomEditor.SelectSetting);
        }

        #endregion
        
    }
}

#endif