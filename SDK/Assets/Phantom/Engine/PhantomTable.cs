#if UNITY_EDITOR

using System;

namespace PhantomEngine
{
    [Serializable]
    public class SettingProfile
    {
        public string label;
        public PhantomProfileType type;
        public string version;
        public string url; 
    }
}

#endif