using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUILayout
    {
        public static readonly Vector2 DefaultSize = new(0, 83f);
        
        public static readonly RectOffset DefaultOffset = new(0, 0, 0, 0);

        // How about changing Property to Height?
        public const float DefaultProperty = 20f;
    }
}