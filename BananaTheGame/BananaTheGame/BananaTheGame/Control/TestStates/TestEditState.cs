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
    public class TestEditState : State
    {
        Chunk chunk;
        TestTerrainGenerator gen;
        //SimpleRenderer renderer;
        SaveManager saveManager;

        Segment segment;
        //SimpleRenderer renderer;

        public override void Load()
        {
            //gen = new TestTerrainGenerator();
            //chunk = new Chunk(Vector2Int.Zero);
            //renderer = new SimpleRenderer();
            //saveManager = new SaveManager("TestWorld");

            //gen.Generate(chunk);
            //saveManager.SaveChunk(chunk);

            segment = new Segment("TestWorld");
            segment.LoadArea(Vector2Int.Zero);

            World.UpdateDayLight();

            BananaGame.GamePlayer = new Player();
            BananaGame.GamePlayer.Load();
            ControllerManager.AddPlayer(BananaGame.GamePlayer);

            BananaGame.GameCamera.FollowTaget = true;
            BananaGame.GameCamera.Target = (BananaGame.GamePlayer);
            //GameCamera.TargetOffset = new Vector3(0.0f, 0f, 10f);
            BananaGame.GameCamera.TargetOffset = new Vector3(0.0f, 0f, 16f);
            //renderer = new SimpleRenderer();
        }

        public override void Update(GameTime gameTime)
        {
            BananaGame.GamePlayer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            BananaGame.Graphics.SamplerStates[0] = SamplerState.PointWrap;

            segment.DrawSegment();

            //renderer.RenderChunk(chunk);

            BananaGame.Graphics.BlendState = BlendState.NonPremultiplied;
        }

        public override void DrawSprite(GameTime gameTime)
        {
            BananaGame.GamePlayer.Draw(gameTime);
        }
    }
}
