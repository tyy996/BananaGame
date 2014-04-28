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
    public class TestFightState : State
    {
        Player testHero1;
        Player testHero2;
        Player testHero3;

        //testEnemy

        Chunk chunk;
        SimpleRenderer renderer;
        TileHighlight highlight;

        public override void Load()
        {
            highlight = new TileHighlight(new Vector2(20, 20), Color.Blue);

            chunk = new Chunk(new Vector2Int(0, 0));
            renderer = new SimpleRenderer();
            chunk.State = ChunkState.NotSoReady;

            chunk.Add(new Tile(TileType.Floor, new Vector2Int(0, 0)));

            chunk.Add(new Tile(TileType.Floor, new Vector2Int(20, 20)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(21, 20)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(22, 20)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(20, 21)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(21, 21)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(22, 21)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(20, 22)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(21, 22)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(22, 22)));

            chunk.Add(new Tile(TileType.Wall, new Vector2Int(19, 20)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(19, 21)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(19, 22)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(23, 20)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(23, 22)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(23, 21)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(20, 19)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(21, 19)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(22, 19)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(20, 23)));

            //chunk.Add(new Tile(TileType.Wall, new Vector2Int(21, 23)));
            chunk.Add(new Tile(TileType.Floor, new Vector2Int(21, 23)));

            chunk.Add(new Tile(TileType.Wall, new Vector2Int(22, 23)));

            chunk.Add(new Tile(TileType.Wall, new Vector2Int(19, 19)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(19, 23)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(23, 19)));
            chunk.Add(new Tile(TileType.Wall, new Vector2Int(23, 23)));

            TileProcessor.Initialize();
            TileProcessor.Process(chunk);

            World.UpdateDayLight();

            BananaGame.GamePlayer = new Player();
            BananaGame.GamePlayer.Position = new Vector2(20, 20);
            BananaGame.GamePlayer.Load();
            ControllerManager.AddPlayer(BananaGame.GamePlayer);

            BananaGame.GameCamera.FollowTaget = true;
            BananaGame.GameCamera.Target = (BananaGame.GamePlayer);
            //GameCamera.TargetOffset = new Vector3(0.0f, 0f, 10f);
            BananaGame.GameCamera.TargetOffset = new Vector3(0.0f, 0f, 12f);
        }

        public override void Update(GameTime gameTime)
        {
            BananaGame.GamePlayer.Update(gameTime);
            if (GameKeyState.IsKeyPressed(Keys.U))
            {
                //GameMouseState.WP();
                Vector2Int blah = new Vector2Int(GameMouseState.WorldPosition());
                highlight = new TileHighlight(blah.asVector2(), Color.Blue);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            BananaGame.Graphics.SamplerStates[0] = SamplerState.PointWrap;

            renderer.RenderChunk(chunk);

            BananaGame.Graphics.BlendState = BlendState.NonPremultiplied;
            highlight.Draw();
        }

        public override void DrawSprite(GameTime gameTime)
        {
            BananaGame.GamePlayer.Draw(gameTime);
        }
    }
}
