#if UNITY_EDITOR

using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomEditorOption
    {
        
        #region VARIABLE

        private static GUILayoutOption[] import;

        private static GUILayoutOption[] publish;

        private static GUILayoutOption[] etc;
        
        #endregion




        #region PROPERTY

        internal static GUILayoutOption[] Import
        {
            get
            {
                import ??= new[]
                {
                    GUILayout.Width(PhantomGUIHelper.LayoutProperty * 4),
                    GUILayout.Height(PhantomGUIHelper.LayoutProperty)
                };
                
                return import;
            }
        }

        internal static GUILayoutOption[] Publish
        {
            get
            {
                publish ??= new[]
                {
                    GUILayout.Width(PhantomGUIHelper.LayoutProperty * 3), 
                    GUILayout.Height(PhantomGUIHelper.LayoutProperty)
                };

                return publish;
            }
        }

        internal static GUILayoutOption[] Etc
        {
            get
            {
                etc ??= new[]
                {
                    GUILayout.Width(PhantomGUIHelper.LayoutProperty), 
                    GUILayout.Height(PhantomGUIHelper.LayoutProperty)
                };

                return etc;
            }
        }
        
        #endregion
        
    }
}

#endif