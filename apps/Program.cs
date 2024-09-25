using SimpleMiniMarketSystem.apps.config;

namespace SimpleMiniMarketSystem.apps
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new login());

        }
    }
}