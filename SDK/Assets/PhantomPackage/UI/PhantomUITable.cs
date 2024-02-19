using System;

namespace PhantomEngine.UI
{
    // => 분해
    
    
    [Serializable]
    public class PhantomUIConfig
    {
        [PhantomPopup("Type")] public PhantomUIType type;
        [PhantomText("Uid")] public string uid;
    }
    
    [Serializable]
    public class PhantomUIRequest
    {
        public int hash;
        public string key;
        public string value;
    }

    [Serializable]
    public class PhantomUIListener
    {
        public int status;
        public PhantomUIConfig config;
        public PhantomUIRequest request;
    }
    
}