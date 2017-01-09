using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    public partial class Secondary_Form : Form
    {
        private Main_Window Main_Form = null;
        bool Phase_Shift = false;

        bool Initial_R;
        bool Initial_M;
        bool Initial_B;
        bool Initial_C;

        public Secondary_Form(Main_Window MW, bool ResourceFlag, bool ModFlag, bool CreditFlag, bool BlueprintFlag)
        {
            Main_Form = MW;
            InitializeComponent();
            textBoxInterval.Text = (Main_Form.Update_Interval / (60 * 1000)).ToString();

            Initial_R = ResourceFlag;
            Initial_M = ModFlag;
            Initial_C = CreditFlag;
            Initial_B = BlueprintFlag;

            Phase_Shift = true;

            if (ResourceFlag)
            {
                checkBoxResource.Checked = true;
            }

            if (ModFlag)
            {
                checkBoxMod.Checked = true;
            }

            if (CreditFlag)
            {
                checkBoxCredit.Checked = true;
            }

            if (BlueprintFlag)
            {
                checkBoxBlueprint.Checked = true;
            }

            Phase_Shift = false;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            string Input = textBoxInterval.Text;

            int Input_To_Int;

            if (!Int32.TryParse(Input, out Input_To_Int))
            {
                string message = "Please insert a valid input";
                string caption = "Invalid Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }

            Main_Form.Update_Interval = Input_To_Int * 60 * 1000;
            this.Close();
        }

        private void CheckBoxResource_Changed(object sender, EventArgs e)
        {
            if (!Phase_Shift)
            {
                if (checkBoxResource.Checked)
                {
                    Main_Form.Resource_Filter = true;
                }
                else
                {
                    Main_Form.Resource_Filter = false;
                }
            }
        }

        private void CheckBoxCredit_Changed(object sender, EventArgs e)
        {
            if (!Phase_Shift)
            {
                if (checkBoxCredit.Checked)
                {
                    Main_Form.Credit_Filter = true;
                }
                else
                {
                    Main_Form.Credit_Filter = false;
                }
            }
        }

        private void CheckBoxMod_Changed(object sender, EventArgs e)
        {
            if (!Phase_Shift)
            {
                if (checkBoxMod.Checked)
                {
                    Main_Form.Mod_Filter = true;
                }
                else
                {
                    Main_Form.Mod_Filter = false;
                }
            }
        }

        private void CheckBoxBlueprint_Changed(object sender, EventArgs e)
        {
            if (!Phase_Shift)
            {
                if (checkBoxBlueprint.Checked)
                {
                    Main_Form.Blueprint_Filter = true;
                }
                else
                {
                    Main_Form.Blueprint_Filter = false;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Main_Form.Blueprint_Filter = Initial_B;
            Main_Form.Resource_Filter = Initial_R;
            Main_Form.Credit_Filter = Initial_C;
            Main_Form.Mod_Filter = Initial_M;

            this.Close();
        }
    }
}
