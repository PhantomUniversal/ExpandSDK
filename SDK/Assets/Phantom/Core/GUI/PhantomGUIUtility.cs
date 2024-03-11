#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PhantomEditor
{
    public static class PhantomGUIUtility
    {
        
        #region REPAINT
        
        
        // ==================================================
        // [ Property ]
        // ==================================================
        private static bool IsRepaint { get; set; }
        
        
        // ==================================================
        // [ Utility ]
        // ==================================================
        public static void RepaintRequest() => IsRepaint = true;

        public static void RepaintClear() => IsRepaint = false;
        
        /// <summary>
        /// current gui total height update
        /// </summary>
        /// <param name="value"> height value </param>
        public static void RepaintUpdate(float value)
        {
            EditorGUILayout.Space(value);
            RepaintRequest();
        }
        
        // ==================================================
        // [ Function ]
        // ==================================================
        public static void Repaint(this EditorWindow window) // EditorWindow
        {
            if (!IsRepaint)
                return;

            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if((bool)(Object)window)
                window.Repaint();
            
            RepaintClear();
        }
        
        public static void Repaint(this Editor editor) // Editor
        {
            if (!IsRepaint)
                return;
            
            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if((bool) (Object) editor)
                editor.Repaint();
            
            RepaintClear();
        }

        #endregion
        
    }
}

#endif