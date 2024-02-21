using UnityEngine;

namespace PhantomEngine.UI
{
    public abstract class PhantomUIBase : MonoBehaviour, IUICallback
    {

        #region BASE

        [Phantom("Type", true), SerializeField] public PhantomUIType eventType;
        [Phantom("Uid"), SerializeField] public string eventUid;
        
        #endregion
        
        
        
        #region OVERRIDE
        
        protected abstract void OnBind();
        
        protected abstract void OnEvent(PhantomUIRequest request);

        #endregion
        
        
        
        #region LIFECYCLE

#if UNITY_EDITOR

        [ContextMenu("Bind")]
        private void OnValidate()
        {
            OnBind();
        }

#endif

        private void Awake()
        {
            OnBind();
        }

        private void Start()
        {
            PhantomUI.Add(this, new PhantomUIConfig{ type = eventType, uid = eventUid });
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