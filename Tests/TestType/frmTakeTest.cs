using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.Tests.TestType
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;

        private clsTest _Test = null;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked ? clsTest.enTestResult.Pass : clsTest.enTestResult.Fail;
            _Test.Notes = txtbNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlShowTestInformation.SetLableTestID(_Test.TestID);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlShowTestInformation.LoadData(_TestAppointmentID);

            int _TestID = ctrlShowTestInformation.TestID;
            if (_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);

                bool IsPassedTest = _Test.TestResult == clsTest.enTestResult.Pass;

                if (IsPassedTest)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtbNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            else
                _Test = new clsTest();
        }
    }
}
