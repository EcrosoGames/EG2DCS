using EG2DCS.Engine.Screen_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EG2DCS.Engine.Blanks
{
    public class Gametest : BaseScreen
    {
        Double AniTime = 0;
        Vector2 PlayerPos = new Vector2(10, 10);
        public void New()
        {
            Name = "Gametest";
            State = ScreenState.Active;
        }
        public override void HandleInput()
        {
            if (Globals.Input.KeyDown(Keys.W))
            {
                PlayerPos.Y -= 1;
            }
            if (Globals.Input.KeyDown(Keys.A))
            {
                PlayerPos.X -= 1;
            }
            if (Globals.Input.KeyDown(Keys.S))
            {
                PlayerPos.Y += 1;
            }
            if (Globals.Input.KeyDown(Keys.D))
            {
                PlayerPos.X += 1;
            }
        }
        public override void Update()
        {
            AniTime += Globals.Globals.GameTime.ElapsedGameTime.TotalMilliseconds;
            if (AniTime > 2)
            {
                AniTime = 0;

            }
        }
        public override void Draw()
        {
            Globals.Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            Globals.Globals.SpriteBatch.Draw(Globals.Textures.Null, new Rectangle((int)PlayerPos.X, (int)PlayerPos.Y, 10, 10), new Color(255, 0, 0));

            Globals.Globals.SpriteBatch.End();
        }
    }
}
