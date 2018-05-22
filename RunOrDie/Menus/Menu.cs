using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunOrDie.Menus
{
    class Menu
    {
        protected static int selection;
        protected List<BlockForMenu> Blocks;

        public Menu()
        {
            Blocks = new List<BlockForMenu>();
        }

        public int Selector
        {
            get
            {
                return selection;
            }
        }

        
    }
}
