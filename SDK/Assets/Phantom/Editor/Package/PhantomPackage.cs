using UnityEngine;

namespace PhantomEditor
{
    public sealed class PhantomPackage : PhantomGUIWindow
    {
        public override string DrawName => PhantomPackageConfig.ToolName;
        public override Vector2 DrawSize => PhantomPackageConfig.ToolSize;
        public override PhantomGUILocationType DrawLocation => PhantomPackageConfig.ToolLocation;
        
        protected override void DrawGUI()
        {
            PhantomGUI.BeginVerticalLayout();
            
            PhantomGUI.Label("Test1", true);
            PhantomGUI.Label("Test2");
            PhantomGUI.Label("Test3");
            
            PhantomGUI.EndVerticalLayout();
        }
    }
}