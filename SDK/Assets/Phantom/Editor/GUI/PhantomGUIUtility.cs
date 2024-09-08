using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIUtility
    {
        private static bool RepaintEnable { get; set; }
        
        
        public static void RepaintRequest() => RepaintEnable = true; 
        
        public static void RepaintClear() => RepaintEnable = false;
        
        public static void RepaintSpace(float value)
        {
            EditorGUILayout.Space();
            RepaintRequest();
        }


        public static void Repaint(this EditorWindow editorWindow)
        {
            if (!RepaintEnable)
                return;

            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if((bool)(Object)editorWindow)
                editorWindow.Repaint();
            
            RepaintClear();
        }

        public static void Repaint(this Editor editor)
        {
            if (!RepaintEnable)
                return;

            if (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse)
                return;
            
            if ((bool)(Object)editor)
                editor.Repaint();
            
            RepaintClear();
        }
    }
}