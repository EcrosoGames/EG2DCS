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
        private Color backgroundColor;

        public Widget(int x, int y, int width, int height) : base(new Rectangle(x, y, width, height))
        {
            backgroundColor = new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255);
        }

        public override void Update()
        {
            base.Update();
        }

        public virtual void Draw()
        {
            Universal.SpriteBatch.Draw(Textures.Null, rectangle, backgroundColor);
        }

        public virtual void Remove()
        {
        }

        public virtual void OnHover()
        {
        }

        public virtual void OnUnHover()
        {
        }

        public virtual void OnClick(bool lmb)
        {
        }
    }
}
