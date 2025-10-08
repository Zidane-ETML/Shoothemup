using MonkeyGame.Helpers;
using MonkeyGame.Properties;
using System.Resources;

namespace MonkeyGame
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class player
    {

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.player, X, Y, 50, 50);
        }

    }
}
