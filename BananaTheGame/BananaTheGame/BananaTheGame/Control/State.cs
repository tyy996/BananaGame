using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Control
{
    public abstract class State
    {
        public bool IsPaused { get; set; }
        public bool IsVisable { get; set; }

        public abstract void Load();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

        public abstract void DrawSprite(GameTime gameTime);
    }
}
