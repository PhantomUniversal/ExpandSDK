namespace PhantomEngine
{
    public abstract class PhantomData<T> where T : class, new()
    {
        protected abstract void OnInitialized();
        
        private static bool _isInitialized = false;
        private static readonly object _lock = new();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_isInitialized)
                    return _instance;

                lock (_lock)
                {
                    if (_instance != null) 
                        return _instance;

                    _instance = new T();
                    
                    if (_instance is PhantomData<T> dataInstance)
                    {
                        dataInstance.OnInitialized();
                    }

                    _isInitialized = true;
                    return _instance;
                }
            }
        }
    }
}