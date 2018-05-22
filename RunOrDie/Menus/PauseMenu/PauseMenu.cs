using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RunOrDie.Menus.PauseMenu
{
    class PauseMenu : Menu
    {
        int temp;
        Color colorOfBlock;

        public PauseMenu(int choices):base(choices)
        {
            temp = 0;
             
            for (int i = 0; i <= choices; i++)
            {
                Blocks[i] = new BlockForMenu(new Rectangle(50, temp, 200, 30));
                temp += 50;
            }
        }

        public void Update()
        {
            foreach (BlockForMenu block in Blocks)
            {




                //color on the block if player has chosen it
                if (block.IsActive)
                {
                    colorOfBlock = Color.Green;
                }
                else
                {
                    colorOfBlock = Color.Gray;
                }
            }
            

            
        }

        public void spriteBatch(SpriteBatch spriteBatch)
        {
            foreach (BlockForMenu block in Blocks)
            {
                spriteBatch.DrawRectangle(block.Rectangle,colorOfBlock,3f);
            }

            
        }

    }
}
