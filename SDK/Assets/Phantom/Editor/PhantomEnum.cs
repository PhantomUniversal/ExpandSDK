#if UNITY_EDITOR

namespace PhantomEditor
{
    
    public enum PhantomProfileType
    {
        Local,
        Dev,
        Integration,
        Qa,
        Staging,
        Production
    }  
    
    public enum PhantomResourceType
    {
        None = 0,
        Icon = 1,
    }
    
}

#endif