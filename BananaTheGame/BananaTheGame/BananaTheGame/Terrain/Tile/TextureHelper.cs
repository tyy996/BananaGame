using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Terrain
{
    public static class TextureHelper
    {
        public const int ATLAS_SIZE = 16;

        private static Random randomGrass; //test code
        private static Dictionary<TileType, TextureList[]> quickTexture;

        public static void Init()
        {
            randomGrass = new Random();
            quickTexture = new Dictionary<TileType, TextureList[]>();
            quickTexture.Add(TileType.Grass, new TextureList[] { TextureList.Grass, TextureList.GrassRed, TextureList.GrassBlue });
            quickTexture.Add(TileType.Dirt, new TextureList[] { TextureList.Dirt });
            quickTexture.Add(TileType.Door, new TextureList[] { TextureList.ClosedDoor });
            quickTexture.Add(TileType.Wall, new TextureList[] { TextureList.BrickWall });
            quickTexture.Add(TileType.Floor, new TextureList[] { TextureList.BrickFloor });
        }

        public static Vector2[] GetCoordinates(TileType type)
        {
            Vector2[] UVList = new Vector2[4];

            int textureIndex = (int)quickTexture[type][randomGrass.Next(0, quickTexture[type].Length)];

            int y = textureIndex / ATLAS_SIZE;
            int x = textureIndex % ATLAS_SIZE;

            float ofs = 1f / ((float)ATLAS_SIZE);

            float yOfs = y * ofs;
            float xOfs = x * ofs;

            UVList[0] = new Vector2(xOfs, yOfs);                // 0,0
            UVList[1] = new Vector2(xOfs + ofs, yOfs);          // 1,0
            UVList[2] = new Vector2(xOfs, yOfs + ofs);          // 0,1
            UVList[3] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1

            return UVList;
        }

        public static Vector2[] RequestTexture(TextureList texture, int rotation)
        {
            Vector2[] UVList = new Vector2[4];

            int y = (int)texture / ATLAS_SIZE;
            int x = (int)texture % ATLAS_SIZE;

            float ofs = 1f / ((float)ATLAS_SIZE);

            float yOfs = y * ofs;
            float xOfs = x * ofs;

            switch (rotation)
            {
                case 1:
                    UVList[1] = new Vector2(xOfs, yOfs);                // 0,0
                    UVList[3] = new Vector2(xOfs + ofs, yOfs);          // 1,0
                    UVList[0] = new Vector2(xOfs, yOfs + ofs);          // 0,1
                    UVList[2] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1
                    break;
                case  2:
                    UVList[3] = new Vector2(xOfs, yOfs);                // 0,0
                    UVList[2] = new Vector2(xOfs + ofs, yOfs);          // 1,0
                    UVList[1] = new Vector2(xOfs, yOfs + ofs);          // 0,1
                    UVList[0] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1
                    break;
                case 3:
                    UVList[2] = new Vector2(xOfs, yOfs);                // 0,0
                    UVList[0] = new Vector2(xOfs + ofs, yOfs);          // 1,0
                    UVList[3] = new Vector2(xOfs, yOfs + ofs);          // 0,1
                    UVList[1] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1
                    break;
                default:
                    UVList[0] = new Vector2(xOfs, yOfs);                // 0,0
                    UVList[1] = new Vector2(xOfs + ofs, yOfs);          // 1,0
                    UVList[2] = new Vector2(xOfs, yOfs + ofs);          // 0,1
                    UVList[3] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1
                    break;
        }

            return UVList;
        }

        //public static Vector2[] GetCoordinates(TileType type, TileType northType, TileType southType, TileType eastType, TileType westType)
        //{
        //    Vector2[] UVList = new Vector2[4];

        //    int textureIndex = (int)type;

        //    int y = textureIndex / ATLAS_SIZE;
        //    int x = textureIndex % ATLAS_SIZE;

        //    float ofs = 1f / ((float)ATLAS_SIZE);

        //    float yOfs = y * ofs;
        //    float xOfs = x * ofs;

        //    UVList[0] = new Vector2(xOfs, yOfs);                // 0,0
        //    UVList[1] = new Vector2(xOfs + ofs, yOfs);          // 1,0
        //    UVList[2] = new Vector2(xOfs, yOfs + ofs);          // 0,1
        //    UVList[3] = new Vector2(xOfs + ofs, yOfs + ofs);    // 1,1

        //    return UVList;
        //}
    }

    public enum TextureList
    {
        Grass,
        GrassRed,
        GrassBlue,
        Dirt,
        HalfDirt,
        CornerDirt,
        ClosedDoor,
        OpenedDoor,
        BrickWall,
        BrickFloor
    }
}
