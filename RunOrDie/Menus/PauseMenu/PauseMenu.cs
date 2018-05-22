using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
namespace RunOrDie.Menus.PauseMenu
{
    class PauseMenu : Menu
    {

        private SpriteFont font;
        KeyboardState newState, oldState;

        public PauseMenu(SpriteFont font)
        {
            this.font = font;

            Blocks.Add(new BlockForMenu(new Rectangle(50, 100, 200, 70), "Contiinue"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 170, 200, 70), "Save"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 240, 200, 70), "Load"));
            Blocks.Add(new BlockForMenu(new Rectangle(50, 310, 200, 70), "Quite"));

            selection = 0;
           

        }

        public void Update()
        {
            //uppdating the keystate
            newState = Keyboard.GetState();

            //selectors movement and changes
            SelectorsMovments();
            //selectors lighting 
            SelectorLighUp();

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

            //inserting the keypress into the old state
            oldState = newState;

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BlockForMenu block in Blocks)
            {
                spriteBatch.DrawString(font, block.Text, new Vector2(block.Rectangle.X + 30 , block.Rectangle.Y + 20), Color.Black);
                spriteBatch.DrawRectangle(block.Rectangle,block.ColorOfBlock,20f);
            }

            
        }



        private void SelectorsMovments()
        {
            //keylogic addition and subtraction
            if (newState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W))
            {
                if (selection >= 1)
                {
                    selection--;
                }

            }
            if (newState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S))
            {
                if ( (Blocks.Count - 1 ) >= selection)
                {
                    if (selection == 3)
                    {

                    }
                    else
                    selection++;
                }

            }
        }

        private void SelectorLighUp()
        {
            //could be better but it works for now
            if (Blocks[selection].IsActive == false)
            {

                Blocks[selection].IsActive = true;
            }
            else
            {
                if (selection != 3)
                {
                    Blocks[selection + 1].IsActive = false;
                }
                if (selection != 0)
                {
                    Blocks[selection - 1].IsActive = false;
                }

            }
        }
    }
}
