using System;
using Microsoft.Xna.Framework;

using BananaTheGame.Control;
using BananaTheGame.Terrain.Renderer;

namespace BananaTheGame.Terrain
{
    public class Segment : Dictionary2<Chunk>
    {
        private SaveManager saveManager;
        private SimpleRenderer renderer;

        public string LevelName { get; private set; }

        public static LevelLoader Loader { get; private set; } //loader should contain saveManager

        public Segment(string levelName)
        {
            LevelName = levelName;
            saveManager = new SaveManager(levelName);
            renderer = new SimpleRenderer();
        }

        public void LoadArea(Vector2Int origen)
        {
            Vector2Int upperLocation = origen + new Vector2Int(-1, -1);

            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Vector2Int location = upperLocation + new Vector2Int(x, z);
                    Chunk chunk = saveManager.LoadChunk(location);
                    this[location.X, location.Z] = chunk;
                    Loader.AddRequest(chunk);
                }
            }
        }

        public void DrawSegment()
        {
            renderer.RenderChunks(this);
        }

        public static void Initialize()
        {
            Loader = new LevelLoader();
        }
    }
}
