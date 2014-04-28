//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;

//using BananaTheGame.AnimationG;
//using BananaTheGame.Controllers;
//using BananaTheGame.Entities;
//using BananaTheGame.Terrain;
//using BananaTheGame.Terrain.Generators;
//using BananaTheGame.Terrain.Processor;
//using BananaTheGame.Terrain.Renderer;
//using BananaTheGame.Control;

//namespace BananaTheGame
//{
//    /// <summary>
//    /// This is the main type for your game
//    /// </summary>
//    public class BananaGame : Microsoft.Xna.Framework.Game
//    {
//        GraphicsDeviceManager graphics;
//        SpriteBatch spriteBatch;

//        public static GraphicsDevice Graphics { get; private set; }
//        public static ContentManager GameContent { get; private set; }
//        public static Camera GameCamera { get; private set; }
//        public static Player GamePlayer { get; set; } //change method of how this works
//        public static SpriteBatch GameSpriteBatch { get; private set; }

//        #region TestCode
//        Chunk chunk;
//        TestTerrainGenerator generator;
//        SimpleRenderer renderer;
//        SaveManager saveManager;
//        #endregion

//        public BananaGame()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//            this.graphics.PreferredBackBufferWidth = 1600;
//            this.graphics.PreferredBackBufferHeight = 900;

//            this.graphics.IsFullScreen = true;
//        }

//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize()
//        {
//            // TODO: Add your initialization logic here

//            Graphics = graphics.GraphicsDevice;
//            GameContent = Content;
//            ControllerManager.Initialize();
//            GameDebugger.Initialize();
//            TextureHelper.Init();
//            GameSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent()
//        {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            // TODO: use this.Content to load your game content here
//            GameCamera = new Camera();
//            GameCamera.LeftRightRotation = -0.5f;
//            GameCamera.UpDownRotation = -0.5f;

//            World.DayLight = Color.White.ToVector3();
//            World.TimeOfDay = 12f;

//            generator = new TestTerrainGenerator();
//            renderer = new SimpleRenderer();
//            chunk = new Chunk(new Vector2Int(0, 0));
//            chunk.State = ChunkState.NotSoReady;


//            generator.Generate(chunk);
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 20)));
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 21)));
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(20, 22)));
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 20)));
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 21)));
//            chunk.Add(new Tile(TileType.Dirt, new Vector2Int(21, 22)));

//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(30, 30)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(31, 30)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(32, 30)));
//            chunk.Add(new Tile(TileType.Door, new Vector2Int(33, 30)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(34, 30)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(35, 30)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(36, 30)));

//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(30, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(31, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(32, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(33, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(34, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(35, 31)));
//            chunk.Add(new Tile(TileType.Wall, new Vector2Int(36, 31)));
//            //chunk.Add(new Tile(TileType.Door, new Vector2Int(20, 20)));
//            TileProcessor.Initialize();
//            TileProcessor.Process(chunk);

//            //SaveManager.SaveChunk(chunk);
//            //chunk = SaveManager.LoadChunk(0, 0);
//            //chunk.State = ChunkState.NotSoReady;
//            //TileProcessor.Process(chunk);
//            World.UpdateDayLight();

//            GamePlayer = new Player();
//            GamePlayer.Load();
//            ControllerManager.AddPlayer(GamePlayer);

//            GameCamera.FollowTaget = true;
//            GameCamera.Target = (GamePlayer);
//            //GameCamera.TargetOffset = new Vector3(0.0f, 0f, 10f);
//            GameCamera.TargetOffset = new Vector3(0.0f, 0f, 16f);
//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// all content.
//        /// </summary>
//        protected override void UnloadContent()
//        {
//            // TODO: Unload any non ContentManager content here
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime)
//        {
//            // Allows the game to exit
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
//                this.Exit();

//            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
//                this.Exit();

//            if (Keyboard.GetState().IsKeyDown(Keys.F))
//            {
//                World.TimeOfDay -= 0.5f;
//                World.UpdateDayLight();
//            }

//            if (Keyboard.GetState().IsKeyDown(Keys.G))
//            {
//                World.TimeOfDay += 0.5f;
//                World.UpdateDayLight();
//            }


//            // TODO: Add your update logic here
//            ControllerManager.Update();
//            GameDebugger.Update(gameTime);

//            GameCamera.Update(gameTime);
//            GamePlayer.Update(gameTime);

//            base.Update(gameTime);
//        }

//        /// <summary>
//        /// This is called when the game should draw itself.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.CornflowerBlue);

//            GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;

//            renderer.RenderChunk(chunk);

//            GraphicsDevice.BlendState = BlendState.NonPremultiplied;

//            GameSpriteBatch.Begin();

//            GameDebugger.Draw();
//            GameCamera.Draw();
//            GamePlayer.Draw(gameTime);
//            GameSpriteBatch.End();

//            // TODO: Add your drawing code here


//            base.Draw(gameTime);
//        }
//    }
//}
