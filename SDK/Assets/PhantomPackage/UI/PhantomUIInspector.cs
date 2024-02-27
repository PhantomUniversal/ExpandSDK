#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace PhantomEngine.UI
{
    // [CustomEditor(typeof(PhantomUIObserver), true, isFallback = true)]
    // public class PhantomUIInspector : PhantomGUIEditor
    // {
    //     private bool ConfigEnable { get; set; }
    //     
    //     // Todo 오브젝트 분리 시키기 가능할듯!
    //     protected override void OnInspector()
    //     {
    //         PhantomUIObserver observerTarget = (PhantomUIObserver)target;
    //         if (observerTarget is null)
    //             return;
    //         
    //     }
    // }
}

#endif