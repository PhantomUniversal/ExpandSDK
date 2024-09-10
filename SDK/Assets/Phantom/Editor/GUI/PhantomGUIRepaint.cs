using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIRepaint
    {
        private static bool RepaintEnable { get; set; }
        
        
        public static void RepaintRequest() => RepaintEnable = true; 
        
        public static void RepaintClear() => RepaintEnable = false;
        
        public static void RepaintSpace(float value)
        {
            EditorGUILayout.Space();
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