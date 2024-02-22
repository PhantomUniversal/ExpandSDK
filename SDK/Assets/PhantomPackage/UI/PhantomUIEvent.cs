using System.Collections.Generic;
using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUIEvent : MonoBehaviour
    {

        #region BASE
        
        [SerializeField] private List<PhantomUIListener> eventListeners;

        #endregion



        #region FUNCTION
        
        protected void Event()
        {
            if (eventListeners is null || eventListeners.Count == 0)
                return;

            foreach (var listener in eventListeners)
            {
                switch ((PhantomUIStatus)listener.status)
                {
                    case PhantomUIStatus.Type:
                        PhantomUI.TypeEvent(listener.config.type, listener.request);
                        break;
                    case PhantomUIStatus.Target:
                        PhantomUI.TargetEvent(listener.config.uid, listener.request);
                        break;
                    default:
                        PhantomUI.Event(listener.request);
                        break;
                }   
            }
        }
        
        #endregion
        
    }
}