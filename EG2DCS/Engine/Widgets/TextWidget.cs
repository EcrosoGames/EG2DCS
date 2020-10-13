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
    public class TextWidget : Widget
    {
        public string Text { get; set; }
        public SpriteFont TextFont { get; set; } = Fonts.Arial_12;
        public Color TextColor { get; set; } = Color.White;
        public bool CenterText { get; set; } = false;

        public TextWidget(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            this.Text = text;
        }
    }
}
