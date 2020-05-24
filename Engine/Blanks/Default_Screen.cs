using EG2DCS.Engine.Screen_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EG2DCS.Engine.Blanks
{
    public class Default_Screen : BaseScreen
    {
        Double AniTime = 0;
        public void New()
        {
            Name = "DefaultScreen";
            State = ScreenState.Active;
        }
        public override void HandleInput()
        {
            
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



            Globals.Globals.SpriteBatch.End();
        }
    }
}
