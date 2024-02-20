using System;
using UnityEngine;

namespace PhantomEngine
{
    public class PhantomAttribute : PropertyAttribute
    {
        public readonly PhantomAttributeStatus EventStatus;
        public readonly string EventLabel;
        
        public PhantomAttribute(PhantomAttributeStatus status = PhantomAttributeStatus.None)
        {
            EventStatus = status;
            EventLabel = string.Empty;
        }
        
        public PhantomAttribute(string label = "", PhantomAttributeStatus status = PhantomAttributeStatus.None)
        {
            EventStatus = status;
            EventLabel = label;
        }
    }
}