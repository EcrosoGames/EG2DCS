using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EG2DCS.Engine.Globals
{
    class Universal
    {
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static bool WindowFocused;
        public static Vector2 GameSize;
        public static RenderTarget2D BackBuffer;
        public static bool Debugging;
        public static Random rnd = new Random();
    }
}
