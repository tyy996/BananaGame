using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BananaTheGame.Controllers
{
    public class CameraController : Controller
    {
        public bool IsMouseLocked { get; set; }

        public CameraController()
        {
            IsMouseLocked = false;
        }

        public override void Update()
        {
            //temporaryControls();
            if (GameKeyState.IsKeyPressed(Keys.P)) //test key
            {
                IsMouseLocked = !IsMouseLocked;
            }

            if (IsMouseLocked)
            {

                float mouseDirectionX = GameMouseState.ScreenX - (BananaGame.GameCamera.CameraViewPort.Width / 2);
                float mouseDirectionY = GameMouseState.ScreenY - (BananaGame.GameCamera.CameraViewPort.Height / 2);

                if (mouseDirectionX != 0)
                {
                    BananaGame.GameCamera.LeftRightRotation -= Camera.ROTATION_SPEED * (mouseDirectionX / 50);
                }

                if (mouseDirectionY != 0)
                {
                    float newPosition = BananaGame.GameCamera.UpDownRotation - Camera.ROTATION_SPEED * (mouseDirectionY / 50);
                    if (newPosition < -1.55f)
                        newPosition = -1.55f;
                    else if (newPosition > 1.55f)
                        newPosition = 1.55f;
                    BananaGame.GameCamera.UpDownRotation = newPosition;
                }

                Mouse.SetPosition(BananaGame.GameCamera.CameraViewPort.Width / 2, BananaGame.GameCamera.CameraViewPort.Height / 2);
            }
        }

        private void temporaryControls()
        {
            float m = 0.025f;

            if (GameKeyState.IsKeyDown(Keys.W))
            {
                BananaGame.GameCamera.Position += Vector3.Forward * m;
            }

            if (GameKeyState.IsKeyDown(Keys.S))
            {
                BananaGame.GameCamera.Position += Vector3.Backward * m;
            }

            if (GameKeyState.IsKeyDown(Keys.A))
            {
                BananaGame.GameCamera.Position += Vector3.Left * m;
            }

            if (GameKeyState.IsKeyDown(Keys.D))
            {
                BananaGame.GameCamera.Position += Vector3.Right * m;
            }

            if (GameKeyState.IsKeyDown(Keys.LeftShift))
            {
                BananaGame.GameCamera.Position += Vector3.Down * m;
            }

            if (GameKeyState.IsKeyDown(Keys.Space))
            {
                BananaGame.GameCamera.Position += Vector3.Up * m;
            }
        }
    }
}
