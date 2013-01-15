using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GamePadTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch inputDisp;
        SpriteFont displayTextFont;
        Texture2D pauseScreenBlanket;
        GamePadState previousGamePadState;
        bool pause = false;
        String tmpGameTime;
        PlayerInput playerOne=new PlayerInput();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1000;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            this.Window.Title = "Gamepad testing bed";
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            inputDisp = new SpriteBatch(GraphicsDevice);
            displayTextFont = Content.Load<SpriteFont>("SpriteFont1");
            pauseScreenBlanket= Content.Load<Texture2D>("PauseMenu");
            playerOne = new PlayerInput();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (!pause)
            {//If not paused
                //Stores game time for display(Doesn't update if the game is paused)
                tmpGameTime = gameTime.TotalGameTime.ToString();
                if (playerOne.getControllerState(pause))
                    this.Exit();
                if (previousGamePadState != null)
                {
                    if (playerOne.startButton && previousGamePadState.Buttons.Start == ButtonState.Released)
                    {
                        if (previousGamePadState.Buttons.Start == ButtonState.Released)
                        {

                            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                            pause = true;
                        }
                    }
                }
            }
            else
            {
                playerOne.getControllerState(pause);
                if (playerOne.startButton && previousGamePadState.Buttons.Start == ButtonState.Released)
                {
                    pause = false;
                }
            }

            if (previousGamePadState != null)
            {//Obtains previous button state
                previousGamePadState = playerOne.playerGamePadState;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Display to the Player
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            inputDisp.Begin();
            inputDisp.DrawString(displayTextFont, "Left thumb: " + playerOne.leftThumbStickVector.ToString() + " " + "Right thumb: " + playerOne.rightThumbstickVector.ToString(), new Vector2(10, 10), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Left Thumb x: " + playerOne.leftThumbstickXCoordinate.ToString(), new Vector2(10, 30), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Left Thumb y: " + playerOne.leftThumbstickYCoordinate.ToString(), new Vector2(300, 30), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Right Thumb x: " + playerOne.rightThumbstickXCoordinate.ToString(), new Vector2(10, 50), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Right Thumb y: " + playerOne.rightThumbstickYCoordinate.ToString(), new Vector2(300, 50), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Left Trigger: " + playerOne.tLeft.ToString(), new Vector2(10, 70), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Right Trigger: " + playerOne.tRight.ToString(), new Vector2(10, 90), Color.Blue);
            inputDisp.DrawString(displayTextFont, "A Button: " + playerOne.aButton.ToString(), new Vector2(10, 110), Color.Blue);
            inputDisp.DrawString(displayTextFont, "B Button: " + playerOne.bButton.ToString(), new Vector2(200, 110), Color.Blue);
            inputDisp.DrawString(displayTextFont, "X Button: " + playerOne.xButton.ToString(), new Vector2(10, 130), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Y Button: " + playerOne.yButton.ToString(), new Vector2(200, 130), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Left Shoulder Button: " + playerOne.leftShoulderButton.ToString(), new Vector2(10, 150), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Right Shoulder Button: " + playerOne.rightShoulderButton.ToString(), new Vector2(320, 150), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Left Thumb Button: " + playerOne.leftThumbstickButton.ToString(), new Vector2(10, 170), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Right Thumb Button: " + playerOne.rightThumbstickButton.ToString(), new Vector2(300, 170), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Dpad Up: " + playerOne.dPadUp.ToString(), new Vector2(10, 190), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Dpad Down: " + playerOne.dPadDown.ToString(), new Vector2(300, 190), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Dpad Left: " + playerOne.dPadLeft.ToString(), new Vector2(10, 210), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Dpad Right: " + playerOne.dPadRight.ToString(), new Vector2(300, 210), Color.Blue);
            inputDisp.DrawString(displayTextFont, "Game Time: " + tmpGameTime, new Vector2(10, 230), Color.Blue);
            if (pause)
            {
                inputDisp.Draw(pauseScreenBlanket, Vector2.Zero, Color.Red);
                inputDisp.DrawString(displayTextFont, "Game Paused", new Vector2(435, 270), Color.Blue);
            }
            inputDisp.End();
            base.Draw(gameTime);
        }
    }
}
