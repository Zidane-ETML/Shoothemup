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

            // Cr�ation de la flotte de drones
            List<player> fleet= new List<player>();
            fleet.Add(new player(Beach.WIDTH / 2, Beach.HEIGHT / 2, "Joe"));

            // D�marrage
            Application.Run(new Beach(fleet));
        }
    }
}