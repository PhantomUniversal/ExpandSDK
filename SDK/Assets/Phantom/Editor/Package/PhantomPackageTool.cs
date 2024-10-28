using UnityEngine;

namespace PhantomEditor
{
    public sealed class PhantomPackageTool : PhantomGUITool
    {
        public override string DrawName => PhantomPackageConfig.ToolName;
        public override Vector2 DrawSize => new(PhantomPackageConfig.ToolWidth, PhantomPackageConfig.ToolHeight);
        
        
        protected override void DrawOpen()
        {
            
        }

        protected override void DrawClose()
        { 
            
        }

        protected override void DrawGUI()
        {
            
        }
    }
}