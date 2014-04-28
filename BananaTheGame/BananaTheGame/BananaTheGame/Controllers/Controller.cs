using System;

namespace BananaTheGame.Controllers
{
    public abstract class Controller
    {
        public bool IsPaused { get; set; }

        public abstract void Update();
    }
}
