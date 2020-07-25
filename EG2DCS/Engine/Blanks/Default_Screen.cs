using EG2DCS.Engine.Screen_Manager;
using Microsoft.Xna.Framework.Graphics;
using EG2DCS.Engine.Globals;

namespace EG2DCS.Engine.Blanks
{
    public class Default_Screen : BaseScreen
    {
        private double AniTime = 0;
        public Default_Screen()
        {
            Name = "DefaultScreen";
            State = ScreenState.Active;
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



            Universal.SpriteBatch.End();
        }
    }
}
