using System;


namespace BananaTheGame.Terrain
{
    public class Tile
    {
        public Vector2Int Position { get; set; }
        public TileType Type { get; set; }
        public int Rotation { get; set; }

        public Tile(TileType type, Vector2Int position)
        {
            this.Type = type;
            this.Position = position;
        }
    }
}
