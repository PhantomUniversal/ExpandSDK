using UnityEngine;

namespace PhantomEditor
{
    public sealed class PhantomHub : PhantomGUITool
    {
        public override string DrawName => PhantomHubConfig.Name;
        public override Vector2 DrawSize => PhantomHubLayout.Size;
        public override PhantomGUILocation DrawLocation => PhantomGUILocation.Center;
        
        protected override void DrawGUI()
        {
            PhantomGUI.BeginVerticalLayout();
            PhantomGUI.BoldLabel("Phantom Hub");
            PhantomGUI.EndVerticalLayout();
        }
    }
}