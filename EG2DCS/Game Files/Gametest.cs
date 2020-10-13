using EG2DCS.Engine.Screen_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EG2DCS.Engine.Globals;
using EG2DCS.Engine.Toast;
using EG2DCS.Engine.Overlay;
using EG2DCS.Engine.Widgets;

namespace EG2DCS.Engine.Blanks
{
    public class Gametest : BaseScreen
    {
        private Vector2 PlayerPos = new Vector2(10, 10);
        public Gametest()
        {
            Id = "game_test";

            InputField inputField = new InputField(700, 300, 75, 25, "");
            inputField.TextColor = Color.Gray;
            inputField.SelectedColor = Color.Orange;
            inputField.PlaceholderText = "Input";
            inputField.setBorder(2, Color.Black);
            AddWidget(inputField);
            AddWidget(new Button(300, 300, 75, 25, "Button", () => { return true; }));
            AddWidget(new Button(400, 300, 75, 25, "Button", () => { return true; }));
            Label label = new Label(500, 300, 75, 25, "Label");
            label.TextColor = Color.White;
            label.BackgroundColor = Color.Red;
            AddWidget(label);
        }

        public override void Load()
        {
            Input.setCurrentKeyListener(this);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (base.focusedWidget != null)
                return;

            if (Input.KeyDown(Keys.W))
            {
                PlayerPos.Y -= 1;
            }
            if (Input.KeyDown(Keys.A))
            {
                PlayerPos.X -= 1;
            }
            if (Input.KeyDown(Keys.S))
            {
                PlayerPos.Y += 1;
            }
            if (Input.KeyDown(Keys.D))
            {
                PlayerPos.X += 1;
            }

            if (Input.KeyPressed(Keys.Escape))
            {
                base.PopOverlay();
            }
            if (Input.KeyPressed(Keys.D1))
            {
                PushToast(new BaseToast(new Vector2(300, 50)));
            }
            if (Input.KeyPressed(Keys.D2))
            {
                PushOverlay(new BaseOverlay(300, 200, 300, 200));
            }
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw()
        {
            base.Draw();
            Universal.SpriteBatch.Draw(Textures.Null, new Rectangle((int)PlayerPos.X, (int)PlayerPos.Y, 10, 10), Color.Red);
        }

        public override bool onKeyPress(Keys key)
        {
            if (!base.onKeyPress(key))
            {
                Console.WriteLine("Here: " + key);
                return false;
            }
            return true;
        }

        public override bool onKeyRelease(Keys key)
        {
            if (!base.onKeyRelease(key))
            {
                Console.WriteLine("Here R: " + key);
                return false;
            }
            return true;
        }
    }
}
