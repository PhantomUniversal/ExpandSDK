using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIOption
    {
        #region Button

        private static GUILayoutOption[] _button;
        private static GUILayoutOption[] _actionButton;

        public static GUILayoutOption[] Button
        {
            get
            {
                _button ??= new[]
                {
                    GUILayout.Width(PhantomGUILayout.DefaultProperty),
                    GUILayout.Height(PhantomGUILayout.DefaultProperty),
                };

                return _button;
            }
        }

        public static GUILayoutOption[] ActionButton
        {
            get
            {
                _actionButton ??= new[]
                {
                    GUILayout.Width(PhantomGUILayout.DefaultProperty * 4),
                    GUILayout.Height(PhantomGUILayout.DefaultProperty),
                };

                return _actionButton;
            }
        }
        
        #endregion
    }
}