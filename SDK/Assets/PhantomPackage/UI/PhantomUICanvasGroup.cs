namespace PhantomEngine.UI
{
    
    #if UNITY_EDITOR

    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(PhantomUICanvasGroup), true)]
    public class PhantomUICanvasGroupInspector : PhantomGUIEditor
    {
        protected override void OnInspector()
        {
            Rect baseRect = PhantomGUI.BeginGroupLayout();
            PhantomGUI.FoldoutHeader(true, "Component");
            PhantomGUI.EndGroupLayout();
        }
    }
    
    #endif
    
    
    public class PhantomUICanvasGroup : PhantomUIBase
    {
        protected override void OnBind()
        {
            eventType = PhantomUIType.CanvasGroup;
        }

        protected override void OnEvent(PhantomUIRequest request)
        {
            
        }
        
    }
}
