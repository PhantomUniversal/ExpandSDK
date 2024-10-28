using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIStyle
    {
        #region BASE

        private static GUIStyle _none;

        
        public static GUIStyle None
        {
            get
            {
                _none ??= new GUIStyle()
                {
                    margin = new RectOffset(0, 0, 0, 0),
                    padding = new RectOffset(0, 0, 0, 0),
                    border = new RectOffset(0, 0, 0, 0)
                };
                return _none;
            }
        }
        
        #endregion

        #region GROUP

        private static GUIStyle _group;
        private static GUIStyle _groupHeader;
        
        public static GUIStyle Group
        {
            get
            {
                _group ??= new GUIStyle(EditorStyles.helpBox)
                {
                    margin = new RectOffset(0, 0, 0, 2),
                };
                return _group;
            }
        }
        public static GUIStyle GroupHeader
        {
            get
            {
                _groupHeader ??= new GUIStyle(None)
                {
                    margin = new RectOffset(0, 0, 0, 2),
                };
                return _groupHeader;
            }
        }

        #endregion
        
        #region LABEL
        
        private static GUIStyle _label;
        private static GUIStyle _labelCentered;
        private static GUIStyle _boldLabel;
        private static GUIStyle _boldLabelCentered;
        
        
        public static GUIStyle Label
        {
            get
            {
                _label ??= new GUIStyle(EditorStyles.label)
                {
                    margin = new RectOffset(0, 0, 0, 0)
                };
                return _label;
            }
        }

        public static GUIStyle LabelCentered
        {
            get
            {
                _labelCentered ??= new GUIStyle(Label)
                {
                    alignment = TextAnchor.MiddleCenter,
                    clipping = TextClipping.Clip
                };
                return _labelCentered;
            }
        }
        public static GUIStyle BoldLabel
        {
            get
            {
                _boldLabel ??= new GUIStyle(EditorStyles.boldLabel)
                {
                    margin = new RectOffset(0, 0, 0, 0)
                };
                return _boldLabel;
            }
        }

        public static GUIStyle BoldLabelCentered
        {
            get
            {
                _boldLabelCentered ??= new GUIStyle(BoldLabel)
                {
                    alignment = TextAnchor.MiddleCenter,
                    clipping = TextClipping.Clip
                };
                return _boldLabelCentered;
            }
        }
        
        #endregion

        #region TEXT
        
        private static GUIStyle _textField;
        
        
        public static GUIStyle TextField
        {
            get
            {
                _textField ??= new GUIStyle(EditorStyles.textField)
                {
                    margin = new RectOffset(0, 0, 0, 0),
                };
                return _textField;
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
                _button ??= new GUIStyle(nameof(Button))
                {
                    margin = new RectOffset(0, 0, 0, 2),
                    clipping = TextClipping.Clip,
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

        private static GUIStyle _popup;

        
        public static GUIStyle Popup
        {
            get
            {
                _popup ??= new GUIStyle(EditorStyles.popup)
                {
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip,
                };
                return _popup;
            }
        }
        
        #endregion
    }
}