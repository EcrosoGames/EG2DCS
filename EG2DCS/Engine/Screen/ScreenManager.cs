using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Screen_Manager
{
    class ScreenManager
    {
        private static bool lmbClicked = false;
        private static bool rmbClicked = false;

        public static List<BaseScreen> Screens
        {
            get;
        } = new List<BaseScreen>();

        private static BaseScreen currentScreen;

        public void Update()
        {

            PollInput();
            if (currentScreen != null)
            {
                currentScreen.Update();
                currentScreen.HandleInput();
            }
        }
        //Draw the appropriate screens
        public void Draw()
        {
            if (currentScreen != null)
            {
                currentScreen.Draw();
            }
        }
        //Add a new screen
        public static void RegisterScreen(BaseScreen screen)
        {
            Screens.Add(screen);
        }

        //Find if a screen is loaded
        public static BaseScreen Find(string id)
        {
            foreach (BaseScreen screen in Screens)
            {
                if (id.Equals(screen.Id))
                {
                    return screen;
                }
            }
            return null;
        }

        //Manually set the state of a screen from another screen
        public static void SetActive(string id)
        {
            BaseScreen nextScreen = Find(id);
            if (nextScreen != null)
            {
                if (currentScreen != null)
                    currentScreen.Unload();
                currentScreen = nextScreen;
                currentScreen.Load();
            }
        }

        public static void PollInput()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !lmbClicked)
            {
                lmbClicked = true;
                currentScreen.OnClick(true, mouseState.X, mouseState.Y);
            }
            else if (mouseState.LeftButton != ButtonState.Pressed && lmbClicked)
            {
                lmbClicked = false;
            }

            if (mouseState.RightButton == ButtonState.Pressed && !rmbClicked)
            {
                rmbClicked = true;
                for (int i = Screens.Count() - 1; i >= 0; i--)
                {
                    BaseScreen foundScreen = Screens[i];
                    currentScreen.OnClick(false, mouseState.X, mouseState.Y);
                }
            }
            else if (mouseState.RightButton != ButtonState.Pressed && rmbClicked)
            {
                rmbClicked = false;
            }
        }
    }
}
