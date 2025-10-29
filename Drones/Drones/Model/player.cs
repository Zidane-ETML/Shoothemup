using MonkeyGame.Model;
using System.Threading;
using System.Resources;
using MonkeyGame.Properties;
namespace MonkeyGame
{
    public partial class player
    {
        private int _x;
        private int _y;

        private int speedx;                                 // Position en X
        private int speedy;                                 // Position en Y

        private int velocityY = 0;
        private bool isJumping = false;
        public int GroundY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get;set; }


        public player(int X, int Y, int width, int height)
        {
            _x = X;
            _y = Y;
            GroundY = 600;
            Width = width;
            Height = height;
        }


        public void move(int movex, int movey)
        {
            speedx = movex;
            speedy = movey;
            

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
            speedx = 0;
            speedy = 0;
        }


        // Cette méthode calcule le nouvel état dans lequel le joueur se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            _x += speedx;
            _y += speedy;
            velocityY += 1;
            _y += velocityY;

            if (_y >= GroundY) 
            {
                _y = GroundY;
                velocityY = 0;
                isJumping = false ;
            }
            Hitbox = new Rectangle(_x, _y, Width, Height);
        }

    }
}
