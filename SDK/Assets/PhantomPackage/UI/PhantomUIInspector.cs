using UnityEditor;

namespace PhantomEngine.UI
{
    [CustomEditor(typeof(PhantomUIBase), true)]
    public class PhantomUIInspector : PhantomGUIEditor
    {

        private SerializedProperty _type;

        private void OnEnable()
        {
            _type = serializedObject.FindProperty("eventConfig.type");
        }

        private void OnDisable()
        {
            _type = null;
        }

        protected override void OnInspector()
        {
            EditorGUILayout.PropertyField(_type);
        }
    }
}