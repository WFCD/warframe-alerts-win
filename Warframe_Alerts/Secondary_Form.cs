using System;
using System.Windows.Forms;

namespace Warframe_Alerts
{
    public partial class SecondaryForm : Form
    {
        private readonly MainWindow _mainForm;

        private readonly bool _phaseShift;
        private readonly bool _initialR;
        private readonly bool _initialM;
        private readonly bool _initialB;
        private readonly bool _initialC;
        private readonly bool _initialD;

        public SecondaryForm(MainWindow mw, bool resourceFlag, bool modFlag, bool creditFlag, bool blueprintFlag, bool detectionFlag)
        {
            _mainForm = mw;
            InitializeComponent();
            textBoxInterval.Text = (_mainForm.UpdateInterval / (60 * 1000)).ToString();

            _initialR = resourceFlag;
            _initialM = modFlag;
            _initialC = creditFlag;
            _initialB = blueprintFlag;
            _initialD = detectionFlag;

            _phaseShift = true;

            if (resourceFlag)
            {
                checkBoxResource.Checked = true;
            }

            if (modFlag)
            {
                checkBoxMod.Checked = true;
            }

            if (creditFlag)
            {
                checkBoxCredit.Checked = true;
            }

            if (blueprintFlag)
            {
                checkBoxBlueprint.Checked = true;
            }

            if (detectionFlag)
            {
                checkBoxDetection.Checked = true;
            }

            _phaseShift = false;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            var input = textBoxInterval.Text;

            if (!Int32.TryParse(input, out var inputToInt))
            {
                var message = "Please insert a valid input";
                var caption = "Invalid Input";
                var buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }

            _mainForm.UpdateInterval = inputToInt * 60 * 1000;

            _mainForm.Update_Settings_XML();
            
            Action update = _mainForm.WF_Update;
            update.BeginInvoke(ar => update.EndInvoke(ar), null);

            Close();
        }

        private void CheckBoxResource_Changed(object sender, EventArgs e)
        {
            if (!_phaseShift)
            {
                _mainForm.ResourceFilter = checkBoxResource.Checked;
            }
        }

        private void CheckBoxCredit_Changed(object sender, EventArgs e)
        {
            if (!_phaseShift)
            {
                _mainForm.CreditFilter = checkBoxCredit.Checked;
            }
        }

        private void CheckBoxMod_Changed(object sender, EventArgs e)
        {
            if (!_phaseShift)
            {
                _mainForm.ModFilter = checkBoxMod.Checked;
            }
        }

        private void CheckBoxBlueprint_Changed(object sender, EventArgs e)
        {
            if (!_phaseShift)
            {
                _mainForm.BlueprintFilter = checkBoxBlueprint.Checked;
            }
        }

        private void CheckBoxDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (!_phaseShift)
            {
                _mainForm.GameDetection = checkBoxDetection.Checked;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            _mainForm.BlueprintFilter = _initialB;
            _mainForm.ResourceFilter = _initialR;
            _mainForm.CreditFilter = _initialC;
            _mainForm.ModFilter = _initialM;
            _mainForm.GameDetection = _initialD;

            Close();
        }
    }
}
