#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;

namespace PhantomEngine
{
    public class PhantomSetting : ScriptableObject
    {

        #region PROFILE
        
        public List<SettingProfile> profiles;
        public int profileIndex = -1;
        
        public int ProfileCount => profiles?.Count ?? 0;

        public string ProfileLabel(int index)
        {
            if (profiles.Count == 0 || profiles.Count - 1 < index)
                return string.Empty;

            return profiles[index].label;
        }
        
        #endregion
        
    }
}

#endif