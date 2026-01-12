using DVLD_project.Properties;
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
using static DVLDBusinessLayer.clsTestTypes;

namespace DVLD_project.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LDLApplicationID;
        private clsTestTypes.enTestType _TestTypeID;

        private DataTable _dtTestAppointments; 

        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        public frmListTestAppointments(int LDLApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void _UpdateFormHeader()
        {
            clsTestTypes TestType = clsTestTypes.Find((int)_TestTypeID);

            if (TestType == null)
            {
                MessageBox.Show("Test Type with ID = " + _TestTypeID + " Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    pbTestImage.Image = Resources.OpenedEye;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    pbTestImage.Image = Resources.TestType;
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    pbTestImage.Image = Resources.Street;
                    break;
            }

            lblTestTitle.Text = TestType.GetTestTypeString() + " Appointement";
        }

        private void _LoadTestAppointments()
        {
            _dtTestAppointments = clsTestAppointment.GetAllTestAppointmentsByTestType(_LDLApplicationID, _TestTypeID);
            dgvTestAppointments.DataSource = _dtTestAppointments;

            lblRecords.Text = dgvTestAppointments.Rows.Count.ToString();

            if (dgvTestAppointments.Rows.Count > 0)
            {
                dgvTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns[0].Width = 150;

                dgvTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns[1].Width = 200;

                dgvTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns[2].Width = 150;

                dgvTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvTestAppointments.Columns[3].Width = 100;
            }
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _UpdateFormHeader();

            _LoadTestAppointments();

            ctrlLDLApplicationDetailsCard.LoadData(_LDLApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLApplicationID);

            if (LDLApplication != null)
            {
                if (LDLApplication.HasAnActiveAppointment(_TestTypeID))
                {
                    MessageBox.Show("Person already have an active appointment for this test, you cannot add new appointment.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsTest LastTest = LDLApplication.GetLastTestPerTestType(_TestTypeID);

                if (LastTest == null)
                {
                    frmScheduleTest frm1 = new frmScheduleTest(_LDLApplicationID, _TestTypeID);
                    frm1.ShowDialog();
                    frmListTestAppointments_Load(null, null);
                    return;
                }

                //if person already passed the test s/he cannot retak it.
                if (LastTest.TestResult == clsTest.enTestResult.Pass)
                {
                    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmScheduleTest frm2 = new frmScheduleTest(LastTest._TestAppointmentInfo.LDLApplicationID, _TestTypeID);
                frm2.ShowDialog();
                frmListTestAppointments_Load(null, null);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
    }
}
