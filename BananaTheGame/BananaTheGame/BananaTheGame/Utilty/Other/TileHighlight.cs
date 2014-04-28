using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame
{
    public class TileHighlight
    {
        private const int DEFAULT_TILE_SIZE = 1;
        private VertexPositionColor[] verts;

        private static BasicEffect highlightEffect;
        private static short[] indexData;

        public TileHighlight()
        {
        }

        public TileHighlight(Vector2 position, Color color)
        {
            Load(position, color);
        }

        public void Load(Vector2 position, Color color)
        {
            verts = new VertexPositionColor[4];

            Vector3 min = new Vector3(position, 0);
            Vector3 max = min + new Vector3(new Vector2(DEFAULT_TILE_SIZE, DEFAULT_TILE_SIZE), 0);

            verts[0] = new VertexPositionColor(min, color);
            verts[1] = new VertexPositionColor(new Vector3(max.X, min.Y, 0), color);
            verts[2] = new VertexPositionColor(new Vector3(min.X, max.Y, 0), color);
            verts[3] = new VertexPositionColor(new Vector3(max.X, max.Y, 0), color);
        }

        public void Draw()
        {
            BananaGame.Graphics.RasterizerState = RasterizerState.CullClockwise;


            highlightEffect.View = BananaGame.GameCamera.View;
            highlightEffect.Projection = BananaGame.GameCamera.Projection;

            foreach (EffectPass pass in highlightEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                BananaGame.Graphics.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verts, 0, verts.Length, indexData, 0, indexData.Length / 3);
            }
        }

        public static void Initialize()
        {
            highlightEffect = new BasicEffect(BananaGame.Graphics);
            highlightEffect.VertexColorEnabled = true;
            highlightEffect.LightingEnabled = false;
            highlightEffect.Alpha = 0.8f;

            indexData = new short[] { 0, 1, 3, 0, 3, 2 };
        }
    }
}
