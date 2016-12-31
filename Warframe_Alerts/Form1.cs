using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    public partial class Main_Window : Form
    {
        List<string> ID_List = new List<string>();

        public int Update_Interval
        {
            get {
                return U_Interval;
            }
            set {
                U_Interval = value;
                Update_Timer.Interval = U_Interval;
            }
        }

        public int U_Interval = 1 * 60 * 1000;
        System.Windows.Forms.Timer Update_Timer = new System.Windows.Forms.Timer();
        bool Start_Minimized = false;
        bool Phase_Shift = false;

        public Main_Window()
        {
            InitializeComponent();
            Apply_Settings();
            WF_Update();

            Update_Timer.Interval = U_Interval;
            Update_Timer.Tick += new EventHandler(Update_Click);
            Update_Timer.Start();
        }

        public void Apply_Settings()
        {
            string Value = "";

            try
            {
                Value = File.ReadAllText("App.cfg");
            }
            catch (System.Exception ex)
            {
                Value = ex.ToString();
                string message = "Creating new config file";
                string caption = "Warframe Alerts";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                File.WriteAllText("App.cfg", "<SM> 0 </SM>");
                return;
            }

            if (Value.IndexOf('1') != -1)
            {
                Start_Minimized = true;
            }

            if (Start_Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                buttonSM.Text = "Disable Start Minimized";
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //Notify_Icon.BalloonTipText = "TEST MESSAGE";
            //Notify_Icon.BalloonTipTitle = "TEST TITLE";
            //Notify_Icon.ShowBalloonTip(1000);
            WF_Update();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            Secondary_Form SF = new Secondary_Form(this);
            SF.ShowDialog();
        }

        public void WF_Update()
        {
            Warframe_Handler WF = new Warframe_Handler();

            List<Alert> Alerts = new List<Alert>();
            List<Invasion> Invasions = new List<Invasion>();
            List<Outbreak> Outbreaks = new List<Outbreak>();

            string Status = "";
            string Response = WF.GetXML(ref Status);

            if (Status != "OK")
            {
                string message = "Network not responding" + '\n';
                message = message + Response;
                string caption = "Update Failed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            WF.GetObjects(Response, ref Alerts, ref Invasions, ref Outbreaks);

            Notify_Alerts_And_Invasions(ref Alerts, ref Invasions, ref Outbreaks);

            AlertData.Rows.Clear();
            InvasionData.Rows.Clear();
            ID_List.Clear();

            for (int i = 0; i < Alerts.Count; i++)
            {
                DateTime S_Time = Convert.ToDateTime(Alerts[i].Start_Date);
                DateTime E_Time = Convert.ToDateTime(Alerts[i].Expiry_Date);

                string Title = Alerts[i].Title;
                string Description = Alerts[i].Description;
                string Faction = Alerts[i].Faction;
                string A_ID = Alerts[i].ID;

                TimeSpan A_Span = E_Time.Subtract(DateTime.Now);
                string A_Left = "";
                
                if (A_Span.Days != 0)
                {
                    A_Left = A_Left + A_Span.Days.ToString() + " Days ";
                }

                if (A_Span.Hours != 0)
                {
                    A_Left = A_Left + A_Span.Hours.ToString() + " Hours ";
                }

                if (A_Span.Minutes != 0)
                {
                    A_Left = A_Left + A_Span.Minutes.ToString() + " Minutes ";
                }

                A_Left = A_Left + A_Span.Seconds.ToString() + " Seconds Left";

                ID_List.Add(A_ID);
                AlertData.Rows.Add(Description, Title, Faction, A_Left);
                //AlertData.Rows.Add(Description, Title, Faction, Time_Left + " min left");
            }

            for (int i = 0; i < Invasions.Count; i++)
            {
                string Title = Invasions[i].Title;
                string I_ID = Invasions[i].ID;

                DateTime S_Time = Convert.ToDateTime(Invasions[i].Start_Date);
                DateTime T_Now = DateTime.Now;
                TimeSpan I_Span = T_Now.Subtract(S_Time);

                ID_List.Add(I_ID);
                InvasionData.Rows.Add(Title, "Invasion", I_Span.Hours.ToString() + " Hours " + I_Span.Minutes.ToString() + " Minutes Ago");
                //InvasionData.Rows.Add(Title, "Invasion", S_Time.ToString());
            }

            for (int i = 0; i < Outbreaks.Count; i++)
            {
                string Title = Outbreaks[i].Title;
                string O_ID = Outbreaks[i].ID;

                DateTime S_Time = Convert.ToDateTime(Outbreaks[i].Start_Date);
                DateTime T_Now = DateTime.Now;
                TimeSpan O_Span = T_Now.Subtract(S_Time);

                ID_List.Add(O_ID);
                InvasionData.Rows.Add(Title, "Outbreak", O_Span.Hours.ToString() + " Hours " + O_Span.Minutes.ToString() + " Minutes Ago");
            }
        }

        public void Notify_Alerts_And_Invasions(ref List<Alert> A, ref List<Invasion> I, ref List<Outbreak> O)
        {
            string Notification_Message = "";

            for (int i = 0; i < A.Count; i++)
            {
                bool Found = false;

                for (int j = 0; j < ID_List.Count && !Found; j++)
                {
                    if (A[i].ID == ID_List[j])
                    {
                        Found = true;
                    }
                }

                if (!Found)
                {
                    Notification_Message = Notification_Message + A[i].Title + '\n';
                }
            }

            for (int i = 0; i < I.Count; i++)
            {
                bool Found = false;

                for (int j = 0; j < ID_List.Count && !Found; j++)
                {
                    if (I[i].ID == ID_List[j])
                    {
                        Found = true;
                    }
                }

                if (!Found)
                {
                    Notification_Message = Notification_Message + I[i].Title + '\n';
                }
            }

            for (int i = 0; i < O.Count; i++)
            {
                bool Found = false;

                for (int j = 0; j < ID_List.Count && !Found; j++)
                {
                    if (O[i].ID == ID_List[j])
                    {
                        Found = true;
                    }
                }

                if (!Found)
                {
                    Notification_Message = Notification_Message + O[i].Title + '\n';
                }
            }

            if (Notification_Message != "")
            {
                Notify_Icon.BalloonTipText = Notification_Message;
                Notify_Icon.BalloonTipTitle = "Update";
                Notify_Icon.ShowBalloonTip(2000);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Resize_Action(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && !Phase_Shift)
            {
                this.Hide();
                Notify_Icon.BalloonTipText = "Warframe_Alerts is running in background";
                Notify_Icon.BalloonTipTitle = "Update";
                Notify_Icon.ShowBalloonTip(2000);
            }
        }

        private void Notification_Icon_Double_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Phase_Shift = true;
                this.ShowInTaskbar = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                Phase_Shift = false;
            }
        }

        private void buttonSM_Click(object sender, EventArgs e)
        {
            if (Start_Minimized)
            {
                string message = "Start minimized has been disabled";
                string caption = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);

                Start_Minimized = false;
                File.WriteAllText("App.cfg", "<SM> 0 </SM>");
            }
            else
            {
                string message = "Start minimized has been enabled";
                string caption = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);

                Start_Minimized = true;
                File.WriteAllText("App.cfg", "<SM> 1 </SM>");
            }
        }
    }
}
