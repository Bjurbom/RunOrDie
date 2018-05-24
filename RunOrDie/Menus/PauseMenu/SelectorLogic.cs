using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunOrDie.Menus.PauseMenu
{
    class SelectorLogic : Menu
    {
        public SelectorLogic()
        {
        
        }

        public void Update()
        {
            //continue
            if (selection == 0 && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Game1.gameState = Gamestate.InGame;
            }
            //save
            if (selection == 1 && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                
            }
            //load
            if (selection == 2 && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                
            }
            //quit
            if (selection == 3 && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Game1.self.Exit();
            }
        }
    }
}
