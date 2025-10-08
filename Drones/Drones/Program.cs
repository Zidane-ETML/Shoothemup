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
            group.Add(new player(Beach.WIDTH / 2, Beach.HEIGHT / 2, 500, 499));
            tree.Add(new Palm_Tree());

            // Démarrage
            Application.Run(new Beach(group));
        }
    }
}