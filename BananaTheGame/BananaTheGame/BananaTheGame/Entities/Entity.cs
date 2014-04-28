using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Entities
{
    public abstract class Entity
    {
        #region Feilds
        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;

        protected float movementSpeed;
        protected float jumpSpeed;

        protected BoundingBox hitbox;

        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public Vector2 Acceleration { get { return acceleration; } }

        //public BoundingBox Bounds { get { return new BoundingBox(position + hitbox.Min, position + hitbox.Max); } }
        #endregion

        public void AddAcceleration(Vector2 acceleration)
        {
            this.acceleration += acceleration;
        }

        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
