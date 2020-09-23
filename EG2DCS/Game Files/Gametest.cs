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
using EG2DCS.Engine.Toast;
using EG2DCS.Engine.Overlay;
using EG2DCS.Engine.Widgets;

namespace EG2DCS.Engine.Blanks
{
    public class Gametest : BaseScreen
    {
        private double AniTime = 0;
        private Vector2 PlayerPos = new Vector2(10, 10);
        public Gametest()
        {
            Name = "Gametest";
            State = ScreenState.Active;

            AddWidget(new InputField(700, 300, 75, 25, "Input", Color.Gray, Color.Orange));
            AddWidget(new Button(300, 300, 75, 25, "Button"));
            AddWidget(new Label(500, 300, 75, 25, "Label", Color.White, Color.Red));
        }

        public override void HandleInput()
        {
            base.HandleInput();

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
                if (base.PopOverlay() == null)
                {
                    ScreenManager.KillAll(false, "Gametest");
                }
            }
            if (Input.KeyPressed(Keys.D1))
            {
                PushToast(new BaseToast());
            }
            if (Input.KeyPressed(Keys.D2))
            {
                PushOverlay(new BaseOverlay(300, 200, 300, 200));
            }
        }
        public override void Update()
        {
            base.Update();
            AniTime += Universal.GameTime.ElapsedGameTime.TotalMilliseconds;
            if (AniTime > 2)
            {
                AniTime = 0;
            }
        }
        public override void Draw()
        {
            base.Draw();
            Universal.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            Universal.SpriteBatch.Draw(Textures.Null, new Rectangle((int)PlayerPos.X, (int)PlayerPos.Y, 10, 10), Color.Red);

            Universal.SpriteBatch.End();
        }
    }
}
