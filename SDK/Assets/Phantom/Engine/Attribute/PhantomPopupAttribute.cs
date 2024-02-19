using UnityEngine;

namespace PhantomEngine
{
    public class PhantomPopupAttribute : PropertyAttribute
    {
        public readonly string Label;

        public PhantomPopupAttribute()
        {
            Label = string.Empty;
        }
        
        public PhantomPopupAttribute(string label)
        {
            Label = label;
        }
    }
}