using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//using BananaTheGame.Entities;
using BananaTheGame.Terrain;
using BananaTheGame.Controllers;

namespace BananaTheGame
{
    public enum DebugDrawState
    {
        None = 0,
        Player = 1,
        Chunk = 2,
    }

    public static class GameDebugger
    {
        private static FrameRateCounter frameRateCounter;

        public static SpriteFont DebugFont { get; private set; }
        public static DebugDrawState DrawState { get; set; }
        public static bool IsChunkBoundsDrawn { get; set; }
        public static bool DebugStopTrigger { get; set; }

        public static void Initialize()
        {
            frameRateCounter = new FrameRateCounter();

            DebugFont = BananaGame.GameContent.Load<SpriteFont>("Font//GameFont");
            //NoClip = true;
            //BananaGame.GamePlayer.PhysicsModel.AffectedByGravity = false;
            IsChunkBoundsDrawn = false; ;
            DrawState = DebugDrawState.Player;
            DebugStopTrigger = false;
        }

        public static void Update(GameTime gameTime)
        {
            frameRateCounter.Update(gameTime);
            debugInputUpdate();
        }

        //drawString(string.Format(""), new Vector2(0, 0)); //blank

        public static void Draw()
        {
            if (DrawState == DebugDrawState.None)
                return;

            switch (DrawState)
            {
                //case DebugDrawState.Player:
                //    drawPlayerMovementDebugText();
                //    break;
                //case DebugDrawState.Chunk:
                //    drawChunkDebugText();
                //    break;
            }
            frameRateCounter.DrawTick();
            drawFrameRate();
        }

        public static void TiggeredTestPeer()
        {
            if (DebugStopTrigger)
            {
                string joe = "Manily man in the world";
            }
        }

        public static void TestPeer()
        {
            string jack = "All work and no play makes Jack a dull boy";
        }

        private static void drawFrameRate()
        {
            drawString(frameRateCounter.FrameRate.ToString(), new Vector2(BananaGame.GameCamera.CameraViewPort.Width - 30, 0));
            //drawString(World.Loader.ToString(), new Vector2(BananaGame.GameCamera.CameraViewPort.Width - 20, 20));
        }

        private static void drawString(string text, Vector2 position)
        {
            BananaGame.GameSpriteBatch.DrawString(DebugFont, text, position, Color.Yellow);
        }

        private static void debugInputUpdate()
        {

            if (GameKeyState.IsKeyPressed(Keys.F3))
            {
                if ((int)DrawState == Enum.GetValues(typeof(DebugDrawState)).Length)
                    DrawState = DebugDrawState.None;
                else
                    DrawState++;
            }

            if (GameKeyState.IsKeyPressed(Keys.F4))
                IsChunkBoundsDrawn = !IsChunkBoundsDrawn;

            if (GameKeyState.IsKeyPressed(Keys.F12))
                DebugStopTrigger = !DebugStopTrigger;
        }
    }
}
