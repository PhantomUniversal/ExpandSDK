using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomPackageConfig
    {
        internal const string ToolName = "Package";
        
        internal static readonly Vector2 ToolSize = new(480f, 720f);

        internal const PhantomGUILocationType ToolLocation = PhantomGUILocationType.Center;
    }
}