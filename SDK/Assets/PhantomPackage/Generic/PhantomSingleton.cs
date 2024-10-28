using UnityEngine;

namespace PhantomEngine
{
    public abstract class PhantomSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected abstract void OnInitialized();
        protected abstract void OnDestroyed();
        
        
        private static bool _applicationIsQuitting;
        private static readonly object _lock = new();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_applicationIsQuitting)
                {
                    Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance != null) 
                        return _instance;
                    
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance != null) 
                        return _instance;
                        
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T) + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);

                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
                OnInitialized();
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_instance != this) 
                return;
            
            _instance = null;
            OnDestroyed();
        }

        private void OnApplicationQuit()
        {
            _applicationIsQuitting = true;
        }
    }
}