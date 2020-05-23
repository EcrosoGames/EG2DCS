using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EG2DCS.Engine.Globals
{
    class Globals
    {
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static bool WindowFocused;
        public static Vector2 GameSize;
        public static RenderTarget2D BackBuffer;
        public static bool Debugging;
    }
}
