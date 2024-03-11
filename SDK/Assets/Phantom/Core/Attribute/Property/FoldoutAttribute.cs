using System;
using System.Diagnostics;
using PhantomEditor;

namespace PhantomEngine
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    [Conditional("UNITY_EDITOR")]
    public class FoldoutAttribute : PhantomAttributeBase
    {
        
        public readonly string attributeLabel;
        public readonly bool attributeHeader;
        
        public FoldoutAttribute(string label)
        {
            attributeLabel = label;
            attributeHeader = false;
        }
        
        public FoldoutAttribute(string label, bool header = false)
        {
            attributeLabel = label;
            attributeHeader = header;
        }
        
    }
}