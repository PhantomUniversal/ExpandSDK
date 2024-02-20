using UnityEngine;

namespace PhantomEngine.UI
{
    
    public abstract class PhantomUIBase : MonoBehaviour, IUICallback
    {

        #region BASE
        
        [Phantom("Type", PhantomAttributeStatus.ReadOnly), SerializeField] public PhantomUIType eventType;
        [Phantom("Uid"), SerializeField] public string eventUid;
        
        #endregion
        
        
        
        #region OVERRIDE

        protected abstract void OnEvent(PhantomUIRequest request);

        #endregion
        
        
        
        #region LIFECYCLE

        private void Start()
        {
            PhantomUI.Add(this, new PhantomUIConfig{ type = eventType, uid = eventUid});
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