using UnityEngine;

namespace PhantomEditor
{
    public class PhantomGUIFrame
    {
        private int _frameCount;
        private bool _frameRepaint = true;
        
        public int FrameCount => _frameCount;

        public bool IsNewFrame()
        {
            if (Event.current == null)
                return false;

            EventType type = Event.current.type;
            if (type == EventType.Repaint)
            {
                _frameRepaint = true;
                return false;
            }

            if (!_frameRepaint) 
                return false;

            _frameCount++;
            _frameRepaint = false;
            return true;
        }
    }
}