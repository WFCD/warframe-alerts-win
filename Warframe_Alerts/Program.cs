using System;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    public struct Alert
    {
        public string ID;
        public string Title;
        public string Description;
        public string Start_Date;
        public string Faction;
        public string Expiry_Date;
    }

    public struct Invasion
    {
        public string ID;
        public string Title;
        public string Start_Date;
    }

    public struct Outbreak
    {
        public string ID;
        public string Title;
        public string Start_Date;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainWindow());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}