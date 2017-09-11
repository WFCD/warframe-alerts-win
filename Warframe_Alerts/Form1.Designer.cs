using System.ComponentModel;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Notify_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu_Strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.InvasionData = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MBtnSettings = new MaterialSkin.Controls.MaterialFlatButton();
            this.MBtnStartM = new MaterialSkin.Controls.MaterialFlatButton();
            this.MBtnLog = new MaterialSkin.Controls.MaterialFlatButton();
            this.MBtnUpdate = new MaterialSkin.Controls.MaterialFlatButton();
            this.MBtnExit = new MaterialSkin.Controls.MaterialFlatButton();
            this.AlertData = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.Menu_Strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Notify_Icon
            // 
            this.Notify_Icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Notify_Icon.ContextMenuStrip = this.Menu_Strip;
            this.Notify_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Notify_Icon.Icon")));
            this.Notify_Icon.Text = "Warframe Alerts";
            this.Notify_Icon.Visible = true;
            this.Notify_Icon.DoubleClick += new System.EventHandler(this.Notification_Icon_Double_Click);
            // 
            // Menu_Strip
            // 
            this.Menu_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Exit});
            this.Menu_Strip.Name = "Menu_Strip";
            this.Menu_Strip.Size = new System.Drawing.Size(93, 26);
            // 
            // Menu_Exit
            // 
            this.Menu_Exit.Name = "Menu_Exit";
            this.Menu_Exit.Size = new System.Drawing.Size(92, 22);
            this.Menu_Exit.Text = "Exit";
            this.Menu_Exit.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // InvasionData
            // 
            this.InvasionData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InvasionData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.InvasionData.Depth = 0;
            this.InvasionData.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.InvasionData.FullRowSelect = true;
            this.InvasionData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.InvasionData.Location = new System.Drawing.Point(12, 299);
            this.InvasionData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.InvasionData.MouseState = MaterialSkin.MouseState.OUT;
            this.InvasionData.Name = "InvasionData";
            this.InvasionData.OwnerDraw = true;
            this.InvasionData.Size = new System.Drawing.Size(962, 170);
            this.InvasionData.TabIndex = 10;
            this.InvasionData.UseCompatibleStateImageBehavior = false;
            this.InvasionData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Title";
            this.columnHeader5.Width = 610;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Start Time";
            this.columnHeader7.Width = 252;
            // 
            // MBtnSettings
            // 
            this.MBtnSettings.AutoSize = true;
            this.MBtnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MBtnSettings.Depth = 0;
            this.MBtnSettings.Icon = null;
            this.MBtnSettings.Location = new System.Drawing.Point(12, 478);
            this.MBtnSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MBtnSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.MBtnSettings.Name = "MBtnSettings";
            this.MBtnSettings.Primary = false;
            this.MBtnSettings.Size = new System.Drawing.Size(85, 36);
            this.MBtnSettings.TabIndex = 11;
            this.MBtnSettings.Text = "Settings";
            this.MBtnSettings.UseVisualStyleBackColor = true;
            this.MBtnSettings.Click += new System.EventHandler(this.Setting_Click);
            // 
            // MBtnStartM
            // 
            this.MBtnStartM.AutoSize = true;
            this.MBtnStartM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MBtnStartM.Depth = 0;
            this.MBtnStartM.Icon = null;
            this.MBtnStartM.Location = new System.Drawing.Point(105, 478);
            this.MBtnStartM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MBtnStartM.MouseState = MaterialSkin.MouseState.HOVER;
            this.MBtnStartM.Name = "MBtnStartM";
            this.MBtnStartM.Primary = false;
            this.MBtnStartM.Size = new System.Drawing.Size(193, 36);
            this.MBtnStartM.TabIndex = 12;
            this.MBtnStartM.Text = "Toggle Start Minimized";
            this.MBtnStartM.UseVisualStyleBackColor = true;
            this.MBtnStartM.Click += new System.EventHandler(this.buttonSM_Click);
            // 
            // MBtnLog
            // 
            this.MBtnLog.AutoSize = true;
            this.MBtnLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MBtnLog.Depth = 0;
            this.MBtnLog.Icon = null;
            this.MBtnLog.Location = new System.Drawing.Point(306, 478);
            this.MBtnLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MBtnLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.MBtnLog.Name = "MBtnLog";
            this.MBtnLog.Primary = false;
            this.MBtnLog.Size = new System.Drawing.Size(102, 36);
            this.MBtnLog.TabIndex = 13;
            this.MBtnLog.Text = "Toggle Log";
            this.MBtnLog.UseVisualStyleBackColor = true;
            this.MBtnLog.Click += new System.EventHandler(this.BtnLog_Click);
            // 
            // MBtnUpdate
            // 
            this.MBtnUpdate.AutoSize = true;
            this.MBtnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MBtnUpdate.Depth = 0;
            this.MBtnUpdate.Icon = null;
            this.MBtnUpdate.Location = new System.Drawing.Point(842, 478);
            this.MBtnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MBtnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.MBtnUpdate.Name = "MBtnUpdate";
            this.MBtnUpdate.Primary = false;
            this.MBtnUpdate.Size = new System.Drawing.Size(73, 36);
            this.MBtnUpdate.TabIndex = 14;
            this.MBtnUpdate.Text = "Update";
            this.MBtnUpdate.UseVisualStyleBackColor = true;
            this.MBtnUpdate.Click += new System.EventHandler(this.Update_Click);
            // 
            // MBtnExit
            // 
            this.MBtnExit.AutoSize = true;
            this.MBtnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MBtnExit.Depth = 0;
            this.MBtnExit.Icon = null;
            this.MBtnExit.Location = new System.Drawing.Point(923, 478);
            this.MBtnExit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MBtnExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.MBtnExit.Name = "MBtnExit";
            this.MBtnExit.Primary = false;
            this.MBtnExit.Size = new System.Drawing.Size(50, 36);
            this.MBtnExit.TabIndex = 15;
            this.MBtnExit.Text = "Exit";
            this.MBtnExit.UseVisualStyleBackColor = true;
            this.MBtnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AlertData
            // 
            this.AlertData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.AlertData.Depth = 0;
            this.AlertData.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.AlertData.FullRowSelect = true;
            this.AlertData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AlertData.Location = new System.Drawing.Point(12, 96);
            this.AlertData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AlertData.MouseState = MaterialSkin.MouseState.OUT;
            this.AlertData.Name = "AlertData";
            this.AlertData.OwnerDraw = true;
            this.AlertData.Size = new System.Drawing.Size(962, 170);
            this.AlertData.TabIndex = 16;
            this.AlertData.UseCompatibleStateImageBehavior = false;
            this.AlertData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 410;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Faction";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time Left";
            this.columnHeader4.Width = 252;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(13, 77);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 17;
            this.materialLabel1.Text = "Alerts";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(8, 277);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(73, 19);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Invasions";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(986, 529);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.AlertData);
            this.Controls.Add(this.MBtnExit);
            this.Controls.Add(this.MBtnUpdate);
            this.Controls.Add(this.MBtnLog);
            this.Controls.Add(this.MBtnStartM);
            this.Controls.Add(this.MBtnSettings);
            this.Controls.Add(this.InvasionData);
            this.Font = new System.Drawing.Font("Roboto Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Warframe Alerts";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.Resize_Action);
            this.Menu_Strip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NotifyIcon Notify_Icon;
        private ContextMenuStrip Menu_Strip;
        private ToolStripMenuItem Menu_Exit;
        private MaterialSkin.Controls.MaterialListView InvasionData;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private MaterialSkin.Controls.MaterialFlatButton MBtnSettings;
        private MaterialSkin.Controls.MaterialFlatButton MBtnStartM;
        private MaterialSkin.Controls.MaterialFlatButton MBtnLog;
        private MaterialSkin.Controls.MaterialFlatButton MBtnUpdate;
        private MaterialSkin.Controls.MaterialFlatButton MBtnExit;
        private MaterialSkin.Controls.MaterialListView AlertData;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}

