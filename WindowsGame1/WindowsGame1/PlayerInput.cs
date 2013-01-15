using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GamePadTest
{
    class PlayerInput
    {

        public GamePadState playerGamePadState = new GamePadState();
        public Vector2 leftThumbStickVector;
        public Vector2 rightThumbstickVector;
        public float rightThumbstickXCoordinate;
        public float rightThumbstickYCoordinate;
        public float leftThumbstickXCoordinate;
        public float leftThumbstickYCoordinate;
        public float tRight;
        public float tLeft;
        public bool aButton = false;      //Buttons
        public bool bButton = false;
        public bool xButton = false;
        public bool yButton = false;
        public bool rightShoulderButton = false;     //Shoulder buttons
        public bool leftShoulderButton = false;
        public bool leftThumbstickButton = false;     //Thumbstick
        public bool rightThumbstickButton = false;
        public bool dPadUp = false;     //D-Pad
        public bool dPadDown = false;
        public bool dPadLeft = false;
        public bool dPadRight = false;
        public bool startButton = false;

        public bool getControllerState(bool pause)
        {
            playerGamePadState = GamePad.GetState(PlayerIndex.One);

            //Start button
            if(playerGamePadState.Buttons.Start == ButtonState.Pressed)
            {
                startButton = true;
            }
            else
            {
                startButton = false;
            }
            if (!pause)
            {
                //Ends the game
                if (playerGamePadState.Buttons.Back == ButtonState.Pressed)
                    return true;

                //Obtain direction from Left thumb stick
                leftThumbStickVector = playerGamePadState.ThumbSticks.Left;
                leftThumbstickXCoordinate = leftThumbStickVector.X;
                leftThumbstickYCoordinate = leftThumbStickVector.Y;

                //Obtain direction from right thumb stick
                rightThumbstickVector = playerGamePadState.ThumbSticks.Right;
                rightThumbstickXCoordinate = rightThumbstickVector.X;
                rightThumbstickYCoordinate = rightThumbstickVector.Y;

                //Triggers
                tRight = playerGamePadState.Triggers.Right;
                tLeft = playerGamePadState.Triggers.Left;

                //Buttons
                if (playerGamePadState.Buttons.A == ButtonState.Pressed)
                {
                    //SuppressDraw();
                    GamePad.SetVibration(PlayerIndex.One, tLeft, tRight);
                    aButton = true;
                }
                else
                {
                    GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                    aButton = false;
                }

                if (playerGamePadState.Buttons.B == ButtonState.Pressed)
                {
                    bButton = true;
                }
                else
                {
                    bButton = false;
                }
                if (playerGamePadState.Buttons.X == ButtonState.Pressed)
                {
                    xButton = true;
                }
                else
                {
                    xButton = false;
                }
                if (playerGamePadState.Buttons.Y == ButtonState.Pressed)
                {
                    yButton = true;
                }
                else
                {
                    yButton = false;
                }

                //Shoulder buttons
                if (playerGamePadState.Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    leftShoulderButton = true;
                }
                else
                {
                    leftShoulderButton = false;
                }
                if (playerGamePadState.Buttons.RightShoulder == ButtonState.Pressed)
                {
                    rightShoulderButton = true;
                }
                else
                {
                    rightShoulderButton = false;
                }

                //Thumbstick buttons
                if (playerGamePadState.Buttons.LeftStick == ButtonState.Pressed)
                {
                    leftThumbstickButton = true;
                }
                else
                {
                    leftThumbstickButton = false;
                }
                if (playerGamePadState.Buttons.RightStick == ButtonState.Pressed)
                {
                    rightThumbstickButton = true;
                }
                else
                {
                    rightThumbstickButton = false;
                }

                //Dpad
                if (playerGamePadState.DPad.Up == ButtonState.Pressed)
                {
                    dPadUp = true;
                }
                else
                {
                    dPadUp = false;
                }
                if (playerGamePadState.DPad.Down == ButtonState.Pressed)
                {
                    dPadDown = true;
                }
                else
                {
                    dPadDown = false;
                }

                if (playerGamePadState.DPad.Left == ButtonState.Pressed)
                {
                    dPadLeft = true;
                }
                else
                {
                    dPadLeft = false;
                }
                if (playerGamePadState.DPad.Right == ButtonState.Pressed)
                {
                    dPadRight = true;
                }
                else
                {
                    dPadRight = false;
                }
            }
            return false;
        }
    }
}
