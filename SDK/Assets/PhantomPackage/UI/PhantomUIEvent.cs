using System.Collections.Generic;
using UnityEngine;

namespace PhantomEngine.UI
{
    public abstract class PhantomUIEvent : MonoBehaviour
    {

        #region BASE
        
        public List<PhantomUIRequest> eventRequest;

        #endregion



        #region FUNCTION
        
        protected void Event()
        {
            if (eventRequest is null || eventRequest.Count == 0)
                return;

            foreach (var request in eventRequest)
            {
                switch ((PhantomUIStatus)request.status)
                {
                    case PhantomUIStatus.Type:
                        PhantomUI.TypeEvent(request);
                        break;
                    case PhantomUIStatus.Target:
                        PhantomUI.TargetEvent(request);
                        break;
                    default:
                        PhantomUI.AllEvent(request);
                        break;
                }   
            }
        }
        
        #endregion
        
    }
}