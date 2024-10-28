using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIHelper
    {
        private static readonly PhantomGUIStack<Color> ColorStack = new();
        
        public static void PushColor(Color color)
        {
            ColorStack.Push(GUI.color);
            GUI.color = color;
        }

        public static void PopColor()
        {
            GUI.color = ColorStack.Pop();
        }
    }
}