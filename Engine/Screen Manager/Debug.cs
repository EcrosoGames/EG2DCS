using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EG2DCS.Engine.Screen_Manager
{
    class Debug : BaseScreen
    {
        protected double AniTime = 0;
        protected string ScreenList;
        public Debug()
        {
            Name = "Debug";
            State = ScreenState.Hiding;
            if (Universal.Debugging) { State = ScreenState.Active; }
            Overridable = false;
        }
        public override void HandleInput()
        {
            if (Input.KeyPressed(Keys.F1))
            {
                if (Universal.Debugging)
                {
                    Universal.Debugging = false;
                    State = ScreenState.Hiding;
                }
                else
                {
                    Universal.Debugging = true;
                    State = ScreenState.Active;
                }
            }
        }
        public override void Update()
        {
            AniTime += Universal.GameTime.ElapsedGameTime.TotalMilliseconds;
            if (AniTime > 20)
            {
                AniTime = 0;
                ScreenList = "";
                for (int q = 0; q < ScreenManager.Screens.Count; q++)
                {
                    ScreenList += ScreenManager.Screens[q].Name + ", ";

                }
            }
        }
        public override void Draw()
        {
            Universal.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            Universal.SpriteBatch.Draw(Textures.Null, new Rectangle(0, 0, 500, 20), new Color(0, 0, 0, 100));
            Universal.SpriteBatch.DrawString(Fonts.Arial_12, "Screens: " + ScreenList, new Vector2(0, 0), Color.White);


            Universal.SpriteBatch.End();
        }
    }
}
