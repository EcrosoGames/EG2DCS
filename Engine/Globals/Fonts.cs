using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Globals
{
    class Fonts
    {
        public static SpriteFont Arial_12;
        public static void Load()
        {
            Arial_12 = Universal.Content.Load<SpriteFont>("Arial_12");

        }
    }
}
