#if UNITY_EDITOR

using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIStyle
    {

        #region VARIABLE

        // ==================================================
        // [ Button ]
        // ==================================================
        private static GUIStyle _button;

        private static GUIStyle _boldButton;

        #endregion



        #region BUTTON

        public static GUIStyle Button
        {
            get
            {
                _button ??= new GUIStyle(GUI.skin.button)
                {
                    margin = new RectOffset(0, 0, 0, 0),
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

#endif