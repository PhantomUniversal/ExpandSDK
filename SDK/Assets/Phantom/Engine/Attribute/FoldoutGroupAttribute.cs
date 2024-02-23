using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class FoldoutGroupAttribute : Attribute
    {
        public readonly string EventLabel;
        
        public FoldoutGroupAttribute(string label)
        {
            EventLabel = label;
        }
    }
}