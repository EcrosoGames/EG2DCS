using Microsoft.Xna.Framework.Graphics;

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
