using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const int _ballNumber = 10;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball[] balls = new Ball[_ballNumber];
        Paddle paddle;

        public Random Random = new Random();

        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            paddle = new Paddle(this);
            for(int i = 0; i < _ballNumber; i++)
            {
                balls[i] = new Ball(this);
            }
            
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
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            foreach(Ball item in balls)
            {
                item.Initialize();
            }
            paddle.Initialize();
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
            foreach (Ball item in balls)
            {
                item.LoadContent(Content);
            }
            paddle.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            newKeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (newKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            paddle.Update(gameTime);
            foreach (Ball item in balls)
            {
                item.Update(gameTime);

                if (paddle.Bounds.CollidesWith(item.Bounds))
                {
                    item.Velocity.X *= -1;
                    var delta = (paddle.Bounds.X + paddle.Bounds.Width) - (item.Bounds.X - item.Bounds.Radius);
                    item.Bounds.X += 2 * delta;
                }
            }
            

            // TODO: Add your update logic here

            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (Ball item in balls)
            {
                item.Draw(spriteBatch);
            }
            paddle.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
