using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class PhantomLabelAttribute : PropertyAttribute
    {
        public readonly string EventLabel;
        public readonly int EventOption;
        
        public PhantomLabelAttribute(string label, int option = 80)
        {
            EventLabel = label;
            EventOption = option;
        }
    }
}