using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace MonkeyGame
{
    public partial class Palm_Tree
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.tree, X, Y, 50, 50);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
        }
    }
}
