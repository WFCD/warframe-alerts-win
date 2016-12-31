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

        public Secondary_Form(Main_Window MW)
        {
            Main_Form = MW;
            InitializeComponent();
            textBoxInterval.Text = (Main_Form.Update_Interval/(60*1000)).ToString();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
