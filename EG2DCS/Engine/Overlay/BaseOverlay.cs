using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Overlay
{
    public class BaseOverlay : Animator
    {
        public Color Color { get; set; } = Color.White;

        public BaseOverlay(int x, int y, int width, int height) : base(new Rectangle(x, y, width, height))
        {
        }
        public virtual void HandleInput()
        {

        }

        public virtual void Draw()
        {
            Universal.SpriteBatch.Draw(Textures.Null, Rectangle, Color);
        }
        public virtual void Remove()
        {

        }
    }
}
