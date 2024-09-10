using UnityEditor;

namespace PhantomEditor
{
    public static class PhantomMenu
    {
        [MenuItem(PhantomMenuConfig.Root + "/" + PhantomHubConfig.Name, false, priority = 0)]
        private static void HubTool()
        {
            PhantomGUIKit.Tool<PhantomHub>();
        }
    }
}