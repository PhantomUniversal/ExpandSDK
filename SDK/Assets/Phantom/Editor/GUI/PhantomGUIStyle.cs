using UnityEngine;

namespace PhantomCore
{
    public static class PhantomGUIStyle
    {
        #region LABEL
        
        private static GUIStyle label;
        
        private static GUIStyle boldLabel;
        
        
        public static GUIStyle Label
        {
            get
            {
                label ??= new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(2, 0, 0, 4),
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip
                };
                return label;
            }
        }

        public static GUIStyle BoldLabel
        {
            get
            {
                boldLabel ??= new GUIStyle(Label)
                {
                    fontStyle = FontStyle.Bold
                };
                return boldLabel;
            }
        }

        #endregion
    }
}