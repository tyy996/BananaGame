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
        SimpleRenderer renderer;

        public override void Load()
        {
            chunk = new Chunk(Vector2Int.Zero);
            renderer = new SimpleRenderer();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public override void DrawSprite(GameTime gameTime)
        {
            
        }
    }
}
