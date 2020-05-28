using System;
using Microsoft.Xna.Framework;

namespace EG2DCS.Engine.Add_Ons
{
    class Maths
    {
        public static int RNGfree(int low, int high)
        {
            Random Gen = new Random();
            return Gen.Next(low, high + 1);
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
        public static bool Collision(Rectangle A, Rectangle B)
        {
            if (A.X < B.X + B.Width && A.X + A.Width > B.X && A.Y < B.Y + B.Height && A.Y + A.Height > B.Y)
            {
                return true;
            }
            return false;
        }
        public static bool Collisioninside(Rectangle A, Rectangle B)
        {
            if (A.X > B.X && A.X + A.Width < B.X + B.Width && A.Y > B.Y && A.Y + A.Height < B.Y + B.Height)
            {
                return true;
            }
            return false;
        }
        public static bool Collisionoutside(Rectangle A, Rectangle B)
        {
            if (A.X < B.X && A.X + A.Width > B.X + B.Width && A.Y < B.Y && A.Y + A.Height > B.Y + B.Height)
            {
                return true;
            }
            return false;
        }
        public static bool Collisioncircle(Vector2 A, float Ar, Vector2 B, float Br)
        {
            if (Distance(A, B) > Ar && Distance(A, B) < Br)
            {
                return true;
            }
            return false;
        }
        public static float Distance(Vector2 A, Vector2 B)
        {
            double dist;
            dist = Math.Abs(Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2)));
            return (float)dist;
        }
    }
}
