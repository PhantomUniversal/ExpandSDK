#if UNITY_EDITOR

namespace PhantomEditor
{
    public static class PhantomHelper
    {

        /// <summary>
        /// Identifier 
        /// </summary>
        public const string Identifier = "com.phantomuniversal.sdk";

        /// <summary>
        /// Root path
        /// </summary>
        public const string Root = "Assets/Phantom";

        /// <summary>
        /// Resource path
        /// </summary>
        public const string Resource = Root + "/" + "Resource";

        /// <summary>
        /// 
        /// </summary>
        public const string Setting = "PhantomSetting";
        
        /// <summary>
        /// Github url
        /// </summary>
        public const string Url = "https://raw.githubusercontent.com/PhantomUniversal/ExpandSDK/main/Release"; // Todo 정확한 주소가 맞은지 확인 필요

    }
}

#endif