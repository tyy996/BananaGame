using System;

namespace BananaTheGame.Controllers
{
    public class MouseClickArgs
    {
        public enum MouseButtons
        {
            Right,
            Left,
            Middle
        }

        public MouseButtons Pressed { get; private set; }

        public MouseClickArgs(MouseButtons button)
        {
            this.Pressed = button;
        }
    }
}
