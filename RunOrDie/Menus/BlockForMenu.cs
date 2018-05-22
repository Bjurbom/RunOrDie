using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunOrDie.Menus
{
    class BlockForMenu
    {
        Rectangle rectangle;
        bool isActive;

        public BlockForMenu(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        #region properies
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
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

    }
}
