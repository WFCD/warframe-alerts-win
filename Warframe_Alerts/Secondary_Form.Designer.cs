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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondaryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.checkBoxMod = new System.Windows.Forms.CheckBox();
            this.checkBoxBlueprint = new System.Windows.Forms.CheckBox();
            this.checkBoxResource = new System.Windows.Forms.CheckBox();
            this.checkBoxCredit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Update Interval (In Minutes)";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(12, 166);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(315, 20);
            this.textBoxInterval.TabIndex = 1;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(251, 193);
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
            this.buttonCancel.Location = new System.Drawing.Point(170, 193);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(13, 13);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(34, 13);
            this.FilterLabel.TabIndex = 4;
            this.FilterLabel.Text = "Filters";
            // 
            // checkBoxMod
            // 
            this.checkBoxMod.AutoSize = true;
            this.checkBoxMod.Location = new System.Drawing.Point(16, 39);
            this.checkBoxMod.Name = "checkBoxMod";
            this.checkBoxMod.Size = new System.Drawing.Size(52, 17);
            this.checkBoxMod.TabIndex = 5;
            this.checkBoxMod.Text = "Mods";
            this.checkBoxMod.UseVisualStyleBackColor = true;
            this.checkBoxMod.CheckedChanged += new System.EventHandler(this.CheckBoxMod_Changed);
            // 
            // checkBoxBlueprint
            // 
            this.checkBoxBlueprint.AutoSize = true;
            this.checkBoxBlueprint.Location = new System.Drawing.Point(16, 63);
            this.checkBoxBlueprint.Name = "checkBoxBlueprint";
            this.checkBoxBlueprint.Size = new System.Drawing.Size(72, 17);
            this.checkBoxBlueprint.TabIndex = 6;
            this.checkBoxBlueprint.Text = "Blueprints";
            this.checkBoxBlueprint.UseVisualStyleBackColor = true;
            this.checkBoxBlueprint.CheckedChanged += new System.EventHandler(this.CheckBoxBlueprint_Changed);
            // 
            // checkBoxResource
            // 
            this.checkBoxResource.AutoSize = true;
            this.checkBoxResource.Location = new System.Drawing.Point(16, 87);
            this.checkBoxResource.Name = "checkBoxResource";
            this.checkBoxResource.Size = new System.Drawing.Size(77, 17);
            this.checkBoxResource.TabIndex = 7;
            this.checkBoxResource.Text = "Resources";
            this.checkBoxResource.UseVisualStyleBackColor = true;
            this.checkBoxResource.CheckedChanged += new System.EventHandler(this.CheckBoxResource_Changed);
            // 
            // checkBoxCredit
            // 
            this.checkBoxCredit.AutoSize = true;
            this.checkBoxCredit.Location = new System.Drawing.Point(16, 111);
            this.checkBoxCredit.Name = "checkBoxCredit";
            this.checkBoxCredit.Size = new System.Drawing.Size(58, 17);
            this.checkBoxCredit.TabIndex = 8;
            this.checkBoxCredit.Text = "Credits";
            this.checkBoxCredit.UseVisualStyleBackColor = true;
            this.checkBoxCredit.CheckedChanged += new System.EventHandler(this.CheckBoxCredit_Changed);
            // 
            // Secondary_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(338, 221);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxCredit);
            this.Controls.Add(this.checkBoxResource);
            this.Controls.Add(this.checkBoxBlueprint);
            this.Controls.Add(this.checkBoxMod);
            this.Controls.Add(this.FilterLabel);
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
        private Label FilterLabel;
        private CheckBox checkBoxMod;
        private CheckBox checkBoxBlueprint;
        private CheckBox checkBoxResource;
        private CheckBox checkBoxCredit;
    }
}