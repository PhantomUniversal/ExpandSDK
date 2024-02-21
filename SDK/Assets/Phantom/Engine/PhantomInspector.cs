#if UNITY_EDITOR

using UnityEditor;

namespace PhantomEngine
{
    
    [CustomEditor(typeof(PhantomSetting), true)]
    public class PhantomInspector : PhantomGUIEditor
    {

        #region OVERRIDE

        protected override void OnInspector()
        {

        }

        #endregion
        
    }
}

#endif