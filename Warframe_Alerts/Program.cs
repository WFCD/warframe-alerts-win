using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Window());
        }
    }
}
