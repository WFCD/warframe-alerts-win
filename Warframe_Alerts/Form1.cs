using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace Warframe_Alerts
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class MainWindow : MaterialForm
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

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            //skinManager.FORM_PADDING = 0;
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1020, 530);
            MinimumSize = new Size(1020, 530);
            skinManager.ColorScheme = new ColorScheme(Primary.Teal800, Primary.Teal900, Primary.Teal500, Accent.Teal200, TextShade.WHITE);

            Apply_Settings();

            Action update = WF_Update;
            update.BeginInvoke(ar => update.EndInvoke(ar), null);

            _updateTimer.Interval = _uInterval;
            _updateTimer.Tick += Update_Click;
            _updateTimer.Start();
        }

        public sealed override Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        public sealed override Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
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
                        new XElement("UpdateTimer", _uInterval.ToString()),
                        new XElement("GameDetection", "1")

                    )
                );

                newDoc.Save("Config.xml");
                return;
            }

            var doc = XDocument.Load("Config.xml");

            if (doc.Element("body").Element("LoadMinimized").Value == "1")
            {
                _startMinimized = true;
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                //MBtnStartM.Text = @"Disable Start Minimized";
                CBStartM.Checked = true;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }

            if (doc.Element("body").Element("Log").Value == "1")
            {
                _enableLog = true;
                //MBtnLog.Text = @"Disable Log";
                CBLog.Checked = true;
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

            if (doc.Element("body").Element("GameDetection").Value == "0")
            {
                GameDetection = false;
            }

            var uInt = doc.Element("body").Element("UpdateTimer").Value;
            _uInterval = Convert.ToInt32(uInt);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Action update = WF_Update;
            update.BeginInvoke(ar => update.EndInvoke(ar), null);
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

            doc.Element("body").Element("GameDetection").Value = GameDetection ? "1" : "0";

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

            Invoke(new Action(() =>
            {
                AlertData.Items.Clear();
                InvasionData.Items.Clear();
                _idList.Clear();
            }));

            //AlertData.Items.Clear();
            //InvasionData.Items.Clear();
            //_idList.Clear();   

            for (var i = 0; i < alerts.Count; i++)
            {
                var eTime = Convert.ToDateTime(alerts[i].Expiry_Date);

                var title = alerts[i].Title;
                var titleSp = title.Split('-');

                title = titleSp[0];

                for (var j = 1; j < titleSp.Length - 1; j++)
                {
                    title = title + "-" + titleSp[j];
                }

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
                string[] row = {description, title, faction, aLeft};
                var listViewItem = new ListViewItem(row);
                //AlertData.Items.Add(listViewItem);
                Invoke(new Action(() => AlertData.Items.Add(listViewItem)));
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
                string[] row = {title, "Invasion", time};
                var listViewItem = new ListViewItem(row);
                //InvasionData.Items.Add(listViewItem);
                Invoke(new Action(() => InvasionData.Items.Add(listViewItem)));
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
                string[] row = {title, "Outbreak", oTime};
                var listViewItem = new ListViewItem(row);
                //InvasionData.Items.Add(listViewItem);
                Invoke(new Action(() => InvasionData.Items.Add(listViewItem)));
            }

            //AlertData.Scrollable = AlertData.Items.Count != 3;
            //InvasionData.Scrollable = InvasionData.Items.Count != 3;

            Invoke(new Action(() =>
            {
                AlertData.Scrollable = AlertData.Items.Count != 3;
                InvasionData.Scrollable = InvasionData.Items.Count != 3;
                InvasionData.Columns[0].Width = InvasionData.Items.Count > 3 ? 627 : 644;
                AlertData.Columns[3].Width = AlertData.Items.Count > 3 ? 235 : 252;
            }));

            //InvasionData.Columns[0].Width = InvasionData.Items.Count > 3 ? 627 : 644;
            //AlertData.Columns[3].Width = AlertData.Items.Count > 3 ? 235 : 252;
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
                if (_enableLog) Log_Alert(a[i].ID, a[i].Title);

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
                if (_enableLog) Log_Invasion(I[i].ID, I[i].Title);

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
                if (_enableLog) Log_Invasion(o[i].ID, o[i].Title);

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
            Opacity = 0;
            Notify_Icon.BalloonTipText = @"Warframe_Alerts is running in background";
            Notify_Icon.BalloonTipTitle = @"Update";
            if (_startMinimized) return;
            Notify_Icon.ShowBalloonTip(2000);
        }

        private void Notification_Icon_Double_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            _phaseShift = true;
            ShowInTaskbar = true;
            Opacity = 100;
            Show();
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            BringToFront();
            _phaseShift = false;
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
            get => _uInterval;
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

        public bool GameDetection { get; set; } = true;

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void CBLog_CheckedChanged(object sender, EventArgs e)
        {
            if (CBLog.Checked)
            {
                _enableLog = true;
                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("Log").Value = "1";
                doc.Save("Config.xml");
            }
            else
            {
                _enableLog = false;
                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("Log").Value = "0";
                doc.Save("Config.xml");
            }
        }

        private void CBStartM_CheckedChanged(object sender, EventArgs e)
        {
            if (CBStartM.Checked)
            {
                _startMinimized = true;
                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("LoadMinimized").Value = "1";
                doc.Save("Config.xml");
            }
            else
            {
                _startMinimized = false;
                var doc = XDocument.Load("Config.xml");
                doc.Element("body").Element("LoadMinimized").Value = "0";
                doc.Save("Config.xml");
            }
        }
    }
}
