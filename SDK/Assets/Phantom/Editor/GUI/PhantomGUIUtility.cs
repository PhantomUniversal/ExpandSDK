#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    internal static class PhantomGUIUtility
    {

        #region REPAINT
        
        // ==================================================
        // [ Property ]
        // ==================================================
        private static bool IsRepaint { get; set; }

        
        // ==================================================
        // [ Event ]
        // ==================================================
        internal static void RequestRepaint() => IsRepaint = true;

        internal static void ClearRepaint() => IsRepaint = false;

        
        /// <summary>
        /// current gui total height update
        /// </summary>
        /// <param name="value"> height value </param>
        internal static void UpdateRepaint(float value)
        {
            EditorGUILayout.Space(value);
            RequestRepaint();
        }
        
        // ==================================================
        // [ Function ]
        // ==================================================
        internal static void Repaint(this EditorWindow window)
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
        internal static void Repaint(this Editor editor)
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