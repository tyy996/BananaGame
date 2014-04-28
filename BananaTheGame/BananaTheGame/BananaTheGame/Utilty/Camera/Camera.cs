using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using BananaTheGame.Entities;
using BananaTheGame.Terrain;

namespace BananaTheGame
{
    public class Camera
    {
        private float viewAngle;
        private float nearPlane;
        private float farPlane;

        private Vector3 cameraFinalTarget;
        //private Vector3 lookVector;
        private Texture2D reticleTexture;

        public const float ROTATION_SPEED = 0.1f;

        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }
        public Viewport CameraViewPort { get; private set; }

        public Vector3 Position { get; set; }
        public float LeftRightRotation { get; set; }
        public float UpDownRotation { get; set; }
        public Vector3 LookVector { get; private set; }

        public Entity Target { get; set; }
        public Vector3 TargetOffset { get; set; }
        public bool FollowTaget { get; set; }
        public bool RotateWithTarget { get; set; }

        public Camera()
        {
            viewAngle = MathHelper.PiOver4;
            nearPlane = 0.01f;
            farPlane = 220 * 4;
            //farPlane = 10000.0f;
            UpDownRotation = 0f;
            LeftRightRotation = 0f;
            CameraViewPort = BananaGame.Graphics.Viewport;
            reticleTexture = BananaGame.GameContent.Load<Texture2D>("Textures//MousePoint");

            //Position = new Vector3(0, 20, 0);
            Position = new Vector3(0.0f, 0f, 2f);
            //Position = Vector3.Zero;
            calculateProjection();
        }

        private void calculateProjection()
        {
            Projection = Matrix.CreatePerspectiveFieldOfView(viewAngle, BananaGame.Graphics.Viewport.AspectRatio, nearPlane, farPlane);
            //Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), FenceGame.Graphics.Viewport.AspectRatio, 1.0f, 10000.0f);
        }

        private void calculateView()
        {
            CameraViewPort = BananaGame.Graphics.Viewport;
            Matrix rotationMatrix = Matrix.CreateRotationX(UpDownRotation) * Matrix.CreateRotationY(LeftRightRotation);
            LookVector = Vector3.Transform(Vector3.Forward, rotationMatrix);

            cameraFinalTarget = Position + LookVector;

            Vector3 cameraRotatedUpVector = Vector3.Transform(Vector3.Up, rotationMatrix);
            View = Matrix.CreateLookAt(Position, cameraFinalTarget, cameraRotatedUpVector);
            //View = Matrix.CreateLookAt(Position, new Vector3(1, 0, 1), Vector3.Up);
        }

        private void calculateView2d()
        {
            CameraViewPort = BananaGame.Graphics.Viewport;
            LookVector = Vector3.Forward;

            Matrix rotationMatrix = Matrix.CreateFromYawPitchRoll(0, 0.5f, 0);
            LookVector = Vector3.Transform(Vector3.Forward, rotationMatrix);

            cameraFinalTarget = Position + LookVector;
            View = Matrix.CreateLookAt(Position, cameraFinalTarget, Vector3.Up);
        }

        public void LookAt(Vector3 target)
        {
            // Doesn't take into account the rotated UP vector
            // Should calculate rotations here!
            //View = Matrix.CreateLookAt(Position, target, Vector3.Up);
        }

        public string LookDirection
        {
            get
            {
                Vector3 peer = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationY(LeftRightRotation));
                float radian = ((float)Math.Atan2(peer.X, peer.Z)) + 3.141592f;
                float degree = MathHelper.ToDegrees(radian);
                if (degree > 225 && degree < 315)
                    return "+X";
                else if (degree > 135 && degree < 225)
                    return "+Z";
                else if (degree > 45 && degree < 135)
                    return "-X";
                else
                    return "-Z";
            }
        }

        #region Update
        public void Update(GameTime gameTime)
        {
            if (FollowTaget)
                Position = new Vector3(Target.Position, 0) + TargetOffset;
            calculateView2d();
        }
        #endregion

        public void Draw()
        {
            Point startPoint = new Point(CameraViewPort.Width / 2 - 8, CameraViewPort.Height / 2 - 8);
            BananaGame.GameSpriteBatch.Draw(reticleTexture, new Rectangle(startPoint.X, startPoint.Y, 16, 16), Color.White);
        }
    }
}
