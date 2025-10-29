using MonkeyGame.Model;
namespace MonkeyGame
{
    

    public partial class Beach : Form
    {
        public static readonly int WIDTH = 1536;        
        public static readonly int HEIGHT = 1024;

        
        private List<player> group;
        private List<Palm_Tree> tree;

        BufferedGraphicsContext currentContext;
        BufferedGraphics beach;
   

        public Beach(List<player> group, List<Palm_Tree> tree)
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            
            beach = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.group = group;
            this.tree = tree;
            this.KeyPreview = true; // Ensures the form captures key events before child controls
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
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

            Image beachImg = Properties.Resources.playa;

            beach.Graphics.DrawImage(beachImg, 0, 0, WIDTH, HEIGHT);

            // draw Trees
            foreach (Palm_Tree palm_tree in tree)
            {
                palm_tree.Render(beach);
            }
            
            // draw Monkeys
            foreach (player monkey in group)
            {
                monkey.Render(beach);
            }
            beach.Render();
        }

        // Calcul du nouvel �tat apr�s que 'interval' millisecondes se sont �coul�es
        private void Update(int interval)
        {
            foreach (player drone in group)
            {
                drone.Update(interval);
            }
        }

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}