using System;

namespace BananaTheGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BananaGame game = new BananaGame())
            {
                game.Run();
            }
        }
    }
#endif
}

