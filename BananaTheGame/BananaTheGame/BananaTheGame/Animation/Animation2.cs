using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.AnimationG
{
    public class Animation2
    {
        public List<Rectangle> Slides { get; set; }
        public double Framerate;

        public Animation2()
        {
            Slides = new List<Rectangle>();
            Framerate = 0;
        }
    }
}
