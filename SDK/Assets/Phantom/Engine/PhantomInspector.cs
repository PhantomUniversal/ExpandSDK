#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEngine
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