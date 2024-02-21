using UnityEngine;

namespace PhantomEngine
{
    public class PhantomAttribute : PropertyAttribute
    {
        public readonly bool EventReadonly;
        public readonly string EventLabel;
        
        public PhantomAttribute(bool enable = false)
        {
            EventReadonly = enable;
            EventLabel = string.Empty;
        }

        public PhantomAttribute(string label, bool enable = false)
        {
            EventReadonly = enable;
            EventLabel = label;
        }
    }
}