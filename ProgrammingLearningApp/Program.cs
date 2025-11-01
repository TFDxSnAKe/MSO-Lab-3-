using System.Numerics;

namespace ProgrammingLearningApp
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
            var player = new MSO_LAB_3.Player(new Vector2(0, 0));
            Application.Run(new Form1(player));
        }
    }
}