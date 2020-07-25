using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Screen_Manager
{
    public enum ScreenState
    {
        Active, Shutdown, Frozen, Paused, Background, Inactive, Hiding
    }
    //           |Draw|Update|Input|
    //Active     | X  |   X  |  X  |
    //Shutdown   |    |      |     |
    //Frozen     | X  |   X  |     |
    //Paused     | X  |      |     |
    //Background |    |   X  |     |
    //Inactive   |    |      |     |
    //Hiding     |    |   X  |  X  |
    class ScreenManager
    {
        private static bool lmbClicked = false;
        private static bool rmbClicked = false;

        public static List<BaseScreen> Screens
        {
            get;
        } = new List<BaseScreen>();

        public void New()
        {
            //Left this here in case we have anything that needs to start upon loading Screen Manager

        }
        public void Update()
        {
            //We iterate backwards here so that we can remove from the list more intuitvley and avoid concurent modifications.
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.State == ScreenState.Shutdown)
                {
                    Screens.RemoveAt(i);
                }
                else
                {
                    foundScreen.Focused = false;
                }
            }

            //Find the screen to focus on
            if (Screens.Count > 0)
            {
                for (int i = 0; i < Screens.Count; i++)
                {
                    if (Screens[i].GrabFocus)
                    {
                        Screens[i].Focused = true;
                        break;
                    }
                }
            }

            PollInput();

            //Update the appropriate screens
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                switch (foundScreen.State)
                {
                    case ScreenState.Active:
                        foundScreen.Update();
                        foundScreen.HandleInput();
                        break;
                    case ScreenState.Frozen:
                        foundScreen.Update();
                        break;
                    case ScreenState.Background:
                        foundScreen.Update();
                        break;
                    case ScreenState.Hiding:
                        foundScreen.Update();
                        foundScreen.HandleInput();
                        break;
                }
            }


        }
        //Draw the appropriate screens
        public void Draw()
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name != "Debug")
                {
                    switch (foundScreen.State)
                    {
                        case ScreenState.Active:
                            foundScreen.Draw();
                            break;
                        case ScreenState.Frozen:
                            foundScreen.Draw();
                            break;
                        case ScreenState.Paused:
                            foundScreen.Draw();
                            break;
                    }
                }
            }
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name == "Debug")
                {
                    foundScreen.Draw();
                }
            }
        }
        //Add a new screen
        public static void AddScreen(BaseScreen screen)
        {
            Screens.Add(screen);
        }
        //remove a screen
        public static void RemoveScreen(string screen)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name == screen)
                {
                    foundScreen.Remove();
                    break;
                }
            }
        }
        //Find if a screen is loaded
        public static bool Find(string name)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (name == foundScreen.Name)
                {
                    return true;
                }
            }
            return false;
        }
        //set all screens to paused if overridable, exception for focused screen
        public static void PauseAll(string exception)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name != exception)
                {
                    if (foundScreen.Overridable)
                    {
                        foundScreen.LastState = foundScreen.State;
                        foundScreen.State = ScreenState.Paused;
                    }
                }
            }
        }
        //set all screens to frozen if overridable, exception for focused screen
        public static void FreezeAll(string exception)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name != exception)
                {
                    if (foundScreen.Overridable)
                    {
                        foundScreen.LastState = foundScreen.State;
                        foundScreen.State = ScreenState.Frozen;
                    }
                }
            }
        }
        //set all screens back to their original state
        public static void ResumeAll()
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Overridable)
                {
                    foundScreen.State = foundScreen.LastState;
                }
            }
        }
        //MURDER all screens, option to force if overridable doesn't matter(ex. game over), also option for exception so you don't delete all your screens
        public static void KillAll(bool force, string exception)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (foundScreen.Name != exception)
                {
                    if (force)
                    {
                        foundScreen.State = ScreenState.Shutdown;
                    }
                    else
                    {
                        if (foundScreen.Overridable)
                        {
                            foundScreen.State = ScreenState.Shutdown;
                        }
                    }
                }
            }
        }
        //Manually set the state of a screen from another screen
        public static void SetState(ScreenState State, string name)
        {
            for (int i = Screens.Count() - 1; i >= 0; i--)
            {
                BaseScreen foundScreen = Screens[i];
                if (name == foundScreen.Name)
                {
                    foundScreen.State = State;
                }
            }
        }

        public static void PollInput()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !lmbClicked)
            {
                lmbClicked = true;
                for (int i = Screens.Count() - 1; i >= 0; i--)
                {
                    BaseScreen foundScreen = Screens[i];
                    if (foundScreen.State == ScreenState.Active)
                    {
                        foundScreen.OnClick(true, mouseState.X, mouseState.Y);
                    }
                }
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
                    if (foundScreen.State == ScreenState.Active)
                    {
                        foundScreen.OnClick(false, mouseState.X, mouseState.Y);
                    }
                }
            }
            else if (mouseState.RightButton != ButtonState.Pressed && rmbClicked)
            {
                rmbClicked = false;
            }
        }
    }
}
