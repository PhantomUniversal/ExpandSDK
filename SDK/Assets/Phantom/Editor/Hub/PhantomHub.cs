using UnityEditor;

namespace PhantomEditor
{
    public static class PhantomHub
    {
        [MenuItem(PhantomHubHelper.ToolPath)]
        private static void Tool()
        {
            PhantomTool.Window<PhantomHubWindow>(PhantomHubHelper.ToolTitle, PhantomHubHelper.ToolSize, PhantomEditorLocation.Center);
        }
    }
}