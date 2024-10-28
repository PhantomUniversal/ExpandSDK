using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public class PhantomEditorSo : Editor
    {
        private const string SoExtension = ".asset";

        public static T Bind<T>(string folderPath, string folderName) where T : ScriptableObject
        {
            if (!AssetDatabase.IsValidFolder(folderPath))
                AssetDatabase.CreateFolder(folderPath, folderName);

            var path = Path<T>(folderPath, folderName);
            if (AssetDatabase.LoadAssetAtPath(path, typeof(T)) is T so)
                return so;
            
            so = CreateInstance<T>();
            AssetDatabase.CreateAsset(so, path);
            AssetDatabase.SaveAssets();
            return so;
        }

        public static bool Release<T>(string folderPath, string folderName) where T : ScriptableObject
        {
            var path = Path<T>(folderPath, folderName);
            if (AssetDatabase.LoadAssetAtPath(path, typeof(T)) is not T so)
                return false;
            
            AssetDatabase.RemoveObjectFromAsset(so);
            return true;
        }
        
        private static string Path<T>(string folderPath, string folderName) where T : ScriptableObject
        {
            return $"{folderPath}/{folderName}/{typeof(T).Name}{SoExtension}";
        }
    }
}