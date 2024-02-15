using UnityEngine;
using UnityEngine.UI;

namespace PhantomEngine.UI
{
    [RequireComponent(typeof(Button))]
    public sealed class PhantomUIButton : PhantomUIEvent
    {

        #region COMPONENT
        
        public Button eventButton;

        #endregion



        #region LIFECYCLE

        private void Start()
        {
            eventButton.onClick.RemoveAllListeners();
            eventButton.onClick.AddListener(Event);
        }

        #endregion

    }
}