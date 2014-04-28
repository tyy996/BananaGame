using System;
using Microsoft.Xna.Framework.Input;

namespace BananaTheGame.Controllers
{
    public static class GameKeyState
    {
        private static KeyboardState oldKeyState;
        private static KeyboardState keyState;

        internal static void Initialize()
        {
            keyState = Keyboard.GetState();
            oldKeyState = Keyboard.GetState();
        }

        internal static void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            if (keyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key))
            {
                return true;
            }

            return false;
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return keyState.IsKeyUp(key);
        }

        public static Keys[] GetPressedKeys()
        {
            return keyState.GetPressedKeys();
        }
    }
}
