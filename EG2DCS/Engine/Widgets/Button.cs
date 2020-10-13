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
    public class Button : TextWidget
    {
        public Color HighlightColor { get; set; } = Color.Pink;
        public float highlightWidth = 0;

        private ButtonHighlightAnimation currentAnim;

        private Func<bool> clickHandler;

        public Button(int x, int y, int width, int height, string text, Func<bool> clickHandler) : base(x, y, width, height, text)
        {
            this.clickHandler = clickHandler;
        }

        public override void Draw()
        {
            base.Draw();
            Rectangle highlightRect = new Rectangle(Rectangle.Location, Rectangle.Size);
            highlightRect.Width = (int)highlightWidth;
            Universal.SpriteBatch.Draw(Textures.Null, highlightRect, HighlightColor);
            Vector2 textMesurements = TextFont.MeasureString(Text);

            if (CenterText)
                Universal.SpriteBatch.DrawString(TextFont, Text, new Vector2(Rectangle.X + ((Rectangle.Width - textMesurements.X) / 2), Rectangle.Y + ((Rectangle.Height - textMesurements.Y) / 2)), TextColor);
            else
                Universal.SpriteBatch.DrawString(TextFont, Text, new Vector2(Rectangle.X, Rectangle.Y), TextColor);
        }

        public override void OnHover()
        {
            base.AddAnimation(currentAnim = new ButtonHighlightAnimation(this, 20));
        }

        public override void OnUnHover()
        {
            highlightWidth = 0;
            currentAnim.Complete = true;
        }

        public override void OnClick(bool lmb)
        {
            base.OnClick(lmb);
            clickHandler.Invoke();
        }
    }
}
