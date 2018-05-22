using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace RunOrDie.Menus.PauseMenu
{
    class PauseMenu : Menu
    {

        private SpriteFont font;

        public PauseMenu(SpriteFont font)
        {
            this.font = font;

            Blocks.Add(new BlockForMenu(new Rectangle(50, 100, 200, 70), "Contiinue"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 150, 200, 70), "Save"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 200, 200, 70), "Load"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 250, 200, 70), "Quite"));

            Blocks[0].IsActive = true;

        }

        public void Update()
        {
            foreach (BlockForMenu block in Blocks)
            {

                //color on the block if player has chosen it
                if (block.IsActive)
                {
                    block.ColorOfBlock = Color.Green;
                }
                else
                {
                    block.ColorOfBlock = Color.Gray;
                }


            }
            

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BlockForMenu block in Blocks)
            {
                spriteBatch.DrawString(font, block.Text, new Vector2(block.Rectangle.X + 30 , block.Rectangle.Y + 20), Color.Black);
                spriteBatch.DrawRectangle(block.Rectangle,block.ColorOfBlock,20f);
            }

            
        }

    }
}
