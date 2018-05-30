using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace RunOrDie.GameObjects.BlocksForLevel
{
    class StillBlocks : GameObjects
    {


        public StillBlocks(Vector2 position, int size) : base(position, size)
        {
            rectangle = new Rectangle((int)position.X,(int)position.Y,size,size);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(rectangle, Color.Red, 2);
        }
    }
}
