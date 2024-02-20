namespace PhantomEngine.UI
{
    public class PhantomUICanvasGroup : PhantomUIBase
    {

#if UNITY_EDITOR

        private void OnValidate()
        {
            eventType = PhantomUIType.CanvasGroup;
        }


#endif
        
        
        protected override void OnEvent(PhantomUIRequest request)
        {
            
        }
        
    }
}
