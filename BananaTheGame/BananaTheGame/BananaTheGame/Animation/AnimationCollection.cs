using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.AnimationG
{
    public class AnimationCollection
    {
        private Animation[] animationList;
        private int currentAnimation;

        public string[] AnimationNames { get; private set; }
        public double MasterFramerate { get; set; }

        public AnimationCollection(int animationAmount)
        {
            animationList = new Animation[animationAmount + 1];
            AnimationNames = new string[animationAmount + 1];

            animationList[0] = AnimationCollection.NullImage();
            AnimationNames[0] = "NL";
            MasterFramerate = 0;
        }

        public void AddAnimation(Animation animation, string animationName)
        {
            if (AnimationNames.Contains(animationName))
            {
                throw new Exception(string.Format("Animation by given name \"&1\" already exist.", animationName));
            }

            for (int index = 1; index < animationList.Length; index++)
            {
                if (animationList[index] == null)
                {
                    animationList[index] = animation;
                    AnimationNames[index] = animationName;
                    return;
                }
            }


            throw new IndexOutOfRangeException(string.Format("Animation \"&1\" was out of range of the specified amount.", animationName));
        }

        public void SwitchAnimation(string animationName)
        {
            if (AnimationNames.Contains(animationName))
            {
                currentAnimation = Array.IndexOf(AnimationNames, animationName);
            }
            else
            {
                currentAnimation = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            animationList[currentAnimation].UpdateSlide(gameTime, MasterFramerate);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color, float rotation)
        {
            animationList[currentAnimation].DrawCurrentSlide(spriteBatch, destinationRectangle, color, rotation);
        }

        #region NullStaticImage
        private static Animation nullImage;
        public static Texture2D NullTexture { get; private set; }

        public static void SetNullImage(Texture2D image)
        {
            nullImage = new Animation("Null", image, image.Width, image.Height, 1, 1, 30);
            NullTexture = image;
        }

        public static Animation NullImage()
        {
            return nullImage;
        }
        #endregion
    }
}
