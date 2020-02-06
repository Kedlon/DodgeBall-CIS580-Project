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
    public class FieldLine
    {
        Game1 game;
        
        public BoundingRectangle Bounds;
        
        Texture2D texture;

        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="game">The game this player belongs to</param>
        public FieldLine(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            Bounds.Width = 25;
            Bounds.Height = game.GraphicsDevice.Viewport.Height;
            Bounds.X = game.GraphicsDevice.Viewport.Width/ 2;
            Bounds.Y = game.GraphicsDevice.Viewport.Height / 2 - Bounds.Height / 2;
        }


        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, Color.Black);
        }
    }
}
