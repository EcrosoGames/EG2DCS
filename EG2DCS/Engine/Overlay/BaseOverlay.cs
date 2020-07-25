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
        private Color color;

        public BaseOverlay(int x, int y, int width, int height) : base(new Rectangle(x, y, width, height))
        {
            color = new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255);
        }
        public virtual void HandleInput()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void Draw()
        {
            Universal.SpriteBatch.Draw(Textures.Null, rectangle, color);
        }
        public virtual void Remove()
        {

        }
    }
}
