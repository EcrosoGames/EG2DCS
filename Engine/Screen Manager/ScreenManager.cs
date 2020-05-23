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

    class ScreenManager
    {
        List<BaseScreen> Screens = new List<BaseScreen>();
        List<BaseScreen> NewScreens = new List<BaseScreen>();
        //Private DebugScreen as new Debug()

        public void New()
        {
            //Add Debug Screen
        }
        public void Update()
        {
            List<BaseScreen> RemoveScreens = new List<BaseScreen>();
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.State == ScreenState.Shutdown)
                {
                    RemoveScreens.Add(FoundScreen);
                }
                else
                {
                    FoundScreen.Focused = false;
                }
            }
            foreach (BaseScreen FoundScreen in RemoveScreens)
            {
                Screens.Remove(FoundScreen);
            }
            foreach (BaseScreen FoundScreen in NewScreens)
            {
                Screens.Add(FoundScreen);
            }
            NewScreens.Clear();
            if (Screens.Count > 0)
            {
                for(int i=0; i < Screens.Count; i++)
                {
                    if (Screens[i].GrabFocus)
                    {
                        Screens[i].Focused = true;
                        break;
                    }
                }
            }
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
        public void Draw()
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                switch (FoundScreen.State)
                {
                    case ScreenState.Active:
                        FoundScreen.Draw();
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
        public  void AddScreen(BaseScreen screen)
        {
            NewScreens.Add(screen);
        }
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
        public bool Find(string Name)
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






    }
}
