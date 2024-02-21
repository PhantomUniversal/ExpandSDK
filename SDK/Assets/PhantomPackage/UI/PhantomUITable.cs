using System;
using UnityEngine;

namespace PhantomEngine.UI
{
    [Serializable]
    public class PhantomUIConfig
    {
        [Phantom("Type", true), SerializeField] public PhantomUIType type;
        [Phantom("Uid"), SerializeField] public string uid;
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