using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIUpdate
    {
        private static bool RepaintEnable { get; set; }
        private static void RepaintRequest() => RepaintEnable = true; 
        private static void RepaintClear() => RepaintEnable = false;
        
        public static void RepaintSpace(float value)
        {
            EditorGUILayout.Space(value);
            RepaintRequest();
        }
        
        public static void Repaint(this EditorWindow editor)
        {
            if (!RepaintEnable)
                return;

            if (Event.current == null || Event.current.type != EventType.Repaint)
                return;
            
            if(editor != null)
                editor.Repaint();
            
            RepaintClear();
        }

        public static void Repaint(this Editor editor)
        {
            if (!RepaintEnable)
                return;

            if (Event.current == null || Event.current.type != EventType.Repaint)
                return;
            
            if (editor != null)
                editor.Repaint();
            
            RepaintClear();
        }
    }
}