#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUIStyle
    {

        #region VARIABLE

        // ==================================================
        // [ Foldout ]
        // ==================================================
        private static GUIStyle _foldoutHeader;
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        private static GUIStyle _label;

        private static GUIStyle _boldLabel;

        private static GUIStyle _leftBoldLabel;
        
        
        // ==================================================
        // [ Text ]
        // ==================================================
        private static GUIStyle _text;
        
        private static GUIStyle _boldText;
        
        
        // ==================================================
        // [ Button ]
        // ==================================================
        private static GUIStyle _button;

        private static GUIStyle _boldButton;
        
        
        // ==================================================
        // [ Popup ]
        // ==================================================
        private static GUIStyle _popup;
        
        
        #endregion



        #region Foldout

        public static GUIStyle FoldoutHeader
        {
            get
            {
                _foldoutHeader ??= new GUIStyle(EditorStyles.foldoutHeader)
                {
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip,
                    fixedHeight = PhantomGUIHelper.Header,
                };

                return _foldoutHeader;
            }
        }

        #endregion

        

        #region LABEL

        public static GUIStyle Label
        {
            get
            {
                _label ??= new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(2, 0, 0, 4), 
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip,
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

        public static GUIStyle LeftBoldLabel
        {
            get
            {
                _leftBoldLabel ??= new GUIStyle(BoldLabel)
                {
                    alignment = TextAnchor.MiddleLeft
                };

                return _leftBoldLabel;
            }
        }
        
        #endregion



        #region TEXT

        public static GUIStyle Text
        {
            get
            {
                _text ??= new GUIStyle(GUI.skin.textField)
                {
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleLeft
                };

                return _text;
            }
        }

        public static GUIStyle BoldText
        {
            get
            {
                _boldText ??= new GUIStyle(Text)
                {
                    fontStyle = FontStyle.Bold,
                };

                return _boldText;
            }
        }

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



        #region POPUP

        public static GUIStyle Popup
        {
            get
            {
                _popup ??= new GUIStyle(EditorStyles.popup)
                {
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip,
                    fixedHeight = 20f,
                };

                return _popup;
            }
        }

        #endregion
        
    }
}

#endif