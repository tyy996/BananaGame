using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame.Terrain.Renderer
{
    public class SimpleRenderer
    {
        private Texture2D textureAtlas;
        //private Effect tileEffect;
        private BasicEffect tileEffect;

        public SimpleRenderer()
        {
            //textureAtlas = BananaGame.GameContent.Load<Texture2D>("Textures\\Dirt1");
            //textureAtlas = BananaGame.GameContent.Load<Texture2D>("Textures\\BlockAtlusTest3");
            textureAtlas = BananaGame.GameContent.Load<Texture2D>("Textures\\BananaAtlus2");
            //tileEffect = BananaGame.GameContent.Load<Effect>("Effects\\SolidBlockEffect");
            tileEffect = new BasicEffect(BananaGame.Graphics);
            //tileEffect.EnableDefaultLighting();

            tileEffect.TextureEnabled = true;
            tileEffect.Texture = textureAtlas;
            tileEffect.LightingEnabled = true;

            Vector3 lightDirection = new Vector3(0, 0.75f, 1);
            Vector3 lightColor = new Vector3(0.2f, 0.2f, 0.2f);

            tileEffect.DirectionalLight0.Enabled = true;
            tileEffect.DirectionalLight0.Direction = lightDirection;
            tileEffect.DirectionalLight0.DiffuseColor = lightColor;
            tileEffect.DirectionalLight0.SpecularColor = lightColor;

            tileEffect.DirectionalLight1.Enabled = true;
            tileEffect.DirectionalLight1.Direction = lightDirection;
            tileEffect.DirectionalLight1.DiffuseColor = lightColor;
            tileEffect.DirectionalLight1.SpecularColor = lightColor;
        }

        public void UpdateEffects()
        {
            //tileEffect.EnableDefaultLighting();
            tileEffect.World = Matrix.Identity;
            tileEffect.View = BananaGame.GameCamera.View;
            tileEffect.Projection = BananaGame.GameCamera.Projection;

            //Vector3 lightDirection = new Vector3(0, 0.75f, 1);
            Vector3 lightDirection = World.SunPosition;
            Vector3 lightColor = World.DayLight;

            tileEffect.DirectionalLight0.Enabled = true;
            tileEffect.DirectionalLight0.Direction = lightDirection;
            tileEffect.DirectionalLight0.DiffuseColor = lightColor;
            tileEffect.DirectionalLight0.SpecularColor = lightColor;

            //tileEffect.TextureEnabled = true;
            //tileEffect.Texture = textureAtlas;

            //tileEffect.Parameters["World"].SetValue(Matrix.Identity);
            //tileEffect.Parameters["View"].SetValue(BananaGame.GameCamera.View);
            //tileEffect.Parameters["Projection"].SetValue(BananaGame.GameCamera.Projection);
            //tileEffect.Parameters["CameraPosition"].SetValue(BananaGame.GameCamera.Position);
            //tileEffect.Parameters["Texture1"].SetValue(textureAtlas);

            //tileEffect.Parameters["HorizonColor"].SetValue(Color.Black.ToVector4());
            //tileEffect.Parameters["NightColor"].SetValue(Color.Black.ToVector4());

            //tileEffect.Parameters["MorningTint"].SetValue(Color.Gold.ToVector4());
            //tileEffect.Parameters["EveningTint"].SetValue(Color.Red.ToVector4());

            //tileEffect.Parameters["SunColor"].SetValue(Color.White.ToVector4());
            //tileEffect.Parameters["timeOfDay"].SetValue(12);

            BananaGame.Graphics.BlendState = BlendState.Opaque;
            BananaGame.Graphics.DepthStencilState = DepthStencilState.Default;
        }

        public void RenderChunks(Segment segment)
        {
            UpdateEffects();

            BoundingFrustum viewFrustum = new BoundingFrustum(BananaGame.GameCamera.View * BananaGame.GameCamera.Projection);

            foreach (EffectPass pass in tileEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                foreach (Chunk chunk in segment.Values)
                {
                    if (viewFrustum.Intersects(chunk.Bounds))
                    {
                        if (chunk.IndexBuffer != null && chunk.IndexBuffer.IndexCount > 0)
                        {
                            //VertCount += chunk.VertexBuffer.VertexCount;
                            BananaGame.Graphics.SetVertexBuffer(chunk.VertexBuffer);
                            BananaGame.Graphics.Indices = chunk.IndexBuffer;
                            BananaGame.Graphics.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, chunk.VertexBuffer.VertexCount, 0, chunk.IndexBuffer.IndexCount / 3);
                        }
                        //if (chunk.State == ChunkState.AwaitingRender)
                        //{
                        //    chunk.State = ChunkState.Rendering;
                        //    chunk.Shape.Process(chunk);
                        //}
                    }
                    //if (chunk.State == ChunkState.AwaitingProcess)
                    //{
                    //    chunk.State = ChunkState.InQueue;
                    //    chunk.ProcessChunk();
                    //}
                }
            }
        }

        public void RenderChunk(Chunk chunk)
        {
            UpdateEffects();

            BoundingFrustum viewFrustum = new BoundingFrustum(BananaGame.GameCamera.View * BananaGame.GameCamera.Projection);

            foreach (EffectPass pass in tileEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (viewFrustum.Intersects(chunk.Bounds))
                {
                    if (chunk.IndexBuffer != null && chunk.IndexBuffer.IndexCount > 0)
                    {
                        //VertCount += chunk.VertexBuffer.VertexCount;
                        BananaGame.Graphics.SetVertexBuffer(chunk.VertexBuffer);
                        BananaGame.Graphics.Indices = chunk.IndexBuffer;
                        BananaGame.Graphics.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, chunk.VertexBuffer.VertexCount, 0, chunk.IndexBuffer.IndexCount / 3);
                    }
                    if (chunk.State == ChunkState.NotSoReady)
                    {
                        chunk.shapeM.Process(chunk);
                    }
                }
                //if (chunk.State == ChunkState.AwaitingProcess)
                //{
                //    chunk.State = ChunkState.InQueue;
                //    chunk.ProcessChunk();
                //}
            }
        }
    }
}
