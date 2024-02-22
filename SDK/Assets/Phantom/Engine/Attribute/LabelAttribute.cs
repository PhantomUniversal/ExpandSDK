using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class LabelAttribute : PropertyAttribute
    {
        public readonly string EventLabel;
        
        public LabelAttribute(string label)
        {
            EventLabel = label;
        }
    }
}