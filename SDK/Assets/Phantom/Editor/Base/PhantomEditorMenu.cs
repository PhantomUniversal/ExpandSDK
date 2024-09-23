using UnityEditor;

namespace PhantomEditor
{
    public static class PhantomEditorMenu
    {
        [MenuItem(PhantomEditorConfig.PackageMenu + "/" + PhantomPackageConfig.ToolName, false, priority = 0)]
        private static void PackageTool()
        {
            PhantomGUIUtility.Tool<PhantomPackage>();
        }
    }
}