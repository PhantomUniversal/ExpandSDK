#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomEditorMenu
    {
        
        #region FUNCTION

        private const float PackageLocation = PhantomGUIHelper.LayoutProperty * 3;
        
        internal static void Package()
        {
            Rect baseRect = GUILayoutUtility.GetLastRect();
            baseRect.x += PhantomGUIHelper.LayoutMargin + PackageLocation;
            baseRect.y += PhantomGUIHelper.LayoutProperty;
            
            GenericMenu menu = new GenericMenu();
            Profile(menu);
            menu.AddSeparator("");
            Setting(menu);
            menu.DropDown(baseRect);
        }

        #endregion



        #region MENU

        // ==================================================
        // [ Profile ]
        // ==================================================
        private const string ProfileMenu = "Profile";
        
        private static void Profile(GenericMenu menu)
        {
            if (PhantomEditor.Setting.GetCount() == 0)
            {
                menu.AddItem(new GUIContent(ProfileMenu), false, () =>
                {
                    Debug.LogError("Profile does not exist. Please create a profile first.");
                    PhantomEditor.SettingSelect();
                });
                return;
            }
            
            for (var i = 0; i < PhantomEditor.Setting.GetCount(); i++)
            {
                int index = i;
                string text = $"[{index}] ";
                text += string.IsNullOrEmpty(PhantomEditor.Setting.GetLabel(index)) ? "Empty profile" : PhantomEditor.Setting.GetLabel(index);
                menu.AddItem(new GUIContent($"{ProfileMenu}/{text}"), PhantomEditor.Setting.GetIndex() == index,
                    () => { PhantomEditor.Setting.SetIndex(index); });  
            }
        }

        
        // ==================================================
        // [ Profile ]
        // ==================================================
        private const string SettingMenu = "Setting";
        
        private static void Setting(GenericMenu menu)
        {
            menu.AddItem(new GUIContent(SettingMenu), false, PhantomEditor.SettingSelect);
        }

        #endregion
        
    }
}

#endif