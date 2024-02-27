using UnityEngine;

namespace PhantomEngine.UI
{
    public class PhantomUIObserver : MonoBehaviour, IUISubject
    {

        // type => so에서 추가 및 설정 하고 지정할수 있도록 설정
        // uid => script별 설정
        // observer init gui button 만들기
        // observer list gui 만들기
        
        #region CONFIG
        
        [SerializeField, PhantomFoldout("zz")] public string eventType;
        [SerializeField] public string eventUid;
        [SerializeField, PhantomFoldout("zzz")] public string eventTypes;
        [SerializeField, PhantomFoldout("zz")] public string eventTypess;
        //[SerializeField] public List<Object> eventObserver;
        
        public string EventTemp { get; set; }
        
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