using UnityEngine;

namespace PhantomEngine.UI
{
    
    public abstract class PhantomUIBase : MonoBehaviour, IUICallback
    {

        #region BASE

        [SerializeField] private PhantomUIConfig eventConfig;

        #endregion
        
        
        
        #region OVERRIDE

        protected abstract void OnEvent(PhantomUIRequest request);

        #endregion
        
        
        
        #region LIFECYCLE

        private void Start()
        {
            PhantomUI.Add(this, eventConfig);
        }

        private void OnDestroy()
        {
            PhantomUI.Remove(this);
        }

        #endregion



        #region CALLBACK

        public void OnEventCallback(PhantomUIRequest request)
        {
            OnEvent(request);
        }

        #endregion
        
    }
}