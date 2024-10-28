using System.Collections.Generic;

namespace PhantomEditor
{
    public class PhantomGUIStack<T>
    {
        private readonly Stack<T> _stack = new();
        private readonly PhantomGUIFrame _frame = new();
        
        public int Count
        {
            get
            {
                if(_frame.IsNewFrame())
                    _stack.Clear();
                return _stack.Count;
            }
        }
        
        public void Push(T value)
        {
            if(_frame.IsNewFrame())
                _stack.Clear();
            _stack.Push(value);
        }

        public T Pop()
        {
            if (Count == 0)
            {
                return default;
            }

            if (!_frame.IsNewFrame())
                return _stack.Pop();    
            
            _stack.Clear();
            return default;
        }

        public T Peek()
        {
            if(_frame.IsNewFrame())
                _stack.Clear();
            return _stack.Peek();
        }
    }
}