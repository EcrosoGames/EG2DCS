using Microsoft.Xna.Framework.Input;

namespace EG2DCS.Engine.Globals
{
    public class Input
    {
        private static KeyboardState CurrentKeyState;
        private static KeyboardState LastKeyState;

        private static KeyListener CurrentListener;

        public static void Update()
        {
            LastKeyState = CurrentKeyState;
            CurrentKeyState = Keyboard.GetState();

            if (CurrentListener == null)
                return;

            foreach (Keys key in LastKeyState.GetPressedKeys())
                if (!CurrentKeyState.IsKeyDown(key))
                    CurrentListener.onKeyRelease(key);

            foreach (Keys key in CurrentKeyState.GetPressedKeys())
                if (!LastKeyState.IsKeyDown(key))
                    CurrentListener.onKeyPress(key);
        }
        public static bool KeyDown(Keys Key)
        {
            return CurrentKeyState.IsKeyDown(Key);
        }
        public static bool KeyPressed(Keys Key)
        {
            return CurrentKeyState.IsKeyDown(Key) && LastKeyState.IsKeyUp(Key);
        }

        public static void setCurrentKeyListener(KeyListener listener)
        {
            CurrentListener = listener;
        }

        public static KeyListener getCurrentKeyListener()
        {
            return CurrentListener;
        }
    }

    public interface KeyListener
    {
        bool onKeyPress(Keys key);

        bool onKeyRelease(Keys key);
    }
}
