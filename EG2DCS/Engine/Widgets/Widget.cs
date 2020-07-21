using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Widgets
{
    public class Widget : Animator
    {
        private Color color;
        protected Rectangle rectangle;

        public Widget(int x, int y, int width, int height)
        {
            color = new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255);
            rectangle = new Rectangle(x, y, width, height);
        }

        public virtual void Update()
        {
            base.Update(ref rectangle);
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
