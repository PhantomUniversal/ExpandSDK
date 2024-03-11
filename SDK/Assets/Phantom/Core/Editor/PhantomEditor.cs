#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEditor
{
    [InitializeOnLoad]
    public static class PhantomEditor
    {
        static PhantomEditor()
        {
            SettingBind();
        }


        #region SETTING

        private static PhantomEditorSetting setting;

        internal static bool IsSetting => setting is not null;
        
        internal static PhantomEditorSetting Setting
        {
            get
            {
                setting ??= PhantomEditorSo.BindSo<PhantomEditorSetting>();
                return setting;
            }
        }
        
        internal static void SettingBind()
        {
            setting ??= PhantomEditorSo.BindSo<PhantomEditorSetting>();
        }

        internal static void SettingSelect()
        {
            if (!IsSetting)
                return;
            
            Selection.activeObject = setting;
        }
        
        #endregion
        
    }
}

#endif