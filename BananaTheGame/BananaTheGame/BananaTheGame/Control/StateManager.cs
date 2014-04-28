using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Control
{
    public static class StateManager
    {
        private static State currentState;
        private static State queuedState;

        public static bool AwaitingSwap { get; private set; }

        public static void QueueState(State state)
        {
            AwaitingSwap = true;
            queuedState = state;
        }

        private static void switchState(State state)
        {
            currentState = state;
            currentState.Load();
        }

        //public void Load()
        //{
        //}

        public static void Update(GameTime gameTime)
        {
            if (AwaitingSwap)
            {
                if (queuedState != null)
                {
                    switchState(queuedState);
                    queuedState = null;
                }
                AwaitingSwap = false;
            }
            if (currentState != null)
                currentState.Update(gameTime);
        }

        public static void Draw(GameTime gameTime)
        {
            if (currentState != null)
                currentState.Draw(gameTime);
        }

        public static void DrawSprite(GameTime gameTime)
        {
            if (currentState != null)
                currentState.DrawSprite(gameTime);
        }
    }
}
