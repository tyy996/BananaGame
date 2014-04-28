using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.Terrain
{
    public class Chunk : Dictionary2<Tile>
    {
        public const int SIZE = 64;

        public Vector2Int Position { get; private set; }
        public Vector2Int PositionInWorld { get { return new Vector2Int(Position.X * SIZE, Position.Z * SIZE); } }
        public BoundingBox Bounds { get { return new BoundingBox(new Vector3(Position.asVector2(), 0), new Vector3(Position.asVector2() + new Vector2(SIZE, SIZE), 0)); } }
        public ChunkState State { get; set; }

        public List<short> IndexList { get; set; }
        public List<VertexPositionNormalTexture> VertexList { get; set; }
        public short VertexCount { get; set; }
        public VertexBuffer VertexBuffer { get; set; }
        public IndexBuffer IndexBuffer { get; set; }

        public ShapeManager shapeM { get; set; }

        public Chunk(Vector2Int position)
        {
            this.Position = position;

            IndexList = new List<short>();
            VertexList = new List<VertexPositionNormalTexture>();

            shapeM = new ShapeManager();
        }

        public bool Add(Tile tile)
        {
            this[tile.Position.X, tile.Position.Z] = tile;
            return true;
        }

        #region Get
        public Tile Get(Vector2Int location)
        {
            Tile outval;
            if (TryGetValue(getLocalLocation(location), out outval))
                return outval;
            return null;
        }

        public bool Exists(Vector2Int location)
        {
            if (Get(location) != null)
                return true;
            else
                return false;
        }

        private Vector2Int getLocalLocation(Vector2Int location)
        {
            return location - PositionInWorld;
        }
        #endregion

        public void GraphicalClear()
        {
            VertexList.Clear();
            IndexList.Clear();

            VertexCount = 0;
        }
    }

    public enum ChunkState
    {
        Ready,
        NotSoReady
    }
}
