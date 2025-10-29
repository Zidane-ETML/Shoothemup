using MonkeyGame.Model;

namespace MonkeyGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création de la flotte de drones
            List<player> group= new List<player>();
            List<Palm_Tree> tree= new List<Palm_Tree>();
            group.Add(new player(Beach.WIDTH / 2, Beach.HEIGHT / 2, 50, 50));
            int space = 100;
            tree.Add(new Palm_Tree(100, GlobalHelpers.alea.Next(0, 2)));
            for (int i = 0; i < 4; i++)
            {
                space = space + GlobalHelpers.alea.Next(120 , 300);
                tree.Add(new Palm_Tree(100 + space, GlobalHelpers.alea.Next(0, 2)));
            }
            

            // Démarrage
            Application.Run(new Beach(group, tree));
        }
    }
}