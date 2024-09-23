using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIStyle
    {
        #region LABEL
        
        private static GUIStyle _label;
        private static GUIStyle _boldLabel;
        
        public static GUIStyle Label
        {
            get
            {
                _label ??= new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(2, 0, 0, 4),
                    margin = PhantomGUILayout.DefaultOffset,
                    clipping = TextClipping.Clip
                };
                return _label;
            }
        }
        public static GUIStyle BoldLabel
        {
            get
            {
                _boldLabel ??= new GUIStyle(Label)
                {
                    fontStyle = FontStyle.Bold
                };
                return _boldLabel;
            }
        }

        #endregion

        #region BUTTON

        private static GUIStyle _button;
        private static GUIStyle _boldButton;

        public static GUIStyle Button
        {
            get
            {
                _button ??= new GUIStyle(GUI.skin.button)
                {
                    padding = PhantomGUILayout.DefaultOffset,
                    margin = PhantomGUILayout.DefaultOffset,
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleCenter
                };
                return _button;
            }
        }

        public static GUIStyle BoldButton
        {
            get
            {
                _boldButton ??= new GUIStyle(Button)
                {
                    fontStyle = FontStyle.Bold
                };
                return _boldButton;
            }
        }

        #endregion
    }
}