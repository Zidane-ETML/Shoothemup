using MonkeyGame.Model;
using System.Threading;
using System.Resources;
using MonkeyGame.Properties;
namespace MonkeyGame
{
    public partial class player
    {
        private int x;
        private int y;

        private int _x;                                 // Position en X
        private int _y;                                 // Position en Y

        private int velocityY = 0;
        private bool isJumping = false;
        public int GroundY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle Hitbox { get;set; }


        public player(int X, int Y, int width, int height)
        {
            x = X;
            y = Y;
            GroundY = Y;
            Width = width;
            Height = height;
        }

        public int X { get { return x;} }
        public int Y { get { return y;} }
        public void move(int movex, int movey)
        {
            _x = movex;
            _y = movey;
            

        }
        public void Jump()
        {
            if (!isJumping) // sauter seulement si on est au sol
            {
                velocityY = -15; // vitesse initiale (vers le haut)
                isJumping = true;
            }
        }
        public void stopmove() 
        {
            _x = 0;
            _y = 0;
        }


        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            x += _x;
            y += _y;
            velocityY += 1;
            y += velocityY;

            if (y >= GroundY) 
            {
                y = GroundY;
                velocityY = 0;
                isJumping = false ;
            }
            Hitbox = new Rectangle(x, y, Resources.player.Width/10, Resources.player.Height/10);
        }

    }
}
