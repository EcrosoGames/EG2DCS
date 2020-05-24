using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Globals
{
    class Input
    {
        static KeyboardState CurrentKeyState;
        static KeyboardState LastKeyState;
        public static void Update()
        {
            LastKeyState = CurrentKeyState;
            CurrentKeyState = Keyboard.GetState();
        }
        public static bool KeyDown(Keys Key)
        {
            return CurrentKeyState.IsKeyDown(Key);
        }
        public static bool KeyPressed(Keys Key)
        {
            if (CurrentKeyState.IsKeyDown(Key) && LastKeyState.IsKeyUp(Key))
            {
                return true;
            }
            return false;
        }
    }
}
