using System.Threading;
namespace MonkeyGame
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class player
    {
        private int x;
        private int y;

        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien

        // Constructeur
        public player(int X, int Y, string name)
        {
            x = X;
            y = Y;
        }
        public int X { get { return x;} }
        public int Y { get { return y;} }
        public void move(int movex, int movey)
        {
            _x = movex;
            _y = movey;
            if (_x == Beach.WIDTH)
            {
                _x = 0;
            }

        }
        public void stopmove(int movex, int movey) 
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
        }

    }
}
