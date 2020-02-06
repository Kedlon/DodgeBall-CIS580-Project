using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Player
    {
        /// <summary>
        /// The game object
        /// </summary>
        Game1 game;
        
        /// <summary>
        /// The Bounds for this player
        /// </summary>
        public BoundingRectangle Bounds;
        
        /// <summary>
        /// The Texture for this player
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="game">The game this player belongs to</param>
        public Player(Game1 game)
        {
            this.game = game;
        }

        /// <summary>
        /// Sets the players initial size, bounds, and position on the screen.
        /// </summary>
        public void Initialize()
        {
            Bounds.Width = 50;
            Bounds.Height = 50;
            Bounds.X = 0;
            Bounds.Y = game.GraphicsDevice.Viewport.Height / 2 - Bounds.Height / 2;
        }

        /// <summary>
        /// loads the content related to the player
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        /// <summary>
        /// Updates the state of the player
        /// </summary>
        /// <param name="gameTime">The game's GameTime</param>
        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                // move up
                Bounds.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                // move down
                Bounds.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // move down
                Bounds.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                // move down
                Bounds.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            //checks if player collides with walls of the viewport
            if (Bounds.Y < 0)
            {
                Bounds.Y = 0;
            }
            if (Bounds.Y > game.GraphicsDevice.Viewport.Height - Bounds.Height)
            {
                Bounds.Y = game.GraphicsDevice.Viewport.Height - Bounds.Height;
            }
            if (Bounds.X < 0)
            {
                Bounds.X = 0;
            }
        }

        /// <summary>
        /// Draws the player
        /// </summary>
        /// <param name="spriteBatch">
        /// The SpriteBatch to draw the paddle with.  This method should 
        /// be invoked between SpriteBatch.Begin() and SpriteBatch.End() calls.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, Color.Green);
        }
    }
}
