using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;

using BananaTheGame.Terrain;

namespace BananaTheGame.Control
{
    public class SaveManager
    {
        private const string BLANK_SEGMENT_PATH = "Lib\\Worlds\\{0}\\Chunks";
        private const string SEGMENT_FORMAT = "\\Chunk{0},{1}.tyy";

        private static string segmentsPath;

        public static string WorldName { get; private set; }

        public SaveManager(string worldName)
        {
            WorldName = worldName;
        }

        public void SaveChunk(Chunk chunk)
        {
            validateIntegrity();
            string filePath = string.Format(segmentsPath + SEGMENT_FORMAT, chunk.Position.X, chunk.Position.Z);

            Stream stream = File.Open(filePath, FileMode.OpenOrCreate);

            for (int x = 0; x < Chunk.SIZE; x++)
            {
                for (int z = 0; z < Chunk.SIZE; z++)
                {
                    Tile tile = chunk.Get(new Vector2Int(x, z) + chunk.PositionInWorld);
                    if (tile != null)
                        stream.WriteByte((byte)tile.Type);
                }
            }

            stream.Close();
        }

        public Chunk LoadChunk(Vector2Int location)
        {
            return LoadChunk(location.X, location.Z);
        }

        public Chunk LoadChunk(int x, int z)
        {
            validateIntegrity();
            Chunk blank = new Chunk(new Vector2Int(x, z));
            byte[] level = File.ReadAllBytes(string.Format(segmentsPath + SEGMENT_FORMAT, x, z));

            for (int seg = 0; seg < level.Length; seg++)
            {
                int row = seg % Chunk.SIZE;
                int column = seg / Chunk.SIZE;
                blank.Add(new Tile((TileType)level[seg], blank.PositionInWorld + new Vector2Int(row, column)));
            }

            return blank;
        }

        public bool CheckIfSegementExists(int x, int z)
        {
            validateIntegrity();
            return File.Exists(string.Format(segmentsPath + SEGMENT_FORMAT, x, z));
        }

        private void validateIntegrity()
        {
            if (segmentsPath == "" || segmentsPath == null)
            {
                if (WorldName == "")
                    WorldName = "NewWorld";

                segmentsPath = string.Format(BLANK_SEGMENT_PATH, WorldName);

                if (!Directory.Exists(segmentsPath))
                    Directory.CreateDirectory(segmentsPath);
            }
        }
    }
}
