using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.Terrain.Processor
{
    public static class TileProcessor
    {
        public static void Initialize()
        {
        }

        public static void Process(Chunk chunk)
        {
            foreach (Tile tile in chunk.Values)
            {
                //processTile(chunk, tile);
                if (tile.Type == TileType.Grass)
                {
                    Tile northTile = chunk.Get(tile.Position + new Vector2Int(0, 1));
                    Tile southTile = chunk.Get(tile.Position + new Vector2Int(0, -1));
                    Tile eastTile = chunk.Get(tile.Position + new Vector2Int(-1, 0));
                    Tile westTile = chunk.Get(tile.Position + new Vector2Int(1, 0));///bug; only check inside chunk;

                    if (northTile != null && northTile.Type == TileType.Dirt)
                    {
                        chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), TextureList.HalfDirt, 1);
                        tile.Rotation = 1;
                    }
                    else if (southTile != null && southTile.Type == TileType.Dirt)
                    {
                        chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), TextureList.HalfDirt, 3);
                        tile.Rotation = 3;
                    }
                    else if (westTile != null && westTile.Type == TileType.Dirt) //bug; no corner check
                    {
                        chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), TextureList.HalfDirt, 2);
                        tile.Rotation = 2;
                    }
                    else if (eastTile != null && eastTile.Type == TileType.Dirt)
                    {
                        chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), TextureList.HalfDirt, 0);
                        tile.Rotation = 0;
                    }
                    else
                    {
                        chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), tile.Type);
                    }
                }
                else
                {
                    chunk.shapeM.BuildFace(new BlockCorners(new Vector3(tile.Position.asVector2(), 0),
                        new Vector3(tile.Position.asVector2() + new Vector2(1, 1), 0)), tile.Type);
                }
            }

            //VertexPositionNormalTexture[] v = chunk.VertexList.ToArray();
            //short[] i = chunk.IndexList.ToArray();

            //if (v.Length > 0)
            //{
            //    chunk.VertexBuffer = new VertexBuffer(BananaGame.Graphics, typeof(VertexPositionNormalTexture), v.Length, BufferUsage.None);
            //    chunk.VertexBuffer.SetData(v);
            //    chunk.IndexBuffer = new IndexBuffer(BananaGame.Graphics, IndexElementSize.SixteenBits, i.Length, BufferUsage.None);
            //    chunk.IndexBuffer.SetData(i);
            //}

            //chunk.GraphicalClear();
            //chunk.State = ChunkState.Ready;
        }

        private static void processTile(Chunk chunk, Tile tile)
        {
            chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(tile.Position.X, tile.Position.Z, 0), Vector3.Forward, new Vector2(0.0f, 1.0f))); //Lower Left
            chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(tile.Position.X, tile.Position.Z + 1, 0), Vector3.Forward, new Vector2(0.0f, 0.0f))); //Upper Left
            chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(tile.Position.X + 1, tile.Position.Z, 0), Vector3.Forward, new Vector2(1.0f, 1.0f))); //Lower Right
            chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(tile.Position.X + 1, tile.Position.Z + 1, 0), Vector3.Forward, new Vector2(1.0f, 0.0f))); //Upper Right

            //chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(-1, -1, 0), Vector3.Forward, new Vector2(0.0f, 1.0f))); //Lower Left
            //chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(-1, 1, 0), Vector3.Forward, new Vector2(0.0f, 0.0f))); //Upper Left
            //chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(1, -1, 0), Vector3.Forward, new Vector2(1.0f, 1.0f))); //Lower Right
            //chunk.VertexList.Add(new VertexPositionNormalTexture(new Vector3(1, 1, 0), Vector3.Forward, new Vector2(1.0f, 0.0f))); //Upper Right

            chunk.IndexList.Add(0);
            chunk.IndexList.Add(1);
            chunk.IndexList.Add(2);
            chunk.IndexList.Add(2);
            chunk.IndexList.Add(1);
            chunk.IndexList.Add(3);

            chunk.VertexCount += 2;
        }
    }
}
