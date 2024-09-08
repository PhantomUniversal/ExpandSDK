using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomHubHelper
    {
        private const string ToolName = "Hub";
        
        internal const string ToolPath = PhantomToolHelper.Name + "/" + ToolName;
        
        internal const string ToolTitle = PhantomToolHelper.Tag + " " + ToolName;
        
        internal static Vector2 ToolSize => new(480f, 720f);
    }
}