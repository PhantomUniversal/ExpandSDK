#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

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
        // [ Event ]
        // ==================================================
        public static void RequestRepaint() => IsRepaint = true;

        public static void ClearRepaint() => IsRepaint = false;

        
        /// <summary>
        /// current gui total height update
        /// </summary>
        /// <param name="value"> height value </param>
        public static void UpdateRepaint(float value)
        {
            EditorGUILayout.Space(value);
            RequestRepaint();
        }
        
        // ==================================================
        // [ Function ]
        // ==================================================
        public static void Repaint(this EditorWindow window)
        {
            if (!IsRepaint)
                return;

            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if((bool)(Object)window)
                window.Repaint();
            
            ClearRepaint();
        }
        
        // [ Editor ]
        public static void Repaint(this Editor editor)
        {
            if (!IsRepaint)
                return;
            
            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if((bool) (Object) editor)
                editor.Repaint();
            
            ClearRepaint();
        }

        #endregion

    }
}

#endif