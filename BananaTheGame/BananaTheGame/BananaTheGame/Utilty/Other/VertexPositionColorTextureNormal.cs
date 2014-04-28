using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BananaTheGame
{
    public struct VertexPositionColorTextureNormal : IVertexType
    {
        public Vector3 Position;
        public Color Color;
        public Vector2 Texture;
        public Vector3 Normal;

        public readonly static VertexDeclaration VertexDeclaration = new VertexDeclaration
        (
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(12, VertexElementFormat.Color, VertexElementUsage.Color, 0),
            new VertexElement(16, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(24, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
        );

        VertexDeclaration IVertexType.VertexDeclaration
        {
            get { return VertexDeclaration; }
        }

        public VertexPositionColorTextureNormal(Vector3 position, Color color, Vector2 texture, Vector3 normal)
        {
            Position = position;
            Color = color;
            Texture = texture;
            Normal = normal;
        }
    }

    public struct VertexPositionColorTextureNormalExtra : IVertexType
    {
        public Vector3 Position;
        public Color Color;
        public Vector2 Texture;
        public Vector3 Normal;
        public Vector3 Extra;

        public readonly static VertexDeclaration VertexDeclaration = new VertexDeclaration
        (
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(12, VertexElementFormat.Color, VertexElementUsage.Color, 0),
            new VertexElement(16, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
            new VertexElement(24, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
            new VertexElement(36, VertexElementFormat.Vector3, VertexElementUsage.Position, 1)
        );

        VertexDeclaration IVertexType.VertexDeclaration
        {
            get { return VertexDeclaration; }
        }

        public VertexPositionColorTextureNormalExtra(Vector3 position, Color color, Vector2 texture, Vector3 normal, Vector3 extra)
        {
            Position = position;
            Color = color;
            Texture = texture;
            Normal = normal;
            Extra = extra;
        }
    }
}
