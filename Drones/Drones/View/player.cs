using MonkeyGame.Helpers;
using MonkeyGame.Properties;
using System.Resources;

namespace MonkeyGame
{

    public partial class player
    {

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.player, X, Y, Width, Height);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
        }


    }
}
