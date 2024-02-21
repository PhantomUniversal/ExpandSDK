#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine.UI
{
    [CustomEditor(typeof(PhantomUIBase), false)]
    public class PhantomUIInspector : PhantomGUIEditor
    {
        private bool ConfigEnable { get; set; }
        
        // Todo 오브젝트 분리 시키기 가능할듯!
        protected override void OnInspector()
        {
            PhantomUIBase baseTarget = (PhantomUIBase)target;
            if (baseTarget is null)
                return;
    
            Rect baseRect = PhantomGUI.BeginGroupLayout();
            PhantomGUI.CustomBox(ConfigEnable ? baseRect : Rect.zero);
            
            ConfigEnable = PhantomGUI.FoldoutHeader(ConfigEnable, "Config");
            if (ConfigEnable)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("eventUid"));
            }
            
            PhantomGUI.EndGroupLayout();
        }
    }
}

#endif