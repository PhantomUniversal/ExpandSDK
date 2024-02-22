using System.Collections.Generic;
using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUIObserver : MonoBehaviour, IUISubject
    {

        #region CONFIG

        [Label("Type"), SerializeField] public string eventType;
        [Label("Type"), SerializeField] public string eventUid;
        //[SerializeField] public List<Object> eventObserver;
        
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