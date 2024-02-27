using System;
using System.Diagnostics;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class PhantomFoldoutAttribute : PhantomAttributeBase
    {
        
        #region VARIABLE

        public readonly string EventLabel;
        public readonly bool EventHeader;

        #endregion

        public PhantomFoldoutAttribute(string label)
        {
            EventLabel = label;
            EventHeader = false;
        }
        
        public PhantomFoldoutAttribute(string label, bool header = false)
        {
            EventLabel = label;
            EventHeader = header;
        }
    }
}