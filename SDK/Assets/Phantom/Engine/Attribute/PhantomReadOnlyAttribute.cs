using System;
using System.Diagnostics;
using UnityEngine;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class PhantomReadOnlyAttribute : PropertyAttribute
    {
        
    }
}