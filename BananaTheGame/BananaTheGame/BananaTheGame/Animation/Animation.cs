using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.AnimationG
{
    public class Animation
    {
        private Texture2D animationTexture;
        private Vector2 currentSlide;
        private double framerate;
        private TimeSpan timer;

        public string Name { get; private set; }
        public int SlideWidth { get; private set; }
        public int SlideHeight { get; private set; }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }
        public int SlideCount { get; private set; }

        public Animation()
        {
            animationTexture = AnimationCollection.NullTexture;
            currentSlide = Vector2.Zero;
            framerate = 0;
            timer = TimeSpan.Zero;
            SlideWidth = 0;
            SlideHeight = 0;
            RowCount = 1;
            ColumnCount = 1;
            SlideCount = 1;
        }

        public Animation(string name, Texture2D texture, int slideWidth, int slideHeight, int rowAmount, int columnAmount, int framerate)
        {
            this.Name = name;
            this.animationTexture = texture;
            this.SlideWidth = slideWidth;
            this.SlideHeight = slideHeight;
            this.RowCount = rowAmount;
            this.ColumnCount = columnAmount;
            this.framerate = framerate;

            this.timer = TimeSpan.Zero;
            this.SlideCount = rowAmount * columnAmount;
            this.currentSlide = Vector2.Zero;
        }

        public void UpdateSlide(GameTime gameTime, double masterFramerate)
        {
            timer += (gameTime.ElapsedGameTime);

            if (timer >= TimeSpan.FromMilliseconds(framerate + masterFramerate))
            {
                switchSlides();
                timer = TimeSpan.Zero;
            }
        }

        public void DrawCurrentSlide(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color, float rotation)
        {
            Vector2 slidePostion = new Vector2(SlideWidth * (int)currentSlide.X, SlideHeight * (int)currentSlide.Y);
            Rectangle slideSourceRectangle = new Rectangle((int)slidePostion.X, (int)slidePostion.Y, SlideWidth, SlideHeight);
            spriteBatch.Draw(animationTexture, destinationRectangle, slideSourceRectangle, color, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

        private void switchSlides()
        {
            currentSlide.X++;

            if (currentSlide.X > RowCount - 1)
            {
                currentSlide.X = 0;
                currentSlide.Y++;
            }
            if (currentSlide.Y > ColumnCount - 1)
            {
                currentSlide.X = 0;
                currentSlide.Y = 0;
            }
        }
    }
}
