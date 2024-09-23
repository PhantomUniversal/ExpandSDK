using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIHelper
    {
        public static Rect ConfigurePlacement(Vector2 size, PhantomGUILocationType location)
        {
            var screenLocation = location switch
            {
                PhantomGUILocationType.General => PhantomGUILayout.DefaultSize,
                PhantomGUILocationType.Center => new Vector2(Screen.currentResolution.width * 0.5f - size.x * 0.5f, PhantomGUILayout.DefaultSize.y),
                _ => Vector2.zero
            };

            return new Rect(screenLocation, size);
        }
    }
}