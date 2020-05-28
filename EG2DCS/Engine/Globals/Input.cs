using Microsoft.Xna.Framework.Input;

namespace EG2DCS.Engine.Globals
{
    class Input
    {
        private static KeyboardState CurrentKeyState;
        private static KeyboardState LastKeyState;
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
            return CurrentKeyState.IsKeyDown(Key) && LastKeyState.IsKeyUp(Key);
        }
    }
}
