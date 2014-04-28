using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame
{
    public class FrameRateCounter
    {
        private TimeSpan elapsedTime;

        public int FrameRate;
        public int FrameCounter;

        public FrameRateCounter()
        {
            elapsedTime = TimeSpan.Zero;

            FrameRate = 0;
            FrameCounter = 0;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                FrameRate = FrameCounter;
                FrameCounter = 0;
            }
        }

        public void DrawTick()
        {
            FrameCounter++;

            //Framerates over 1000 aren't important as we have lots of room for features.
            if (FrameRate >= 1000)
            {
                FrameRate = 999;
            }
        }
    }
}
