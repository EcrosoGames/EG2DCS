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
    public class Button : Widget
    {
        private string text;

        private Color highlightColor;
        public float highlightWidth = 0;

        private ButtonHighlightAnimation currentAnim;

        public Button(int x, int y, int width, int height, string text) : this(x, y, width, height, text, Color.White, new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255))
        {
        }

        public Button(int x, int y, int width, int height, string text, Color textColor, Color highlightColor) : base(x, y, width, height)
        {
            this.text = text;
            this.highlightColor = highlightColor;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            Rectangle higlightRect = new Rectangle(rectangle.Location, rectangle.Size);
            higlightRect.Width = (int)highlightWidth;
            Universal.SpriteBatch.Draw(Textures.Null, higlightRect, highlightColor);
            Universal.SpriteBatch.DrawString(Fonts.Arial_12, text, new Vector2(rectangle.X, rectangle.Y), Color.White);
        }

        public override void Remove()
        {
        }

        public override void OnHover()
        {
            base.AddAnimation(currentAnim = new ButtonHighlightAnimation(this, 20));
        }

        public override void OnUnHover()
        {
            highlightWidth = 0;
            currentAnim.SetComplete();
        }

        public override void OnClick(bool lmb)
        {
            Console.WriteLine("Button Clicked!");
            base.OnClick(lmb);
        }
    }
}
