using System;
using BananaTheGame.Entities;

namespace BananaTheGame.Controllers
{
    public static class ControllerManager
    {
        public static CameraController CameraControls { get; private set; }
        public static PlayerController PlayerControls { get; private set; }

        public static void Initialize()
        {
            GameKeyState.Initialize();
            GameMouseState.Initialize();

            CameraControls = new CameraController();
        }

        public static void AddPlayer(Player player)
        {
            PlayerControls = new PlayerController(player);
        }

        public static void Update()
        {
            GameKeyState.Update();
            GameMouseState.Update();

            if (CameraControls != null && !CameraControls.IsPaused)
                CameraControls.Update();

            if (PlayerControls != null && !PlayerControls.IsPaused)
            {
                PlayerControls.Update();
            }
        }

        //public static void ResumePlayerControls()
        //{
        //    PlayerControls.IsPaused = false;
        //}

        //public static void PausePlayerControls()
        //{
        //    PlayerControls.IsPaused = true;
        //}

        //load key bindings
    }
}
