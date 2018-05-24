using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;

namespace RunOrDie.Creatures
{
    class Players
    {
        private Texture2D sprite;
        private ControlForPlayer input;
        private Vector2 position, velocity, center, oldmouseposition, direction;
        float rotation;
        CircleF circle;

        public Players(Texture2D sprite, ControlForPlayer input, Vector2 position)
        {
            this.sprite = sprite;

            this.input = input;
            this.position = position;
        }

        #region properties
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public Vector2 Center
        {
            get
            {
                return center;
            }

        }
        #endregion

        public void Update(GameTime gameTime)
        {

            center = new Vector2(position.X + 32f, position.Y + 32);

            circle = new CircleF(center, 64);

            Move();
     
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, circle, Color.White);
            spriteBatch.DrawCircle(circle, 100, Color.Black, 10f);
        }

        private void Move()
        {
            //UP
            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                velocity.Y -= 1;
            }
            //down
            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                velocity.Y += 1;
            }
            //Left
            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                velocity.X -= 1;
            }
            //Right
            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                velocity.X += 1;
            }

            velocity = velocity * 0.95f;

            position += velocity;

        }
    }
}

