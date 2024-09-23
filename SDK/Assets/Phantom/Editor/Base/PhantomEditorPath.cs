using System.Runtime.CompilerServices;

namespace PhantomEditor
{
    public static class PhantomEditorPath
    {
        // Why don't you add a full search function?
        public static string ResourcePath(string resourceName, PhantomEditorResourceType resourceType, [CallerFilePath] string packageRoot = null)
        {
            if (string.IsNullOrEmpty(resourceName) || resourceType == PhantomEditorResourceType.None)
                return string.Empty;

            return packageRoot is null ? string.Empty : $"{RootPath(packageRoot)}/{PhantomEditorAssemblyType.Resource}/{resourceType}/{resourceName}";
        }
        
        private static string RootPath(string packageRoot)
        {
            return packageRoot.Contains(PhantomEditorConfig.PackageIdentifier) ? $"Packages/{PhantomEditorConfig.PackageIdentifier}" : $"Assets/{PhantomEditorConfig.PackageName}";
        }
    }
}