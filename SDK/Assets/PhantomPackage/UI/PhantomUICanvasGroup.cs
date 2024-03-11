namespace PhantomEngine.UI
{
    
    #if UNITY_EDITOR

    using UnityEngine;
    using UnityEditor;
    using PhantomEditor;
    
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
    
    
    public class PhantomUICanvasGroup : MonoBehaviour, IUIObserver
    {
        public void OnEvent(PhantomUIRequest request)
        {
            
        }
    }
}
