using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using BananaTheGame.AnimationG;
using BananaTheGame.Controllers;
using BananaTheGame.Entities;
using BananaTheGame.Terrain;
using BananaTheGame.Terrain.Generators;
using BananaTheGame.Terrain.Processor;
using BananaTheGame.Terrain.Renderer;

namespace BananaTheGame.Control
{
    public class TestFreeRoamState : State
    {
        #region TestCode
        Chunk chunk;
        TestTerrainGenerator generator;
        SimpleRenderer renderer;
        SaveManager saveManager;
        #endregion

        public override void Load()
        {
            generator = new TestTerrainGenerator();
            renderer = new SimpleRenderer();
            chunk = new Chunk(new Vector2Int(0, 0));
            chunk.State = ChunkState.NotSoReady;

            generator.Generate(chunk);
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 20)));
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 21)));
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 22)));
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 20)));
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 21)));
            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 22)));

            chunk.Add(new Tile(TileType.Wall, new Vector2Int(30, 30)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(31, 30)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(32, 30)));
            chunk.Add(new Tile(TileType.Door, new Vector2Int(33, 30)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(34, 30)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(35, 30)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(36, 30)));

            chunk.Add(new Tile(TileType.Wall, new Vector2Int(30, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(31, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(32, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(33, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(34, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(35, 31)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(36, 31)));
            //chunk.Add(new Tile(TileType.Door, new Vector2Int(20, 20)));
            TileProcessor.Initialize();
            TileProcessor.Process(chunk);

            World.UpdateDayLight();

            BananaGame.GamePlayer = new Player();
            BananaGame.GamePlayer.Load();
            ControllerManager.AddPlayer(BananaGame.GamePlayer);

            BananaGame.GameCamera.FollowTaget = true;
            BananaGame.GameCamera.Target = (BananaGame.GamePlayer);
            //GameCamera.TargetOffset = new Vector3(0.0f, 0f, 10f);
            BananaGame.GameCamera.TargetOffset = new Vector3(0.0f, 0f, 16f);
        }

        public override void Update(GameTime gameTime)
        {
            BananaGame.GamePlayer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            BananaGame.Graphics.SamplerStates[0] = SamplerState.PointWrap;

            renderer.RenderChunk(chunk);

            BananaGame.Graphics.BlendState = BlendState.NonPremultiplied;
        }

        public override void DrawSprite(GameTime gameTime)
        {
            BananaGame.GamePlayer.Draw(gameTime);
        }
    }
}
