#if UNITY_EDITOR

namespace PhantomEditor
{
    public static class PhantomEditorUtility
    {

        #region PATH

        internal static string CombinePath(string packagePath, string resourcePath)
        {
            return packagePath.Contains(PhantomEditorHelper.Identifier) 
                ? $"Package/{PhantomEditorHelper.Identifier}/Resource/{resourcePath}" : $"{PhantomEditorHelper.Resource}/{resourcePath}";
        }

        #endregion
        
    }
}

#endif