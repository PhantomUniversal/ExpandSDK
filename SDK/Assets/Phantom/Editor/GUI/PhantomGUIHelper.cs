using UnityEngine;

namespace PhantomEditor
{
    public static class PhantomGUIHelper
    {
        public static Rect ConfigurePlacement(Vector2 size, PhantomGUILocation location)
        {
            var screenLocation = location switch
            {
                PhantomGUILocation.General => PhantomGUILayout.Location,
                PhantomGUILocation.Center => new Vector2(Screen.currentResolution.width * 0.5f - size.x * 0.5f, PhantomGUILayout.Location.y),
                _ => Vector2.zero
            };

            return new Rect(screenLocation, size);
        }
    }
}