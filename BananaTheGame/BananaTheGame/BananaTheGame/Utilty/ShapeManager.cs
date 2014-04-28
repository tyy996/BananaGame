using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.Terrain
{
    public class ShapeManager
    {
        public List<short> IndexList { get; set; }
        //public List<VertexPositionTextureLight> VertexList { get; set; }
        //public List<VertexPositionNormalTexture> VertexList { get; set; }

        public List<VertexPositionColorTextureNormal> VertexList { get; set; }

        public short VertexCount { get; set; }

        public ShapeManager()
        {
            IndexList = new List<short>();
            //VertexList = new List<VertexPositionTextureLight>();
            //VertexList = new List<VertexPositionNormalTexture>();

            VertexList = new List<VertexPositionColorTextureNormal>();
        }

        public void Clear()
        {
            VertexList.Clear();
            IndexList.Clear();

            VertexCount = 0;
        }

        public void Process(Chunk chunk)
        {
            //VertexPositionTextureLight[] v = VertexList.ToArray();
            //VertexPositionNormalTexture[] v = VertexList.ToArray();

            VertexPositionColorTextureNormal[] v = VertexList.ToArray();

            short[] i = IndexList.ToArray();

            if (v.Length > 0)
            {
                //chunk.VertexBuffer = new VertexBuffer(BananaGame.Graphics, typeof(VertexPositionTextureLight), v.Length, BufferUsage.None);
                //chunk.VertexBuffer = new VertexBuffer(BananaGame.Graphics, typeof(VertexPositionNormalTexture), v.Length, BufferUsage.None);

                chunk.VertexBuffer = new VertexBuffer(BananaGame.Graphics, typeof(VertexPositionColorTextureNormal), v.Length, BufferUsage.None);
                chunk.VertexBuffer.SetData(v);
                chunk.IndexBuffer = new IndexBuffer(BananaGame.Graphics, IndexElementSize.SixteenBits, i.Length, BufferUsage.None);
                chunk.IndexBuffer.SetData(i);
            }

            Clear();
            chunk.State = ChunkState.Ready;
        }

        //public void BuildTriangle(Vector3 point1, Vector3 point2, Vector3 point3)
        //{
        //    int direction = 0;
        //    BlockTexture texture = TextureHelper.GetTexture(BlockTexture.Grass, (BlockFaceDirection)direction, BlockTexture.None);
        //    int faceIndex = (int)direction;
        //    Vector2[] UVList = TextureHelper.UVMappings[(int)texture * 6 + faceIndex];

        //    float light = 0f;
        //    Color color = Color.White;

        //    addVertex(point1, UVList[0], light, color);
        //    addVertex(point2, UVList[1], light, color);
        //    addVertex(point3, UVList[2], light, color);
        //    addIndex(0, 1, 2);
        //}

        public void BuildFace(BlockCorners corners, TileType type)
        {
            //BlockTexture texture = TextureHelper.GetTexture(type, (BlockFaceDirection)direction, BlockTexture.None);
            //int faceIndex = (int)direction;
            //Vector2[] UVList = TextureHelper.UVMappings[(int)texture * 6 + faceIndex];

            float light = 0.5f;
            Color color = Color.White;

            //addVertex(corners.BackUpperLeft, new Vector2(0.0f, 0.0f), light, color);
            //addVertex(corners.FrontUpperLeft, new Vector2(1.0f, 0.0f), light, color);
            //addVertex(corners.BackLowerLeft, new Vector2(0.0f, 1.0f), light, color);
            //addVertex(corners.FrontLowerLeft, new Vector2(1.0f, 1.0f), light, color);

            //addIndex(0, 1, 2, 2, 1, 3);
            //addIndex(0, 1, 3, 0, 3, 2);

            Vector2[] textureMapping = TextureHelper.GetCoordinates(type);

            addVertex(corners.FrontUpperRight, textureMapping[0], light, color);
            addVertex(corners.BackUpperRight, textureMapping[1], light, color);
            addVertex(corners.FrontLowerRight, textureMapping[2], light, color);
            addVertex(corners.BackLowerRight, textureMapping[3], light, color);

            //addVertex(corners.FrontUpperRight, new Vector2(0.0f, 0.0f), light, color);
            //addVertex(corners.BackUpperRight, new Vector2(1.0f, 0.0f), light, color);
            //addVertex(corners.FrontLowerRight, new Vector2(0.0f, 1.0f), light, color);
            //addVertex(corners.BackLowerRight, new Vector2(1.0f, 1.0f), light, color);

            addIndex(0, 1, 3, 0, 3, 2);
        }

        public void BuildFace(BlockCorners corners, TextureList texture, int rotation)
        {
            float light = 0.5f;
            Color color = Color.White;

            Vector2[] textureMapping = TextureHelper.RequestTexture(texture, rotation);

            addVertex(corners.FrontUpperRight, textureMapping[0], light, color);
            addVertex(corners.BackUpperRight, textureMapping[1], light, color);
            addVertex(corners.FrontLowerRight, textureMapping[2], light, color);
            addVertex(corners.BackLowerRight, textureMapping[3], light, color);

            addIndex(0, 1, 3, 0, 3, 2);
        }

        private void addVertex(Vector3 point, Vector2 uv1, float sunLight, Color localLight)
        {
            //VertexList.Add(new VertexPositionTextureLight(point, uv1, sunLight, localLight.ToVector3()));
            //VertexList.Add(new VertexPositionNormalTexture(point, Vector3.Forward, uv1));

            VertexList.Add(new VertexPositionColorTextureNormal(point, localLight, uv1, Vector3.Forward));
        }

        private void addIndex(short i1, short i2, short i3, short i4, short i5, short i6)
        {
            IndexList.Add((short)(VertexCount + i1));
            IndexList.Add((short)(VertexCount + i2));
            IndexList.Add((short)(VertexCount + i3));
            IndexList.Add((short)(VertexCount + i4));
            IndexList.Add((short)(VertexCount + i5));
            IndexList.Add((short)(VertexCount + i6));
            VertexCount += 4;
        }

        private void addIndex(short i1, short i2, short i3)
        {
            IndexList.Add((short)(VertexCount + i1));
            IndexList.Add((short)(VertexCount + i2));
            IndexList.Add((short)(VertexCount + i3));
            VertexCount += 3;
        }
    }

    public struct BlockCorners
    {
        private Vector3 frontUpperLeft;
        private Vector3 frontUpperRight;
        private Vector3 frontLowerLeft;
        private Vector3 frontLowerRight;

        private Vector3 backUpperLeft;
        private Vector3 backUpperRight;
        private Vector3 backLowerLeft;
        private Vector3 backLowerRight;

        public Vector3 FrontUpperLeft { get { return frontUpperLeft; } set { frontUpperLeft = value; } }
        public Vector3 FrontUpperRight { get { return frontUpperRight; } set { frontUpperRight = value; } }
        public Vector3 FrontLowerLeft { get { return frontLowerLeft; } set { frontLowerLeft = value; } }
        public Vector3 FrontLowerRight { get { return frontLowerRight; } set { frontLowerRight = value; } }

        public Vector3 BackUpperLeft { get { return backUpperLeft; } set { backUpperLeft = value; } }
        public Vector3 BackUpperRight { get { return backUpperRight; } set { backUpperRight = value; } }
        public Vector3 BackLowerLeft { get { return backLowerLeft; } set { backLowerLeft = value; } }
        public Vector3 BackLowerRight { get { return backLowerRight; } set { backLowerRight = value; } }

        public BlockCorners(Vector3 startPoint, Vector3 endPoint)
        {
            frontLowerLeft = new Vector3(startPoint.X, startPoint.Y, startPoint.Z);
            frontLowerRight = new Vector3(startPoint.X, startPoint.Y, endPoint.Z);
            frontUpperLeft = new Vector3(startPoint.X, endPoint.Y, startPoint.Z);
            frontUpperRight = new Vector3(startPoint.X, endPoint.Y, endPoint.Z);

            backLowerLeft = new Vector3(endPoint.X, startPoint.Y, startPoint.Z);
            backLowerRight = new Vector3(endPoint.X, startPoint.Y, endPoint.Z);
            backUpperLeft = new Vector3(endPoint.X, endPoint.Y, startPoint.Z);
            backUpperRight = new Vector3(endPoint.X, endPoint.Y, endPoint.Z);
        }
    }
}
