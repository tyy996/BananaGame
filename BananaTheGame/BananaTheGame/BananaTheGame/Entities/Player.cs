using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using BananaTheGame.AnimationG;

namespace BananaTheGame.Entities
{
    public class Player : Entity
    {
        private Vector2 drawPosition;

        public AnimationCollection2 Collection { get; private set; }

        public override void Load()
        {
            Viewport viewPort = BananaGame.Graphics.Viewport;
            drawPosition = new Vector2(viewPort.Width / 2, viewPort.Height / 2);

            Collection = new AnimationCollection2();

            Collection.AnimationAtlus = BananaGame.GameContent.Load<Texture2D>("Textures\\SaraFullSheet");
            Collection.CreateRectangleAnimtaion("up", 64, 64, 8, 0, 9, 1, 50);
            Collection.CreateRectangleAnimtaion("left", 64, 64, 9, 0, 9, 1, 50);
            Collection.CreateRectangleAnimtaion("down", 64, 64, 10, 0, 9, 1, 50);
            Collection.CreateRectangleAnimtaion("right", 64, 64, 11, 0, 9, 1, 50);

            Collection.CreateRectangleAnimtaion("standUp", 64, 64, 8, 0, 1, 1, 50);
            Collection.CreateRectangleAnimtaion("standLeft", 64, 64, 9, 0, 1, 1, 50);
            Collection.CreateRectangleAnimtaion("standDown", 64, 64, 10, 0, 1, 1, 50);
            Collection.CreateRectangleAnimtaion("standRight", 64, 64, 11, 0, 1, 1, 50);

            Collection.PlayAnimation("standDown");
        }

        public override void Update(GameTime gameTime)
        {
            Position += (acceleration * gameTime.ElapsedGameTime.Milliseconds) * 0.003f;
            acceleration = Vector2.Zero;
            Collection.UpdateAnimation(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Collection.CurrentAnimation != null)
            {
                BananaGame.GameSpriteBatch.Draw(Collection.AnimationAtlus, new Rectangle((int)drawPosition.X, (int)drawPosition.Y, 64, 64),
                    Collection.GetCurrentSourceRectangle(), Color.White);
            }
        }
    }
}
