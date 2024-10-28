using UnityEditor;

namespace PhantomEditor
{
    public static class PhantomExport
    {
        [MenuItem(PhantomEditorConfig.PackageName + "/" + PhantomExportConfig.ToolName, false, priority = 101)]
        private static void Tool()
        {
            PhantomGUIFunction.Tool<PhantomExportTool>();
        }
    }
}