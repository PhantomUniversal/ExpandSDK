using System;

namespace PhantomEditor
{
    [Serializable]
    public class VersionData
    {
        public string Major;
        public string Minor;
        public string Patch;
        public string Build;
        
        public string Version => $"{Major}.{Minor}.{Patch}.{Build}";


        public VersionData()
        {
            Major = "1";
            Minor = "0";
            Patch = "0";
            Build = "";
        }
        
        public VersionData(string major, string minor, string patch, string build)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Build = build;
        }
        
        
        public override string ToString()
        {
            return Version;
        }
    }
}