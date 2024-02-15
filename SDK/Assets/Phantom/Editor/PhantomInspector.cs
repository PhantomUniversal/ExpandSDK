using UnityEditor;

#if UNITY_EDITOR

namespace PhantomEditor
{
    
    [CustomEditor(typeof(PhantomSetting), true)]
    public class PhantomInspector : PhantomGUIEditor
    {
        
        protected override void OnInspector()
        {

        }
        
    }
}

#endif