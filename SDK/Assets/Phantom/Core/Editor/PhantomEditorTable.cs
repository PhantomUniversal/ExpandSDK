#if UNITY_EDITOR

using System;

namespace PhantomEditor
{
    [Serializable]
    public class PhantomProfileTable
    {
        public string label;
        public PhantomProfileType type;
        public string version;
        public string url; 
    }
}

#endif