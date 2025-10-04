using MonkeyGame.Model;

namespace MonkeyGame
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Beach : Form
    {
        public static readonly int WIDTH = 1536;        // Dimensions of the airspace
        public static readonly int HEIGHT = 1024;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<player> group;

        BufferedGraphicsContext currentContext;
        BufferedGraphics beach;
        // Initialisation de l'espace aérien avec un certain nombre de drones
        public List<Palm_tree> palm_Trees = new List<Palm_tree>();

        public Beach(List<player> group)
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            beach = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.group = group;
            this.KeyPreview = true; // Ensures the form captures key events before child controls
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            palm_Trees = new List<Palm_tree>
            {
                new Palm_tree(200, 400, 100, 220),
                new Palm_tree(500, 400, 100, 220)
            };
        }
        
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (player monkey in group)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        monkey.move(-10, 0);
                        break;
                    case Keys.D:
                        monkey.move(10, 0);
                        if (monkey.X == 0 || monkey.X == WIDTH)
                        {
                            monkey.stopmove();
                        }
                        break;
                    case Keys.Space:
                        monkey.Jump();
                        break;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs i)
        {
            foreach (player monkey in group)
            {
                switch (i.KeyCode)
                {
                    case Keys.A:
                        monkey.stopmove();
                        break;
                    case Keys.D:
                        monkey.stopmove();
                        break;
                }
            }
            
        }
        
            // Affichage de la situation actuelle
            private void Render()
        {

            Image beachImg = new Bitmap("C:\\Users\\pd01wvj\\Documents\\GitHub\\shoothemup\\Drones\\Drones\\Resources\\playa.png");

            beach.Graphics.DrawImage(beachImg, 0, 0, WIDTH, HEIGHT);

            foreach (Palm_tree palmier in palm_Trees)
            {
                palmier.Draw(beach.Graphics);
            }

            // draw drones
            foreach (player monkey in group)
            {
                monkey.Render(beach);
            }

            beach.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (player drone in group)
            {
                drone.Update(interval, palm_Trees);
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}