using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Widgets
{
    public class InputField : TextWidget, IFocusable
    {
        public string PlaceholderText { get; set; }
        public Color SelectedColor { get; set; }

        private bool selected = false;

        public InputField(int x, int y, int width, int height, string text) : base(x, y, width, height, text)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            if (selected)
                Universal.SpriteBatch.Draw(Textures.Null, Rectangle, SelectedColor);
            Universal.SpriteBatch.DrawString(TextFont, Text.Length == 0 ? PlaceholderText : Text, new Vector2(Rectangle.X, Rectangle.Y), TextColor);
        }

        public override void Remove()
        {
        }

        public void onFocus()
        {
            selected = true;
        }

        public void onUnFocus()
        {
            selected = false;
        }


        public bool onKeyPress(Keys key)
        {
            if (key >= Keys.A && key <= Keys.Z)
            {
                if (Input.KeyDown(Keys.LeftShift) || Input.KeyDown(Keys.RightShift))
                    Text += key.ToString();
                else
                    Text += key.ToString().ToLower();
            }
            else if (key == Keys.Back && Text.Length > 0)
            {
                Text = Text.Substring(0, Text.Length - 1);
            }
            return true;
        }

        public bool onKeyRelease(Keys key)
        {
            return true;
        }
    }
}
