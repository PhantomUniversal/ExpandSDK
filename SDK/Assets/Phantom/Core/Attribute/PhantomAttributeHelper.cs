#if UNITY_EDITOR

using System.Reflection;

namespace PhantomEditor
{
    public static class PhantomAttributeHelper
    {
        
        /// <summary>
        /// 
        /// </summary>
        public const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly;
        
    }
}

#endif