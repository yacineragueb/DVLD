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

namespace DVLD_project.Applications.Controls
{
    public partial class ctrlApplicationDetailsCard : UserControl
    {
        private clsApplication _Application = null;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }

        public ctrlApplicationDetailsCard()
        {
            InitializeComponent();
        }

        private void _FillApplicationInformation()
        {
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblApplicationStatus.Text = _Application.GetApplicationStatusString();
            lblApplicationFees.Text = _Application.PaidFees.ToString();
            lblApplicationType.Text = _Application.ApplicationType.Title;
            lblApplicant.Text = _Application.Person.FullName();
            lblApplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblApplicationStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _Application.User.UserName;
        }

        public void LoadData(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);

            if (_Application == null)
            {
                MessageBox.Show("Application with ID = " + ApplicationID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationID = ApplicationID;
            _FillApplicationInformation();
        }

        private void LlblViewPersonInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_Application.Person.ID);
            frm.ShowDialog();
        }
    }
}
