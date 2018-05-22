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
        private string text;
        bool isActive;
        Color colorOfBlock;
        

        public BlockForMenu(Rectangle rectangle, string text)
        {
            this.rectangle = rectangle;
            this.text = text;
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

        public string Text
        {
            get
            {
                return text;
            }
        }

        public Color ColorOfBlock
        {
            get
            {
                return colorOfBlock;
            }
            set
            {
                colorOfBlock = value;
            }
        }
        #endregion

    }
}
