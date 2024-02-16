#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;

namespace PhantomEngine
{
    [InitializeOnLoad]
    public static class PhantomEditor
    {

        static PhantomEditor()
        {
            BindSetting();
        }


        #region SETTING

        internal static PhantomSetting PhantomSetting;

        internal static bool IsPhantomSetting => PhantomSetting;
        
        internal static void BindSetting()
        {
            PhantomSetting ??= PhantomUtility.BindSo<PhantomSetting>();
            PhantomSetting.profiles ??= new List<SettingProfile>
            {
                new ()
                {
                    label = "Default profile",
                    type = PhantomProfileType.Local,
                    url = ""
                }
            };
        }

        internal static void SelectSetting()
        {
            if (!IsPhantomSetting)
                return;
            
            Selection.activeObject = PhantomSetting;
        }
        
        #endregion
        
    }
}

#endif