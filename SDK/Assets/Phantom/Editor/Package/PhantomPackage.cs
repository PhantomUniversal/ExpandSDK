using UnityEditor;

namespace PhantomEditor
{
    public static class PhantomPackage
    {
        [MenuItem(PhantomEditorConfig.PackageName + "/" + PhantomPackageConfig.ToolName, false, priority = 0)]
        private static void Tool()
        {
            PhantomGUIFunction.Tool<PhantomPackageTool>();
        }
    }
}