#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine
{
    public static class PhantomGUIStyle
    {
        
        #region VARIABLE
        
        // ==================================================
        // [ Box ]
        // ==================================================
        private static GUIStyle _box;
        
        
        // ==================================================
        // [ Foldout ]
        // ==================================================
        private static GUIStyle _foldout;
        
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
        
        private static GUIStyle _leftText;
        
        
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



        #region BOX

        public static GUIStyle Box
        {
            get
            {
                _box ??= new GUIStyle(GUI.skin.box)
                {
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
                };

                return _box;
            }
        }

        
        #endregion
        
        


        #region FOLDOUT

        public static GUIStyle Foldout
        {
            get
            {
                _foldout ??= new GUIStyle(EditorStyles.foldout)
                {
                    padding = new RectOffset(16, 0, 0, 0), 
                    margin = new RectOffset(4, 0, 0, 0),
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleLeft
                };

                return _foldout;
            }
        }
        
        public static GUIStyle FoldoutHeader
        {
            get
            {
                _foldoutHeader ??= new GUIStyle(Foldout)
                {
                    fontSize = PhantomGUIHelper.FontSize,
                    fontStyle = FontStyle.Bold,
                    
                    normal = new GUIStyleState()
                    {
                        textColor = PhantomGUIColor.NormalTextColor
                    },
                    
                    onNormal = new GUIStyleState()
                    {
                        textColor = PhantomGUIColor.SelectTextColor
                    }
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
                    margin = PhantomGUIHelper.LayoutOffset,
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
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip
                };

                return _text;
            }
        }

        public static GUIStyle LeftText
        {
            get
            {
                _leftText ??= new GUIStyle(Text)
                {
                    alignment = TextAnchor.MiddleLeft
                };

                return _leftText;
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
                    margin = PhantomGUIHelper.LayoutOffset,
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
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
                    fixedHeight = PhantomGUIHelper.LayoutProperty
                };

                return _popup;
            }
        }

        #endregion
        
    }
}

#endif