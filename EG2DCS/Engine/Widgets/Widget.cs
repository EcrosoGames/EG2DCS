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
        public Color BackgroundColor { get; set; } = Color.Black;

        private int borderWidth = 0;
        public Color BorderColor { get; set; } = Color.White;

        public bool Visible { get; set; } = true;

        public Widget(int x, int y, int width, int height) : base(new Rectangle(x, y, width, height))
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public virtual void Draw()
        {
            if (borderWidth > 0)
            {
                Rectangle borderRect = new Rectangle(Rectangle.Location, Rectangle.Size);
                borderRect.Inflate(borderWidth, borderWidth);
                Universal.SpriteBatch.Draw(Textures.Null, borderRect, BorderColor);
            }
            Universal.SpriteBatch.Draw(Textures.Null, Rectangle, BackgroundColor);
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

        public Color setBackgroundColor(Color color)
        {
            Color old = BackgroundColor;
            BackgroundColor = color;
            return old;
        }

        public void setBorder(int width, Color color)
        {
            setBorderWidth(width);
            BorderColor = color;
        }

        public void setBorderWidth(int width)
        {
            this.borderWidth = width;
        }
    }
}
