#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

namespace PhantomEditor
{
    public class PhantomUtility : Editor
    {

        #region SO

        private const string DirectorySo = PhantomHelper.Resource + "/" + "So";

        private const string ExtensionSo = ".asset";
        
        public static T BindSo<T>() where T : ScriptableObject
        {
            if (!Directory.Exists(DirectorySo))
            {
                Directory.CreateDirectory(DirectorySo);
            }
            
            var path = PathSo<T>();
            if (AssetDatabase.LoadAssetAtPath(path, typeof(T)) is T so) 
                return so;
            
            so = CreateInstance<T>();
            AssetDatabase.CreateAsset(so, path);
            AssetDatabase.SaveAssets();
            return so;
        }

        public static bool ReleaseSo<T>() where T : ScriptableObject
        {
            var path = PathSo<T>();
            if (AssetDatabase.LoadAssetAtPath(path, typeof(T)) is not T so)
                return false;
            
            AssetDatabase.RemoveObjectFromAsset(so);
            return true;
        }

        private static string PathSo<T>() where T : ScriptableObject
        {
            return DirectorySo + "/" + typeof(T).Name + ExtensionSo;
        }

        #endregion
        
    }
}

#endif