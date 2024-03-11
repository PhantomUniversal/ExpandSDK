#if UNITY_EDITOR

using System.Reflection;

namespace PhantomEditor
{
    internal static class PhantomEditorHelper
    {

        #region FLÅG

        /// <summary>
        /// Binding flags
        /// </summary>
        internal const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Instance;

        #endregion
        
        
        
        #region HASH

        /// <summary>
        /// SDK Identifier
        /// </summary>
        internal const string Identifier = "com.phantomuniversal.sdk";

        /// <summary>
        /// SDK Root directory
        /// </summary>
        internal const string Directory = "Assets/Phantom";

        /// <summary>
        /// SDK Resource directory
        /// </summary>
        internal const string Resource = Directory + "/" + "Resource";

        /// <summary>
        /// SDK Setting
        /// </summary>
        internal const string Setting = "PhantomSetting";

        /// <summary>
        /// SDK Url
        /// </summary>
        internal const string Url = "https://raw.githubusercontent.com/PhantomUniversal/ExpandSDK/main/Release";
        
        /// <summary>
        /// Assembly resource
        /// </summary>
        internal const string Assembly = "UnityEditor.Toolbar";

        /// <summary>
        /// Field root
        /// </summary>
        internal const string Root = "m_Root";

        /// <summary>
        /// Zone
        /// </summary>
        internal const string Zone = "ToolbarZoneRightAlign";
        
        #endregion
        
    }
}

#endif