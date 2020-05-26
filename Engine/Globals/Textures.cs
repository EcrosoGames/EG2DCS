using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Globals
{
    class Textures
    {
        public static Texture2D Null;
        public static void Load()
        {
            Null = Universal.Content.Load<Texture2D>("Null");

        }

    }
}
