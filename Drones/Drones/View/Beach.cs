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
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (player drone in group)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        drone.move(-10, 0);
                        break;
                    case Keys.D:
                        drone.move(10, 0);
                        break;
                    case Keys.Space:

                        break;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs i)
        {
            foreach (player drone in group)
            {
                switch (i.KeyCode)
                {
                    case Keys.A:
                        drone.stopmove(0, 0);
                        break;
                    case Keys.D:
                        drone.stopmove(0, 0);
                        break;
                }
            }
            
        }
        
            // Affichage de la situation actuelle
            private void Render()
        {

            Image beachImg = new Bitmap("C:\\Users\\pd01wvj\\Documents\\GitHub\\shoothemup\\Drones\\Drones\\Resources\\playa.png");

            beach.Graphics.DrawImage(beachImg, 0, 0, WIDTH, HEIGHT);

            // draw drones
            foreach (player drone in group)
            {
                drone.Render(beach);
            }

            beach.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (player drone in group)
            {
                drone.Update(interval);
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