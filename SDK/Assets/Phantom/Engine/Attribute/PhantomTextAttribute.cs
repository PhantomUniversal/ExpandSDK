using UnityEngine;

namespace PhantomEngine
{
    public class PhantomTextAttribute : PropertyAttribute
    {
        public readonly string Label;

        public PhantomTextAttribute()
        {
            Label = string.Empty;
        }
        
        public PhantomTextAttribute(string label)
        {
            Label = label;
        }
    }
}