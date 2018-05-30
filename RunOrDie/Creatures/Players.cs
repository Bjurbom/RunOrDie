using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;
using RunOrDie.GameObjects.BlocksForLevel;

namespace RunOrDie.Creatures
{
    class Players
    {
        private Texture2D sprite;
        private ControlForPlayer input;
        private Vector2 position, velocity, center, oldmouseposition, direction;
        bool moveLeft, moveRight, moveUp, moveDown;
        CircleF circle;

        public Players(Texture2D sprite, ControlForPlayer input, Vector2 position)
        {
            this.sprite = sprite;

            this.input = input;
            this.position = position;

            moveDown = true;
            moveUp = true;
            moveRight = true;
            moveLeft = true;
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
        public CircleF Circle
        {
            get
            {
                return circle;
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
            if (Keyboard.GetState().IsKeyDown(input.Up) && moveUp)
            {
                velocity.Y -= 1.5f;
            }
            //down
            if (Keyboard.GetState().IsKeyDown(input.Down) && moveDown)
            {
                velocity.Y += 1.5f;
            }
            //Left
            if (Keyboard.GetState().IsKeyDown(input.Left) && moveLeft)
            {
                velocity.X -= 1.5f;
            }
            //Right
            if (Keyboard.GetState().IsKeyDown(input.Right) && moveRight)
            {
                velocity.X += 1.5f;
            }

            velocity = velocity * 0.89f;

            position += velocity;

        }
        public void Intersect(Players Player, StillBlocks obj)
        {
            
        }
    }
}

