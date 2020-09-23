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
    public class InputField : Widget
    {
        private string text;
        private Color textColor;
        private Color selectedColor;

        private bool selected = false;

        public InputField(int x, int y, int width, int height, string text) : this(x, y, width, height, text,
            new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255),
            new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255))
        {
        }

        public InputField(int x, int y, int width, int height, string text, Color textColor) : this(x, y, width, height, text, textColor, textColor)
        {
        }

        public InputField(int x, int y, int width, int height, string text, Color textColor, Color selectedColor) : base(x, y, width, height)
        {
            this.text = text;
            this.textColor = textColor;
            this.selectedColor = selectedColor;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            //Universal.SpriteBatch.DrawString(Fonts.Arial_12, text, new Vector2(rectangle.X, rectangle.Y), textColor);
        }

        public override void Remove()
        {
        }

        public override void OnClick(bool lmb)
        {
            if(lmb)
            {
                selected = true;
            }
        }
    }
}
