using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace MonkeyGame
{
    public partial class Palm_Tree
    {
        private int x = 499;
        private int y = 500;

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Rectangle Hitbox { get; set; }
    }
}
