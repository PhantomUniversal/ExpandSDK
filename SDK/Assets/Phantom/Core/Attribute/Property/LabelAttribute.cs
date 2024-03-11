using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class LabelAttribute : PropertyAttribute
    {
        
        public readonly string attributeLabel;
        public readonly int attributeWidth;
        
        public LabelAttribute(string label, int width = 80)
        {
            attributeLabel = label;
            attributeWidth = width;
        }
        
    }
}