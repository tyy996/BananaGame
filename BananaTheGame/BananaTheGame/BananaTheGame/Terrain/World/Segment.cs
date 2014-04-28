using System;
using Microsoft.Xna.Framework;

using BananaTheGame.Control;

namespace BananaTheGame.Terrain
{
    public class Segment : Dictionary2<Chunk>
    {
        private SaveManager saveManager;

        public string LevelName { get; private set; }

        public Segment(string levelName)
        {
            LevelName = levelName;
            saveManager = new SaveManager(levelName);
        }
    }
}
