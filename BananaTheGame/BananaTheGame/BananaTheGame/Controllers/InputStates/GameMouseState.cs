using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BananaTheGame.Controllers
{
    public static class GameMouseState
    {
        private static MouseState oldMouseState;
        private static MouseState mouseState;

        internal static void Initialize()
        {
            oldMouseState = Mouse.GetState();
            mouseState = Mouse.GetState();
        }

        internal static void Update()
        {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public static ButtonState LeftButton
        {
            get { return mouseState.LeftButton; }
        }

        public static ButtonState MiddleButton
        {
            get { return mouseState.MiddleButton; }
        }

        public static ButtonState RightButton
        {
            get { return mouseState.RightButton; }
        }

        public static int ScrollWheelValue
        {
            get { return mouseState.ScrollWheelValue; }
        }

        public static float ScreenX
        {
            get { return mouseState.X; }
        }

        public static float ScreenY
        {
            get { return mouseState.Y; }
        }

        public static bool IsLeftButtonClicked()
        {
            if (mouseState.LeftButton == ButtonState.Released &&
                oldMouseState.LeftButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool IsMiddleButtonClicked()
        {
            if (mouseState.MiddleButton == ButtonState.Released &&
                oldMouseState.MiddleButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool IsRightButtonClicked()
        {
            if (mouseState.RightButton == ButtonState.Released &&
                oldMouseState.RightButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool HasScrollValueChanged()
        {
            if (mouseState.ScrollWheelValue != oldMouseState.ScrollWheelValue)
                return true;
            return false;
        }

        //public static Vector2 WorldPosition()//ray method
        //{
        //    Vector3 nearPlane = BananaGame.Graphics.Viewport.Unproject(new Vector3(mouseState.X, mouseState.Y, 0),
        //        BananaGame.GameCamera.Projection, BananaGame.GameCamera.View, Matrix.Identity);

        //    Vector3 farPlane = BananaGame.Graphics.Viewport.Unproject(new Vector3(mouseState.X, mouseState.Y, 1),
        //        BananaGame.GameCamera.Projection, BananaGame.GameCamera.View, Matrix.Identity);

        //    Ray ray = new Ray(nearPlane, farPlane - nearPlane);

        //    float? depth = ray.Intersects(new Plane(Vector3.UnitZ, 0));

        //    if (depth != null)
        //    {
        //        Vector3 mouseFinal = (nearPlane + (farPlane - nearPlane) * depth.Value);
        //        return new Vector2(mouseFinal.X, mouseFinal.Y);
        //    }

        //    return Vector2.Zero;

        //}

        public static Vector2 WorldPosition()
        {
            Vector3 nearPlane = BananaGame.Graphics.Viewport.Unproject(new Vector3(mouseState.X, mouseState.Y, 0),
                BananaGame.GameCamera.Projection, BananaGame.GameCamera.View, Matrix.Identity);

            Vector3 farPlane = BananaGame.Graphics.Viewport.Unproject(new Vector3(mouseState.X, mouseState.Y, 1),
                BananaGame.GameCamera.Projection, BananaGame.GameCamera.View, Matrix.Identity);

            Vector3 direction = farPlane - nearPlane;

            float zFactor = -nearPlane.Z / direction.Z;
            Vector3 zeroWorldPoint = nearPlane + direction * zFactor;

            return new Vector2(zeroWorldPoint.X, zeroWorldPoint.Y);
        }

        //public static Vector3 WorldPosition(GraphicsDeviceManager graphics, Camera3d camera)
        //{
        //    float tempX = 582f;
        //    float tempY = 382f;
        //    Vector3 nearScreenPoint = new Vector3(mouseState.X, mouseState.Y, 0);
        //    //Vector3 farScreenPoint = new Vector3(mouseState.X, mouseState.Y, 0.98f);
        //    Vector3 farScreenPoint = new Vector3(mouseState.X, mouseState.Y, 1f);
        //    //Vector3 nearScreenPoint = new Vector3(tempX, tempY, 0);
        //    //Vector3 farScreenPoint = new Vector3(tempX, tempY, 0.5f);
        //    Vector3 nearWorldPoint = graphics.GraphicsDevice.Viewport.Unproject(nearScreenPoint, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);
        //    Vector3 farWorldPoint = graphics.GraphicsDevice.Viewport.Unproject(farScreenPoint, camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

        //    Vector3 direction = farWorldPoint - nearWorldPoint;
        //    Vector3 zeroWorldPoint = nearWorldPoint + direction;

        //    if (direction.Z < 0)
        //    {
        //        float zFactor = -nearWorldPoint.Z / direction.Z;
        //        zeroWorldPoint = nearWorldPoint + direction * zFactor;
        //    }

        //    return zeroWorldPoint;

        //    /*Vector3 nearScreenPoint = new Vector3(ms.X, ms.Y, 0);
        //    Vector3 farScreenPoint = new Vector3(ms.X, ms.Y, 1);
        //    Vector3 nearWorldPoint = device.Viewport.Unproject(nearScreenPoint, cam.projectionMatrix, cam.viewMatrix, Matrix.Identity);
        //    Vector3 farWorldPoint = device.Viewport.Unproject(farScreenPoint, cam.projectionMatrix, cam.viewMatrix, Matrix.Identity);

        //    Vector3 direction = farWorldPoint - nearWorldPoint;

        //    float zFactor = -nearWorldPoint.Y / direction.Y;
        //    Vector3 zeroWorldPoint = nearWorldPoint + direction * zFactor;

        //    return zeroWorldPoint;*/
        //}

        //public static Vector2 GroundPosition(GraphicsDeviceManager graphics, Camera3d camera)
        //{
        //    Vector3 position3d = WorldPosition(graphics, camera);
        //    return new Vector2(position3d.X, position3d.Y);
        //}
    }
}
