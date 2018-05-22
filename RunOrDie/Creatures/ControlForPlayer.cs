using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunOrDie.Creatures
{
    public class ControlForPlayer
    {
        public Keys Left;
        public Keys Right;
        public Keys Up;
        public Keys Down;

        public ControlForPlayer(Keys Left, Keys Right, Keys Up, Keys Down)
        {
            this.Left = Left;
            this.Right = Right;
            this.Down = Down;
            this.Up = Up;
        }
    }
}
