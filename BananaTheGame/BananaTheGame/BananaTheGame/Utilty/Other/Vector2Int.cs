using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame
{
    public class Vector2Int
    {
        public readonly int X;
        public readonly int Z;

        public Vector2Int(int x, int z)
        {
            this.X = x;
            this.Z = z;
        }

        public Vector2Int(Vector2 vector2)
        {
            X = (int)vector2.X;
            Z = (int)vector2.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2Int)
            {
                Vector2Int other = (Vector2Int)obj;
                return this.X == other.X && this.Z == other.Z;
            }
            return base.Equals(obj);
        }

        public static Vector2Int Zero
        {
            get { return new Vector2Int(0, 0); }
        }

        public static bool operator ==(Vector2Int a, Vector2Int b)
        {
            return a.X == b.X && a.Z == b.Z;
        }

        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            return !(a.X == b.X && a.Z == b.Z);
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X + b.X, a.Z + b.Z);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X - b.X, a.Z - b.Z);
        }

        public static Vector2Int operator *(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X * b.X, a.Z * b.Z);
        }

        public static int DistanceSquared(Vector2Int value1, Vector2Int value2)
        {
            int x = value1.X - value2.X;
            int z = value1.Z - value2.Z;

            return (x * x) + (z * z);
        }

        public override int GetHashCode()
        {
            //TODO check this hashcode impl           
            return (int)(X ^ Z);
        }

        public override string ToString()
        {
            return ("vector3i (" + X + "," + Z + ")");
        }

        public Vector2 asVector2()
        {
            return new Vector2(X, Z);
        }
    }
}
