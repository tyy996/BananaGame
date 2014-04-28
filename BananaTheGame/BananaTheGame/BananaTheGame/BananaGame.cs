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
using BananaTheGame.Control;

namespace BananaTheGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BananaGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GraphicsDevice Graphics { get; private set; }
        public static ContentManager GameContent { get; private set; }
        public static Camera GameCamera { get; private set; }
        public static Player GamePlayer { get; set; } //change method of how this works
        public static SpriteBatch GameSpriteBatch { get; private set; }

        #region TestCode
        //Chunk chunk;
        //TestTerrainGenerator generator;
        //SimpleRenderer renderer;
        //SaveManager saveManager;
        TestFreeRoamState roamState;
        TestFightState fightState;
        #endregion

        public BananaGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //this.graphics.PreferredBackBufferWidth = 1600;
            //this.graphics.PreferredBackBufferHeight = 900;

            //this.graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            Graphics = graphics.GraphicsDevice;
            GameContent = Content;
            ControllerManager.Initialize();
            GameDebugger.Initialize();
            TextureHelper.Init();
            GameSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            TileHighlight.Initialize();
            roamState = new TestFreeRoamState();
            fightState = new TestFightState();
            StateManager.QueueState(fightState);
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GameCamera = new Camera();
            GameCamera.LeftRightRotation = -0.5f;
            GameCamera.UpDownRotation = -0.5f;

            World.DayLight = Color.White.ToVector3();
            World.TimeOfDay = 12f;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                World.TimeOfDay -= 0.5f;
                World.UpdateDayLight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                World.TimeOfDay += 0.5f;
                World.UpdateDayLight();
            }


            // TODO: Add your update logic here
            ControllerManager.Update();
            GameDebugger.Update(gameTime);

            GameCamera.Update(gameTime);
            StateManager.Update(gameTime);
            //GamePlayer.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap; 

            //GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            StateManager.Draw(gameTime);

            GameSpriteBatch.Begin();

            GameDebugger.Draw();
            GameCamera.Draw();
            StateManager.DrawSprite(gameTime);
            //GamePlayer.Draw(gameTime);
            GameSpriteBatch.End();

            // TODO: Add your drawing code here
            

            base.Draw(gameTime);
        }
    }
}
