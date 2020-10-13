using System;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;

namespace EG2DCS.Engine.Add_Ons
{
    class Maths
    {
        public static int RNGfree(int low, int high)
        {
            return Universal.Rand.Next(low, high + 1);
        }

        public static Random Genf;
        public static int RNGfixed(int low, int high, int seed, bool Reset)
        {
            if (Reset)
            {
                Genf = new Random(seed);
            }

            return Genf.Next(low, high + 1);
        }

        public static bool Collisioninside(Rectangle A, Rectangle B)
        {
            return A.X > B.X && A.X + A.Width < B.X + B.Width && A.Y > B.Y && A.Y + A.Height < B.Y + B.Height;
        }
        public static bool Collisionoutside(Rectangle A, Rectangle B)
        {
            return A.X < B.X && A.X + A.Width > B.X + B.Width && A.Y < B.Y && A.Y + A.Height > B.Y + B.Height;
        }
        public static bool Collisioncircle(Vector2 A, float Ar, Vector2 B, float Br)
        {
            return Distance(A, B) > Ar && Distance(A, B) < Br;
        }
        public static float Distance(Vector2 A, Vector2 B)
        {
            return (float)Math.Abs(Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2)));
        }
    }
}
