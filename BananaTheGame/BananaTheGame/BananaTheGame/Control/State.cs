using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Control
{
    public class State
    {
        public bool IsPaused { get; set; }
        public bool IsVisable { get; set; }

        public virtual void Load() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(GameTime gameTime) { }

        public virtual void DrawSprite(GameTime gameTime) { }
    }
}
