using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUIObserver : MonoBehaviour, IUISubject
    {

        #region CONFIG
        
        [SerializeField, FoldoutGroup("zz")] public string eventType;
        [SerializeField] public string eventUid;
        //[SerializeField] public List<Object> eventObserver;
        
        public string EventString { get; set; }
        
        #endregion
        
        
        
        #region LIFECYCLE
        
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

        public void OnBind()
        {
            
        }

        public void OnObserver(PhantomUIRequest request)
        {
            
        }

        public void OnClear()
        {
            
        }

        #endregion
        
    }
}