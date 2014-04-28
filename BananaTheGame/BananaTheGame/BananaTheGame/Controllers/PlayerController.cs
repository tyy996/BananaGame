using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using BananaTheGame.Entities;

namespace BananaTheGame.Controllers
{
    public class PlayerController : Controller
    {
        public const Keys DEFAULT_FORWARD_KEY = Keys.W;
        public const Keys DEFAULT_BACK_KEY = Keys.S;
        public const Keys DEFAULT_LEFT_KEY = Keys.A;
        public const Keys DEFAULT_RIGHT_KEY = Keys.D;
        public const Keys DEFAULT_JUMP_KEY = Keys.Space;
        public const Keys DEFAULT_DECEND_KEY = Keys.LeftShift;

        public Keys ForwardKey { get; set; }
        public Keys BackKey { get; set; }
        public Keys LeftKey { get; set; }
        public Keys RightKey { get; set; }
        public Keys JumpKey { get; set; }
        public Keys DecendKey { get; set; }

        public Player SelectedPlayer { get; private set; }

        public PlayerController(Player player)
        {
            SelectedPlayer = player;
            ResetDefaultKeys();
        }

        public override void Update()
        {
            Vector2 moveVector = Vector2.Zero;

            if (GameKeyState.IsKeyDown(ForwardKey))
            {
                moveVector += new Vector2(0,1);
                if (SelectedPlayer.Collection.CurrentAnimationName != "up") //move to player
                    SelectedPlayer.Collection.PlayAnimation("up");
            }
            else if (GameKeyState.IsKeyDown(BackKey))
            {
                moveVector += new Vector2(0, -1);
                if (SelectedPlayer.Collection.CurrentAnimationName != "down")
                    SelectedPlayer.Collection.PlayAnimation("down");
            }
            else if (GameKeyState.IsKeyDown(LeftKey))
            {
                moveVector += new Vector2(-1, 0);
                if (SelectedPlayer.Collection.CurrentAnimationName != "left")
                    SelectedPlayer.Collection.PlayAnimation("left");
            }
            else if (GameKeyState.IsKeyDown(RightKey))
            {
                moveVector += new Vector2(1, 0);
                if (SelectedPlayer.Collection.CurrentAnimationName != "right")
                    SelectedPlayer.Collection.PlayAnimation("right");
            }
            else
            {
                if (SelectedPlayer.Collection.CurrentAnimationName == "up")
                {
                    SelectedPlayer.Collection.PlayAnimation("standUp");
                }
                else if (SelectedPlayer.Collection.CurrentAnimationName == "down")
                {
                    SelectedPlayer.Collection.PlayAnimation("standDown");
                }
                else if (SelectedPlayer.Collection.CurrentAnimationName == "left")
                {
                    SelectedPlayer.Collection.PlayAnimation("standLeft");
                }
                else if (SelectedPlayer.Collection.CurrentAnimationName == "right")
                {
                    SelectedPlayer.Collection.PlayAnimation("standRight");
                }
            }

            //if (GameKeyState.IsKeyDown(JumpKey))
            //{
            //    moveVector += Vector3.Up;
            //}

            //if (GameKeyState.IsKeyPressed(Keys.F))
            //{
            //    Diamond dia = new Diamond(SelectedPlayer.Scanner.NearAimPoint);
            //    dia.Direction = FenceGame.GameCamera.LookVector;
            //    dia.Load();
            //    ProjectileManager.Add(dia);
            //}

            //if (GameKeyState.IsKeyPressed(Keys.J))
            //{
            //    SelectedPlayer.PhysicsModel.IsJumping = true;
            //}

            //if (GameKeyState.IsKeyDown(DecendKey))
            //{
            //    moveVector += Vector3.Down;
            //}

            //if (GameKeyState.IsKeyPressed(Keys.Q))
            //{
            //    SelectedPlayer.TestTool.SwitchItems();
            //}

            //if (GameMouseState.IsLeftButtonClicked())
            //{
            //    SelectedPlayer.TestTool.Use();
            //}

            //if (GameMouseState.IsMiddleButtonClicked())
            //{
            //    SelectedPlayer.TestTool.AltUse();
            //}

            //if (GameKeyState.IsKeyPressed(Keys.NumPad9))
            //{
            //    SelectedPlayer.TestTool.BuildTool.RotateRight();
            //}

            if (moveVector != Vector2.Zero)
            {
                //Matrix rotationMatrix = Matrix.CreateRotationY(FenceGame.GameCamera.LeftRightRotation);
                //Vector3 rotatedVector = Vector3.Transform(moveVector, rotationMatrix);
                SelectedPlayer.AddAcceleration(moveVector);
            }
        }

        public void ResetDefaultKeys()
        {
            ForwardKey = DEFAULT_FORWARD_KEY;
            BackKey = DEFAULT_BACK_KEY;
            LeftKey = DEFAULT_LEFT_KEY;
            RightKey = DEFAULT_RIGHT_KEY;
            JumpKey = DEFAULT_JUMP_KEY;
            DecendKey = DEFAULT_DECEND_KEY;
        }
    }
}
