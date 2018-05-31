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
        private Rectangle recUp, recDown, recLeft, recRight, upperRight,upperRightUp,upperRightRight,upperLeft, underRight,underRightRight,underRightDown,underLeft, upperLeftUp, upperLeftLeft, underLeftLeft,underLeftDown;
        bool moveLeft, moveRight, moveUp, moveDown;
        CircleF circle;
        private bool upperLeftDisableUp, upperLeftDisableLeft, upperRightDisasbleUp, upperRightDisableRight, underRightDisableRight,underRightDisableDown, underLeftDisableDown, underLeftDisableLeft;

        public Players(Texture2D sprite, ControlForPlayer input, Vector2 position)
        {
            this.sprite = sprite;

            this.input = input;
            this.position = position;

            ResetTheBools();
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
        public Rectangle RecUp
        {
            get
            {
                return recUp;
            }
        }
        public Rectangle RecDown
        {
            get
            {
                return recDown;
            }
        }
        public Rectangle RecRight
        {
            get
            {
                return recRight;
            }
        }
        public Rectangle RecLeft
        {
            get
            {
                return recLeft;
            }
        }
        public Rectangle UpperRight
        {
            get
            {
                return upperRight;
            }
        }
        public bool MoveUp{ get { return moveUp; } set { moveUp = value; } }
        public bool MoveLeft { get { return moveLeft; } set { moveLeft = value; } }
        public bool MoveRight { get { return moveRight; } set { moveRight = value; } }
        public bool MoveDown { get { return moveDown; } set { moveDown = value; } }

        #endregion

        public void Update(GameTime gameTime)
        {

            center = new Vector2(position.X + 32f, position.Y + 32);
            circle = new CircleF(center, 64);


            //Hitbox drawing out every update
            recUp = new Rectangle((int)center.X - 10, (int)center.Y -100, 10, 100);
            recDown = new Rectangle((int)center.X - 10, (int)center.Y, 10, 100);
            recRight = new Rectangle((int)center.X, (int)center.Y - 10, 100, 10);
            recLeft = new Rectangle((int)center.X - 100, (int)center.Y - 10, 100, 10);

            //hitbox for upperleft
            #region Upperleft
            upperLeft = new Rectangle((int)center.X - 30, (int)center.Y - 30, 30, 30);

            if (upperLeftDisableLeft)
            {
                upperLeftLeft = new Rectangle(upperLeft.X - 30, upperLeft.Y -5, 30, 5);
            }
           
           
            if (upperLeftDisableUp)
            {
                upperLeftUp = new Rectangle(upperLeft.X - 5, upperLeft.Y - 30, 5, 30);
            }

            #endregion

            //hitbox for upperRight
            #region UpperRight
            upperRight = new Rectangle((int)center.X, (int)center.Y - 30, 30, 30);

            if (upperRightDisasbleUp)
            {
                upperRightUp = new Rectangle((int)upperRight.X + 30, (int)upperRight.Y - 30, 5, 30);
            }

            if (upperRightDisableRight)
            {
                upperRightRight = new Rectangle((int)upperRight.X + 30, (int)upperRight.Y - 5, 30, 5);
            }
            #endregion

            //hitbox for underRight
            #region underRight
            underRight = new Rectangle((int)center.X, (int)center.Y, 30, 30);

            if (underRightDisableRight)
            {
                underRightRight = new Rectangle((int)underRight.X + 30, (int)underRight.Y + 30, 30, 5);
            }

            if (underRightDisableDown)
            {
                underRightDown = new Rectangle((int)underRight.X +30 , (int)underRight.Y + 30 , 5, 30);
            }
            #endregion

            //hitbox for underLeft
            #region underLeft
            underLeft = new Rectangle((int)center.X - 30, (int)center.Y, 30, 30);

            if (underLeftDisableLeft)
            {
                underLeftLeft = new Rectangle((int)underLeft.X - 30, (int)underLeft.Y + 30, 30, 5);
            }

            if (underLeftDisableDown)
            {
                underLeftDown = new Rectangle((int)underLeft.X, (int)underLeft.Y + 35, 5, 30);
            }
            #endregion

            Move();

     
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, circle, Color.White);
            spriteBatch.DrawCircle(circle, 100, Color.Black, 10f);

            if(Game1.debug == Debug.True)
            {

                //the whole body (sorta)
                spriteBatch.DrawRectangle(recUp, Color.Red);
                spriteBatch.DrawRectangle(recDown, Color.Red);
                spriteBatch.DrawRectangle(recRight, Color.Red);
                spriteBatch.DrawRectangle(recLeft, Color.Red);

                //upperleft
                spriteBatch.DrawRectangle(upperLeft, Color.Red);
                spriteBatch.DrawRectangle(upperLeftUp, Color.Red);
                spriteBatch.DrawRectangle(upperLeftLeft, Color.Red);

                //upperRight
                spriteBatch.DrawRectangle(upperRight, Color.Red);
                spriteBatch.DrawRectangle(upperRightUp, Color.Red);
                spriteBatch.DrawRectangle(upperRightRight, Color.Red);

                //underRight
                spriteBatch.DrawRectangle(underRight, Color.Red);
                spriteBatch.DrawRectangle(underRightRight, Color.Red);
                spriteBatch.DrawRectangle(underRightDown, Color.Red);

                //underLeft
                spriteBatch.DrawRectangle(underLeft, Color.Red);
                spriteBatch.DrawRectangle(underLeftLeft, Color.Red);
                spriteBatch.DrawRectangle(underLeftDown, Color.Red);
            }
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
        public void Intersect(Players player, StillBlocks block)
        {
            //body hitbox
            #region Hitbox
            if (player.RecUp.Intersects(block.Rectangle))
            {
                moveUp = false;
                if (velocity.Y <= 0f)
                {
                    velocity.Y = 0f;
                }
              
            }
            else
            {
                moveUp = true;
            }

            if (player.RecDown.Intersects(block.Rectangle))
            {
                moveDown = false;
                if (velocity.Y >= 0f)
                {
                    velocity.Y = 0f;
                }

            }
            else
            {
                moveDown = true;
            }

            if (player.RecRight.Intersects(block.Rectangle))
            {
                moveRight = false;
                if (velocity.X >= 0f)
                {
                    velocity.X = 0f;
                }

            }
            else
            {
                moveRight = true;
            }

            if (player.RecLeft.Intersects(block.Rectangle))
            {
                moveLeft = false;
                if (velocity.X <= 0f)
                {
                    velocity.X = 0f;
                }

            }
            else
            {
                moveLeft = true;
            }
            #endregion

            //upper Left hitbox
            #region upperLeft
            if (player.upperLeftUp.Intersects(block.Rectangle))
            {
                upperLeftDisableLeft = false;
                if (player.upperLeft.Intersects(block.Rectangle))
                {
                    velocity.X += 1;
                }
            }
            if (player.upperLeftLeft.Intersects(block.Rectangle))
            {
                upperLeftDisableUp = false;
                if (player.upperLeft.Intersects(block.Rectangle))
                {
                    velocity.Y += 1;

                }
            }
            #endregion

            //upper Right hitbox
            #region UpperRight
            if (player.upperRightUp.Intersects(block.Rectangle))
            {
                upperRightDisableRight = false;
                if (player.upperRight.Intersects(block.Rectangle))
                {
                    velocity.X -= 1;
                    velocity.Y -= 1;
                }
            }

            if (player.upperRightRight.Intersects(block.Rectangle))
            {
                upperRightDisasbleUp = false;
                if (player.upperRight.Intersects(block.Rectangle))
                {
                    velocity.Y += 1;
                }
            }
            #endregion

            //under Right hitbox
            #region underRight
            if (player.underRightRight.Intersects(block.Rectangle))
            {
                underRightDisableDown = false;
                if (player.underRight.Intersects(block.Rectangle))
                {
                    velocity.Y += 1;
                }
            }

            if (player.underRightDown.Intersects(block.Rectangle))
            {
                underRightDisableRight = false;
                if (player.underRight.Intersects(block.Rectangle))
                {
                    velocity.X -= 1;
                }
            }
            #endregion

            //under Left hibox
            #region underLeft
            if (player.underLeftLeft.Intersects(block.Rectangle))
            {
                underLeftDisableDown = false;
                if (player.underLeft.Intersects(block.Rectangle))
                {
                    velocity.Y -= 1;
                }
            }

            if (player.underLeftDown.Intersects(block.Rectangle))
            {
                underLeftDisableLeft = false;
                if (player.underLeft.Intersects(block.Rectangle))
                {
                    velocity.X += 1;
                }
            }
            #endregion
        }

        public void ResetTheBools()
        {
            moveDown = true;
            moveUp = true;
            moveRight = true;
            moveLeft = true;
            upperLeftDisableUp = true;
            upperLeftDisableLeft = true;
            upperRightDisableRight = true;
            upperRightDisasbleUp = true;
            underRightDisableDown = true;
            underRightDisableRight = true;
            underLeftDisableDown = true;
            underLeftDisableLeft = true;
        }
    }
}

