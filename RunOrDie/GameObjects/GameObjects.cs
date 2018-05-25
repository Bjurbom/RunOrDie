using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunOrDie.GameObjects
{
    abstract class GameObjects
    {
        protected Vector2 position;
        protected Texture2D sprite;
        protected Rectangle rectangle;
        protected int size;

        public GameObjects(Vector2 position, int size)
        {
            this.position = position;
            this.size = size;
        }

        #region Properties

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }

        #endregion


        public abstract void Draw(SpriteBatch spriteBatch);
        

        
    }
}
