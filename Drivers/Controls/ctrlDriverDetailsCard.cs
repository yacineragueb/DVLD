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
using System.IO;

namespace DVLD_project.Drivers.Controller
{
    public partial class ctrlDriverDetailsCard : UserControl
    {
        private clsDriver _Driver = null;

        public ctrlDriverDetailsCard()
        {
            InitializeComponent();
        }

        private void _FillDriverInformation()
        {
            lblLicenseClass.Text = _Driver._LicenseInfo._LicenseClass.ClassName; // There is error here
            lblName.Text = _Driver._PersonInfo.FullName();
            lblLicenseID.Text = _Driver._LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _Driver._PersonInfo.NationalNo;

            switch (_Driver._PersonInfo.Gender)
            {
                case clsPerson.enGender.Male:
                    pbGender.Image = Resources.Male;
                    pbDriverImage.Image = Resources.MalePerson;
                    lblGender.Text = "Male";
                    break;
                case clsPerson.enGender.Female:
                    pbGender.Image = Resources.Female;
                    pbDriverImage.Image = Resources.FemalePerson;
                    lblGender.Text = "Female";
                    break;
            }

            lblIssueDate.Text = _Driver._LicenseInfo.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _Driver._LicenseInfo.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = _Driver._LicenseInfo.GetIssueReasonString();

            if (string.IsNullOrEmpty(_Driver._LicenseInfo.Notes))
            {
                lblNotes.Text = "No Notes";
            } else
            {
                lblNotes.Text = _Driver._LicenseInfo.Notes;
            }

            lblIsAcitve.Text = _Driver._LicenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _Driver._PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _Driver.DriverID.ToString();
            lblIsDetained.Text = "This will add later";

            string ImagePath = _Driver._PersonInfo.ImagePath;
            if (! string.IsNullOrEmpty(ImagePath))
            {
                if (File.Exists(ImagePath))
                {
                    pbDriverImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoadData(int DriverID)
        {
            _Driver = clsDriver.Find(DriverID);

            if ( _Driver == null )
            {
                MessageBox.Show("Driver with ID = " + DriverID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDriverInformation();
        }

        public void LoadData(string PersonNationalNo)
        {
            _Driver = clsDriver.Find(PersonNationalNo);

            if (_Driver == null)
            {
                MessageBox.Show("Driver with Person National No. = " + PersonNationalNo + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDriverInformation();
        }
    }
}
