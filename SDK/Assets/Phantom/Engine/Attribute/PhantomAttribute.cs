using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public sealed class PhantomAttribute : PropertyAttribute
    {
        public readonly bool EventEnable;
        public readonly string EventLabel;
        
        public PhantomAttribute(bool enable = false)
        {
            EventEnable = enable;
            EventLabel = string.Empty;
        }

        public PhantomAttribute(string label, bool enable = false)
        {
            EventEnable = enable;
            EventLabel = label;
        }
    }
    
}