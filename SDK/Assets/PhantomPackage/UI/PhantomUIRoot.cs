namespace PhantomEngine.UI
{

    public interface IUISubject
    {

        /// <summary>
        /// 
        /// </summary>
        void OnBind();
        
        /// <summary>
        /// 
        /// </summary>
        void OnObserver(PhantomUIRequest request);

        /// <summary>
        /// 
        /// </summary>
        void OnClear();

    }
    
    public interface IUIObserver
    {

        void OnEvent(PhantomUIRequest request);

    }
    
}