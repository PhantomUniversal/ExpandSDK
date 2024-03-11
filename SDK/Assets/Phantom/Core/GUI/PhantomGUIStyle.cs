#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIStyle
    {
        
        #region VARIABLE
        
        // ==================================================
        // [ Box ]
        // ==================================================
        private static GUIStyle box;
        
        
        // ==================================================
        // [ Foldout ]
        // ==================================================
        private static GUIStyle foldout;
        
        private static GUIStyle foldoutHeader;
        
        
        // ==================================================
        // [ Label ]
        // ==================================================
        private static GUIStyle label;

        private static GUIStyle boldLabel;

        private static GUIStyle leftBoldLabel;
        
        
        // ==================================================
        // [ Text ]
        // ==================================================
        private static GUIStyle text;
        
        private static GUIStyle leftText;
        
        
        // ==================================================
        // [ Button ]
        // ==================================================
        private static GUIStyle button;

        private static GUIStyle boldButton;
        
        
        // ==================================================
        // [ Popup ]
        // ==================================================
        private static GUIStyle popup;
        
        
        #endregion



        #region BOX

        public static GUIStyle Box
        {
            get
            {
                box ??= new GUIStyle(GUI.skin.box)
                {
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
                };

                return box;
            }
        }

        
        #endregion
        
        


        #region FOLDOUT

        public static GUIStyle Foldout
        {
            get
            {
                foldout ??= new GUIStyle(EditorStyles.foldout)
                {
                    padding = new RectOffset(16, 0, 0, 0), 
                    margin = new RectOffset(4, 0, 0, 0),
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleLeft
                };

                return foldout;
            }
        }
        
        public static GUIStyle FoldoutHeader
        {
            get
            {
                foldoutHeader ??= new GUIStyle(Foldout)
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

                return foldoutHeader;
            }
        }

        
        #endregion

        

        #region LABEL

        public static GUIStyle Label
        {
            get
            {
                label ??= new GUIStyle(GUI.skin.label)
                {
                    padding = new RectOffset(2, 0, 0, 4), 
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
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

        public static GUIStyle LeftBoldLabel
        {
            get
            {
                leftBoldLabel ??= new GUIStyle(BoldLabel)
                {
                    alignment = TextAnchor.MiddleLeft
                };

                return leftBoldLabel;
            }
        }
        
        #endregion



        #region TEXT

        public static GUIStyle Text
        {
            get
            {
                text ??= new GUIStyle(GUI.skin.textField)
                {
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip
                };

                return text;
            }
        }

        public static GUIStyle LeftText
        {
            get
            {
                leftText ??= new GUIStyle(Text)
                {
                    alignment = TextAnchor.MiddleLeft
                };

                return leftText;
            }
        }

        #endregion
        
        

        #region BUTTON

        public static GUIStyle Button
        {
            get
            {
                button ??= new GUIStyle(GUI.skin.button)
                {
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleCenter
                };

                return button;
            }
        }

        public static GUIStyle BoldButton
        {
            get
            {
                boldButton ??= new GUIStyle(Button)
                {
                    fontStyle = FontStyle.Bold
                };

                return boldButton;
            }
        }

        #endregion



        #region POPUP

        public static GUIStyle Popup
        {
            get
            {
                popup ??= new GUIStyle(EditorStyles.popup)
                {
                    margin = PhantomGUIHelper.LayoutOffset,
                    clipping = TextClipping.Clip,
                    fixedHeight = PhantomGUIHelper.LayoutProperty
                };

                return popup;
            }
        }

        #endregion
        
    }
}

#endif