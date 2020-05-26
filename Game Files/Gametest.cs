using EG2DCS.Engine.Screen_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EG2DCS.Engine.Globals;

namespace EG2DCS.Engine.Blanks
{
    public class Gametest : BaseScreen
    {
        Double AniTime = 0;
        Vector2 PlayerPos = new Vector2(10, 10);
        public Gametest()
        {
            Name = "Gametest";
            State = ScreenState.Active;
        }
        public override void HandleInput()
        {
            if (Input.KeyDown(Keys.W))
            {
                PlayerPos.Y -= 1;
            }
            if (Input.KeyDown(Keys.A))
            {
                PlayerPos.X -= 1;
            }
            if (Input.KeyDown(Keys.S))
            {
                PlayerPos.Y += 1;
            }
            if (Input.KeyDown(Keys.D))
            {
                PlayerPos.X += 1;
            }
            if (Input.KeyPressed(Keys.Space))
            {
                ScreenManager.AddScreen(new Default_Screen());
            }
            if (Input.KeyPressed(Keys.Escape))
            {
                ScreenManager.KillAll(false, "Gametest");
            }
        }
        public override void Update()
        {
            AniTime += Universal.GameTime.ElapsedGameTime.TotalMilliseconds;
            if (AniTime > 2)
            {
                AniTime = 0;

            }
        }
        public override void Draw()
        {
            Universal.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            Universal.SpriteBatch.Draw(Textures.Null, new Rectangle((int)PlayerPos.X, (int)PlayerPos.Y, 10, 10), Color.Red);

            Universal.SpriteBatch.End();
        }
    }
}
