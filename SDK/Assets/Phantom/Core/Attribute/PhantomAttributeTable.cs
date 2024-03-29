﻿#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;

namespace PhantomEditor
{
    [Serializable]
    public class PhantomAttributeTable
    {
        public PhantomAttributeType eventType;
        public bool eventEnable;
        public string eventLabel;
        public List<SerializedProperty> eventProperties;
    }
}

#endif