using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Widgets
{
    public class Label : TextWidget
    {
        public Color HoverColor { get; set; } = Color.White;

        private bool hovered = false;

        public Label(int x, int y, int width, int height, string text) : base(x, y, width, height, text)
        {

        }

        public override void Draw()
        {
            base.Draw();
            Universal.SpriteBatch.DrawString(TextFont, Text, new Vector2(Rectangle.X, Rectangle.Y), hovered ? HoverColor : TextColor);
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
