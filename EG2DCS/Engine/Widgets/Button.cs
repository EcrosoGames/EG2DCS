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

        public Button(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            this.text = text;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            Universal.SpriteBatch.DrawString(Fonts.Arial_12, text, new Vector2(rectangle.X, rectangle.Y), Color.White);
        }

        public override void Remove()
        {
        }
    }
}
