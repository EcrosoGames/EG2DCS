using EG2DCS.Engine.Screen_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EG2DCS.Engine.Globals;

namespace EG2DCS.Engine.Blanks
{
    public class Default_Screen : BaseScreen
    {
        Double AniTime = 0;
        public Default_Screen()
        {
            Name = "DefaultScreen";
            State = ScreenState.Active;
        }
        public override void HandleInput()
        {
            
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
