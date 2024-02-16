using UnityEngine;

namespace PhantomEngine
{
    public class PhantomEnumAttribute : PropertyAttribute
    {
        public readonly string Label;

        public PhantomEnumAttribute()
        {
            Label = string.Empty;
        }
        
        public PhantomEnumAttribute(string label)
        {
            Label = label;
        }
    }
}