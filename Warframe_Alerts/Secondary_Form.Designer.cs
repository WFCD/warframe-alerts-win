using System.ComponentModel;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    partial class SecondaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondaryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxMod = new System.Windows.Forms.CheckBox();
            this.checkBoxBlueprint = new System.Windows.Forms.CheckBox();
            this.checkBoxResource = new System.Windows.Forms.CheckBox();
            this.checkBoxCredit = new System.Windows.Forms.CheckBox();
            this.checkBoxDetection = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Update Interval (In Minutes)";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(13, 174);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(532, 20);
            this.textBoxInterval.TabIndex = 1;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(470, 200);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 2;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(389, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // checkBoxMod
            // 
            this.checkBoxMod.AutoSize = true;
            this.checkBoxMod.Location = new System.Drawing.Point(12, 12);
            this.checkBoxMod.Name = "checkBoxMod";
            this.checkBoxMod.Size = new System.Drawing.Size(106, 17);
            this.checkBoxMod.TabIndex = 5;
            this.checkBoxMod.Text = "Show Mod Alerts";
            this.checkBoxMod.UseVisualStyleBackColor = true;
            this.checkBoxMod.CheckedChanged += new System.EventHandler(this.CheckBoxMod_Changed);
            // 
            // checkBoxBlueprint
            // 
            this.checkBoxBlueprint.AutoSize = true;
            this.checkBoxBlueprint.Location = new System.Drawing.Point(12, 36);
            this.checkBoxBlueprint.Name = "checkBoxBlueprint";
            this.checkBoxBlueprint.Size = new System.Drawing.Size(126, 17);
            this.checkBoxBlueprint.TabIndex = 6;
            this.checkBoxBlueprint.Text = "Show Blueprint Alerts";
            this.checkBoxBlueprint.UseVisualStyleBackColor = true;
            this.checkBoxBlueprint.CheckedChanged += new System.EventHandler(this.CheckBoxBlueprint_Changed);
            // 
            // checkBoxResource
            // 
            this.checkBoxResource.AutoSize = true;
            this.checkBoxResource.Location = new System.Drawing.Point(12, 60);
            this.checkBoxResource.Name = "checkBoxResource";
            this.checkBoxResource.Size = new System.Drawing.Size(136, 17);
            this.checkBoxResource.TabIndex = 7;
            this.checkBoxResource.Text = "Show Resources Alerts";
            this.checkBoxResource.UseVisualStyleBackColor = true;
            this.checkBoxResource.CheckedChanged += new System.EventHandler(this.CheckBoxResource_Changed);
            // 
            // checkBoxCredit
            // 
            this.checkBoxCredit.AutoSize = true;
            this.checkBoxCredit.Location = new System.Drawing.Point(12, 84);
            this.checkBoxCredit.Name = "checkBoxCredit";
            this.checkBoxCredit.Size = new System.Drawing.Size(117, 17);
            this.checkBoxCredit.TabIndex = 8;
            this.checkBoxCredit.Text = "Show Credits Alerts";
            this.checkBoxCredit.UseVisualStyleBackColor = true;
            this.checkBoxCredit.CheckedChanged += new System.EventHandler(this.CheckBoxCredit_Changed);
            // 
            // checkBoxDetection
            // 
            this.checkBoxDetection.AutoSize = true;
            this.checkBoxDetection.Location = new System.Drawing.Point(12, 107);
            this.checkBoxDetection.Name = "checkBoxDetection";
            this.checkBoxDetection.Size = new System.Drawing.Size(239, 17);
            this.checkBoxDetection.TabIndex = 9;
            this.checkBoxDetection.Text = "Pause notifications while Warframe is running";
            this.checkBoxDetection.UseVisualStyleBackColor = true;
            this.checkBoxDetection.CheckedChanged += new System.EventHandler(this.CheckBoxDetection_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Note: Rivens, Catalysts, Reactors and Nitain are considered high priority alerts " +
    "and thus are never filtered";
            // 
            // SecondaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(557, 232);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxDetection);
            this.Controls.Add(this.checkBoxCredit);
            this.Controls.Add(this.checkBoxResource);
            this.Controls.Add(this.checkBoxBlueprint);
            this.Controls.Add(this.checkBoxMod);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SecondaryForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxInterval;
        private Button buttonSet;
        private Button buttonCancel;
        private CheckBox checkBoxMod;
        private CheckBox checkBoxBlueprint;
        private CheckBox checkBoxResource;
        private CheckBox checkBoxCredit;
        private CheckBox checkBoxDetection;
        private Label label2;
    }
}