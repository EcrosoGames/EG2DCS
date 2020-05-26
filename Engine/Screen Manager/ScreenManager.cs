using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Screen_Manager
{
    public enum ScreenState
    {
        Active, Shutdown, Frozen, Paused, Background, Inactive
    }
    //           |Draw|Update|Input|
    //Active     | X  |   X  |  X  |
    //Shutdown   |    |      |     |
    //Frozen     | X  |   X  |     |
    //Paused     | X  |      |     |
    //Background |    |   X  |     |
    //Inactive   |    |      |     |
    class ScreenManager
    {
        private static List<BaseScreen> Screens = new List<BaseScreen>();

        public void New()
        {
            //Left this here in case we have anything that needs to start upon loading Screen Manager
        }
        public void Update()
        {
            //Create a list of screens to remove so you can remove them all at once
            for (int i = Screens.Count() - 1; i > 0; i--)
            {
                BaseScreen FoundScreen = Screens[i];
                if (FoundScreen.State == ScreenState.Shutdown)
                {
                    Screens.RemoveAt(i);
                }
                else
                {
                    FoundScreen.Focused = false;
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
            //Update the appropriate screens
            foreach (BaseScreen FoundScreen in Screens)
            {
                switch (FoundScreen.State)
                {
                    case ScreenState.Active:
                        FoundScreen.Update();
                        break;
                    case ScreenState.Frozen:
                        FoundScreen.Update();
                        break;
                    case ScreenState.Background:
                        FoundScreen.Update();
                        break;
                }
            }

        }
        //Draw the appropriate screens
        public void Draw()
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                switch (FoundScreen.State)
                {
                    case ScreenState.Active:
                        FoundScreen.Draw();
                        FoundScreen.HandleInput();
                        break;
                    case ScreenState.Frozen:
                        FoundScreen.Draw();
                        break;
                    case ScreenState.Paused:
                        FoundScreen.Draw();
                        break;
                }
            }
        }
        //Add a new screen
        public void AddScreen(BaseScreen screen)
        {
            Screens.Add(screen);
        }
        //remove a screen
        public void RemoveScreen(string screen)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Name == screen)
                {
                    FoundScreen.Remove();
                    break;
                }
            }
        }
        //Find if a screen is loaded
        public static bool Find(string Name)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (Name == FoundScreen.Name)
                {
                    return true;
                }
            }
            return false;
        }
        //set all screens to paused if overridable, exception for focused screen
        public static void PauseAll(string exception)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Name != exception)
                {
                    if (FoundScreen.Overridable)
                    {
                        FoundScreen.LastState = FoundScreen.State;
                        FoundScreen.State = ScreenState.Paused;
                    }
                }
            }
        }
        //set all screens to frozen if overridable, exception for focused screen
        public static void FreezeAll(string exception)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Name != exception)
                {
                    if (FoundScreen.Overridable)
                    {
                        FoundScreen.LastState = FoundScreen.State;
                        FoundScreen.State = ScreenState.Frozen;
                    }
                }
            }
        }
        //set all screens back to their original state
        public static void ResumeAll()
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Overridable)
                {
                    FoundScreen.State = FoundScreen.LastState;
                }
            }
        }
        //MURDER all screens, option to force if overridable doesn't matter(ex. game over), also option for exception so you don't delete all your screens
        public static void KillAll(bool Force, string exception)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Name != exception)
                {
                    if (Force)
                    {
                        FoundScreen.State = ScreenState.Shutdown;
                    }
                    else
                    {
                        if (FoundScreen.Overridable)
                        {
                            FoundScreen.State = ScreenState.Shutdown;
                        }
                    }
                }
            }
        }
        //Manually set the state of a screen from another screen
        public static void SetState(ScreenState State, string name)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (name == FoundScreen.Name)
                {
                    FoundScreen.State = State;
                }
            }
        }
    }
}
