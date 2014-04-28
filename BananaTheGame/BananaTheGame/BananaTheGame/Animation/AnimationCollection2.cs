using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.AnimationG
{
    public class AnimationCollection2
    {
        private TimeSpan timer;

        public Texture2D AnimationAtlus { get; set; }
        public Dictionary<string, Animation2> Collection { get; private set; }
        public Animation2 CurrentAnimation { get; private set; }
        public string CurrentAnimationName { get; private set; }
        public int CurrentFrame { get; set; }

        public AnimationCollection2()
        {
            Collection = new Dictionary<string, Animation2>();
            CurrentFrame = 0;
        }

        public void AddAnimation(string name, Animation2 animation)
        {
            if (!Collection.ContainsKey(name))
            {
                Collection.Add(name, animation);
            }
        }

        public void CreateRectangleAnimtaion(string name, int frameWidth, int frameHeight, int rowStart, int columnStart,
            int animationWidth, int animationHeight, double frameRate)
        {
            Animation2 animationNew = new Animation2();

            for (int row = rowStart; row < rowStart + animationHeight; row++)
            {
                for (int column = columnStart; column < columnStart + animationWidth; column++)
                {
                    animationNew.Slides.Add(new Rectangle(column * frameWidth, row * frameHeight,
                        frameWidth, frameHeight));
                }
            }

            animationNew.Framerate = frameRate;
            AddAnimation(name, animationNew);
        }

        public void PlayAnimation(string name)
        {
            CurrentAnimationName = name;
            CurrentAnimation = Collection[name];
            CurrentFrame = 0;
        }

        //puase

        //stop

        public void UpdateAnimation(GameTime gameTime)
        {
            if (CurrentAnimation != null)
            {
                timer += (gameTime.ElapsedGameTime);

                if (timer >= TimeSpan.FromMilliseconds(CurrentAnimation.Framerate))// + masterFramerate))
                {
                    CurrentFrame++;
                    if (CurrentFrame > CurrentAnimation.Slides.Count - 1)
                        CurrentFrame = 0;
                    timer = TimeSpan.Zero;
                }
            }
        }

        public Rectangle GetCurrentSourceRectangle()
        {
            return CurrentAnimation.Slides[CurrentFrame];
        }
    }
}
