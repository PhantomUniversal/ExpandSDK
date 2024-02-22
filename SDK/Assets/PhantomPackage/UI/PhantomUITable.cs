using System;

namespace PhantomEngine.UI
{
    [Serializable]
    public class PhantomUIConfig
    {
        public string type;
        public string uid;
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