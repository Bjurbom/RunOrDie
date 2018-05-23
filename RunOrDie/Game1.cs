using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunOrDie.Creatures;
using System;
using System.Collections.Generic;
using RunOrDie.Menus.PauseMenu;
using MonoGame.Extended;



namespace RunOrDie
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    //Gamestate Enum

    public enum Gamestate { InGame, Editing, Menu, Pause }

    public class Game1 : Game
    {
        Camera cameraPlayer;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D playerSprite;
        SpriteFont font;
        List<Players> playerList;
        PauseMenu pause;

       
        public static Game1 self;
        public static Gamestate gameState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            self = this;

            //setting value of screen resolutionen
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
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


            //Setting up the camera
            cameraPlayer = new Camera(graphics.GraphicsDevice.Viewport);



            //set the value of gamestate
            gameState = Gamestate.InGame;
            playerList = new List<Players>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerSprite = Content.Load<Texture2D>("Player");
            font = Content.Load<SpriteFont>("Spritefont");

            pause = new PauseMenu(font);

            playerList.Add(new Players(playerSprite, new ControlForPlayer(Keys.A, Keys.D, Keys.W, Keys.S), new Vector2(0f, 0f)));
        }

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

 




            if (gameState == Gamestate.InGame)
            {
                //Players Update
                foreach (Players player in playerList)
                {
                    player.Update(gameTime);
                    cameraPlayer.Update(player.Center);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Y))
                {
                    gameState = Gamestate.Pause;
                }
            }
            else if (gameState == Gamestate.Pause)
            {
                pause.Update(playerList[0]);
                IsMouseVisible = true;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, cameraPlayer.Transform);
            //players draw
            foreach (Players player in playerList)
            {
                player.Draw(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin();
            if (gameState == Gamestate.Pause)
            {
                pause.Draw(spriteBatch);
            }
            spriteBatch.DrawString(font, Convert.ToString(playerList[0].Position), new Vector2(0, 0), Color.Black);

            spriteBatch.DrawString(font, Convert.ToString(pause.Selector), new Vector2(0, 100), Color.Black);

            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Quit()
        {
             this.Exit();
        }
    }
}
