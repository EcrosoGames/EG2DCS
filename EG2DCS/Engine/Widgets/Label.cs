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
    public class Label : Widget
    {
        private string text;
        private Color textColor;
        private Color hoverColor;

        private bool hovered = false;

        public Label(int x, int y, int width, int height, string text) : this(x, y, width, height, text,
            new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255),
            new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255))
        {
        }

        public Label(int x, int y, int width, int height, string text, Color textColor) : this(x, y, width, height, text, textColor, textColor)
        {
        }

        public Label(int x, int y, int width, int height, string text, Color textColor, Color hoverColor) : base(x, y, width, height)
        {
            this.text = text;
            this.textColor = textColor;
            this.hoverColor = hoverColor;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            Universal.SpriteBatch.DrawString(Fonts.Arial_12, text, new Vector2(rectangle.X, rectangle.Y), hovered ? hoverColor : textColor);
        }

        public override void Remove()
        {
        }

        public override void OnHover()
        {
            hovered = true;
        }

        public override void OnUnHover()
        {
            hovered = false;
        }
    }
}
