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
        protected int choices;
        protected int Selection;
        protected List<BlockForMenu> Blocks;

        public Menu()
        {
            
            Blocks = new List<BlockForMenu>();
        }

        
    }
}
