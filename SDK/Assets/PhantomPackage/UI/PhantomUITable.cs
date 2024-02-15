using System;

namespace PhantomEngine.UI
{
    
    [Serializable]
    public class PhantomUIConfig
    {
        public int type;
        public string uid;
    }
    
    [Serializable]
    public class PhantomUIRequest : PhantomUIConfig
    {
        public int status;
        public int hash;
        public string key;
        public string value;
    }
    
}