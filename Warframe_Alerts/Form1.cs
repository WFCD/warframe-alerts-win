using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Warframe_Alerts
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class MainWindow : Form
    {
        private readonly List<string> _idList = new List<string>();

        private int _uInterval = 1 * 60 * 1000;
        private bool _startMinimized;
        private bool _enableLog;

        private readonly Timer _updateTimer = new Timer();
        private bool _phaseShift;

        public MainWindow()
        {
            InitializeComponent();
            Apply_Settings();
            WF_Update();

            _updateTimer.Interval = _uInterval;
            _updateTimer.Tick += Update_Click;
            _updateTimer.Start();
        }

        public void Apply_Settings()
        {
            if (!File.Exists("Config.xml"))
            {
                var newDoc = new XDocument(
                    new XElement("body",

                        new XElement("LoadMinimized", "0"),
                        new XElement("Resources", "1"),
                        new XElement("Mods", "1"),
                        new XElement("Credits", "1"),
                        new XElement("Blueprints", "1"),
                        new XElement("Log", "0"),
                        new XElement("UpdateTimer", _uInterval.ToString())

                    )
                );

                newDoc.Save("Config.xml");
                return;
            }

            var doc = XDocument.Load("Config.xml");

            if (doc.Element("body").Element("LoadMinimized").Value == "1")
            {
                _startMinimized = true;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                buttonSM.Text = @"Disable Start Minimized";
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }

            if (doc.Element("body").Element("Log").Value == "1")
            {
                _enableLog = true;
                BtnLog.Text = @"Disable Log";
            }

            if (doc.Element("body").Element("Resources").Value == "0")
            {
                ResourceFilter = false;
            }

            if (doc.Element("body").Element("Blueprints").Value == "0")
            {
                BlueprintFilter = false;
            }

            if (doc.Element("body").Element("Mods").Value == "0")
            {
                ModFilter = false;
            }

            if (doc.Element("body").Element("Credits").Value == "0")
            {
                CreditFilter = false;
            }

            var uInt = doc.Element("body").Element("UpdateTimer").Value;

            _uInterval = Convert.ToInt32(uInt);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            WF_Update();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            var sf = new SecondaryForm(this,ResourceFilter,ModFilter,CreditFilter,BlueprintFilter);
            sf.ShowDialog();
        }

        public void Update_Settings_XML()
        {
            var doc = XDocument.Load("Config.xml");
            
            doc.Element("body").Element("Resources").Value = ResourceFilter ? "1" : "0";

            doc.Element("body").Element("Credits").Value = CreditFilter ? "1" : "0";

            doc.Element("body").Element("Mods").Value = ModFilter ? "1" : "0";

            doc.Element("body").Element("Blueprints").Value = BlueprintFilter ? "1" : "0";

            doc.Element("body").Element("UpdateTimer").Value = _uInterval.ToString();

            doc.Save("Config.xml");
        }

        public void WF_Update()
        {
            var wf = new WarframeHandler();

            var alerts = new List<Alert>();
            var invasions = new List<Invasion>();
            var outbreaks = new List<Outbreak>();

            var status = "";
            var response = wf.GetXml(ref status);

            if (status != "OK")
            {
                var message = "Network not responding" + '\n';
                message = message + response;

                Notify_Icon.BalloonTipText = message;
                Notify_Icon.BalloonTipTitle = @"Update Failed";
                Notify_Icon.ShowBalloonTip(2000);
                return;
            }

            wf.GetObjects(response, ref alerts, ref invasions, ref outbreaks);

            Notify_Alerts_And_Invasions(ref alerts, ref invasions, ref outbreaks);

            AlertData.Rows.Clear();
            InvasionData.Rows.Clear();
            _idList.Clear();

            for (var i = 0; i < alerts.Count; i++)
            {
                var eTime = Convert.ToDateTime(alerts[i].Expiry_Date);

                var title = alerts[i].Title;
                var description = alerts[i].Description;
                var faction = alerts[i].Faction;
                var aId = alerts[i].ID;

                if (!Filter_Alerts(title)) continue;
                var aSpan = eTime.Subtract(DateTime.Now);
                var aLeft = "";

                if (aSpan.Days != 0)
                {
                    aLeft = aLeft + aSpan.Days + " Days ";
                }

                if (aSpan.Hours != 0)
                {
                    aLeft = aLeft + aSpan.Hours + " Hours ";
                }

                if (aSpan.Minutes != 0)
                {
                    aLeft = aLeft + aSpan.Minutes + " Minutes ";
                }

                aLeft = aLeft + aSpan.Seconds + " Seconds Left";

                _idList.Add(aId);
                AlertData.Rows.Add(description, title, faction, aLeft);
            }

            for (var i = 0; i < invasions.Count; i++)
            {
                var title = invasions[i].Title;
                var invId = invasions[i].ID;

                var sTime = Convert.ToDateTime(invasions[i].Start_Date);
                var now = DateTime.Now;
                var span = now.Subtract(sTime);

                var time = "";

                if (span.Hours != 0)
                {
                    time = time + span.Hours + " Hours ";
                }

                time = time + span.Minutes + " Minutes Ago";

                _idList.Add(invId);
                InvasionData.Rows.Add(title, "Invasion", time);
            }

            for (var i = 0; i < outbreaks.Count; i++)
            {
                var title = outbreaks[i].Title;
                var oId = outbreaks[i].ID;

                var sTime = Convert.ToDateTime(outbreaks[i].Start_Date);
                var now = DateTime.Now;
                var oSpan = now.Subtract(sTime);

                var oTime = "";

                if (oSpan.Hours != 0)
                {
                    oTime = oTime + oSpan.Hours + " Hours ";
                }

                oTime = oTime + oSpan.Minutes + " Minutes Ago";

                _idList.Add(oId);
                InvasionData.Rows.Add(title, "Outbreak", oTime);
            }
        }

        public void Log_Alert(string id, string disc)
        {
            var flag = true;

            if (File.Exists("AlertLog.txt"))
            {
                var text = File.ReadAllText("AlertLog.txt");

                if (text.Contains(id))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                File.AppendAllText("AlertLog.txt", id + '\t' + disc + Environment.NewLine);
            }
        }

        public void Log_Invasion(string id, string disc)
        {
            var flag = true;

            if (File.Exists("InvasionLog.txt"))
            {
                var text = File.ReadAllText("InvasionLog.txt");

                if (text.Contains(id))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                File.AppendAllText("InvasionLog.txt", id + '\t' + disc + Environment.NewLine);
            }
        }

        public void Notify_Alerts_And_Invasions(ref List<Alert> a, ref List<Invasion> I, ref List<Outbreak> o)
        {
            var notificationMessage = "";

            for (var i = 0; i < a.Count; i++)
            {
                var found = false;

                for (var j = 0; j < _idList.Count && !found; j++)
                {
                    if (a[i].ID == _idList[j])
                    {
                        found = true;
                    }
                }

                if (found) continue;
                Log_Alert(a[i].ID, a[i].Title);

                if (Filter_Alerts(a[i].Title))
                {
                    notificationMessage = notificationMessage + a[i].Title + '\n';
                }
            }

            for (var i = 0; i < I.Count; i++)
            {
                var found = false;

                for (var j = 0; j < _idList.Count && !found; j++)
                {
                    if (I[i].ID == _idList[j])
                    {
                        found = true;
                    }
                }

                if (found) continue;
                Log_Invasion(I[i].ID, I[i].Title);

                if (Filter_Alerts(I[i].Title))
                {
                    notificationMessage = notificationMessage + I[i].Title + '\n';
                }
            }

            for (var i = 0; i < o.Count; i++)
            {
                var found = false;

                for (var j = 0; j < _idList.Count && !found; j++)
                {
                    if (o[i].ID == _idList[j])
                    {
                        found = true;
                    }
                }

                if (found) continue;
                Log_Invasion(o[i].ID, o[i].Title);

                if (Filter_Alerts(o[i].Title))
                {
                    notificationMessage = notificationMessage + o[i].Title + '\n';
                }
            }

            if (notificationMessage == "") return;
            Notify_Icon.BalloonTipText = notificationMessage;
            Notify_Icon.BalloonTipTitle = @"Update";
            Notify_Icon.ShowBalloonTip(2000);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Resize_Action(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized || _phaseShift) return;
            Hide();
            Notify_Icon.BalloonTipText = @"Warframe_Alerts is running in background";
            Notify_Icon.BalloonTipTitle = @"Update";
            if (_startMinimized) return;
            Notify_Icon.ShowBalloonTip(2000);
        }

        private void Notification_Icon_Double_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _phaseShift = true;
            ShowInTaskbar = true;
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            _phaseShift = false;
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            var message = "Logging has been disabled";
            var caption = "Success";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;

            if (_enableLog)
            {
                MessageBox.Show(message, caption, buttons);

                _enableLog = false;

                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("Log").Value = "0";
                doc.Save("Config.xml");
            }
            else
            {
                message = "Logging has been enabled";
                MessageBox.Show(message, caption, buttons);

                _enableLog = true;

                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("Log").Value = "1";
                doc.Save("Config.xml");
            }
        }

        private void buttonSM_Click(object sender, EventArgs e)
        {
            var message = "Start minimized has been disabled";
            const string caption = "Success";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;

            var doc = XDocument.Load("Config.xml");

            if (_startMinimized)
            {
                MessageBox.Show(message, caption, buttons);
                _startMinimized = false;
                
                doc.Element("body").Element("LoadMinimized").Value = "0";
                doc.Save("Config.xml");
            }
            else
            {
                message = "Start minimized has been enabled";
                MessageBox.Show(message, caption, buttons);
                _startMinimized = true;

                doc.Element("body").Element("LoadMinimized").Value = "1";
                doc.Save("Config.xml");
            }
        }

        private bool Filter_Alerts(string title)
        {
            var flag = true;

            if (!BlueprintFilter)
            {
                if (title.IndexOf("(Blueprint)", StringComparison.Ordinal) != -1)
                {
                    flag = false;
                }
            }

            var dashCount = 0;

            if (!CreditFilter)
            {
                foreach (var t in title)
                {
                    if (t == '-')
                    {
                        dashCount++;
                    }
                }

                if (dashCount == 2)
                {
                    var arr = title.Split('-');

                    if (arr[0].IndexOf("cr", StringComparison.Ordinal) != -1)
                    {
                        flag = false;
                    }
                }
            }

            if (!ModFilter)
            {
                if (title.IndexOf("(Mod)", StringComparison.Ordinal) != -1)
                {
                    flag = false;
                }
            }

            if (ResourceFilter) return flag;
            if (title.IndexOf("Resource", StringComparison.Ordinal) == -1 &&
                title.IndexOf("ENDO", StringComparison.Ordinal) == -1) return flag;
            if (title.IndexOf("Nitain", StringComparison.Ordinal) == -1)
            {
                flag = false;
            }

            return flag;
        }

        public int UpdateInterval
        {
            get
            {
                return _uInterval;
            }
            set
            {
                _uInterval = value;
                _updateTimer.Interval = _uInterval;
            }
        }

        public bool ResourceFilter { get; set; } = true;

        public bool CreditFilter { get; set; } = true;

        public bool ModFilter { get; set; } = true;

        public bool BlueprintFilter { get; set; } = true;
    }
}
