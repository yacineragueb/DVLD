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
        private clsLicense _License = null;
        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return _License; } }

        public ctrlDriverDetailsCard()
        {
            InitializeComponent();
        }

        private void _FillDriverInformation()
        {
            lblLicenseClass.Text = _License._LicenseClass.ClassName; // There is error here
            lblName.Text = _License._DriverInfo._PersonInfo.FullName();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License._DriverInfo._PersonInfo.NationalNo;

            clsPerson.enGender Gender = _License._DriverInfo._PersonInfo.Gender;

            switch (Gender)
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

            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = _License.GetIssueReasonString();

            if (string.IsNullOrEmpty(_License.Notes))
            {
                lblNotes.Text = "No Notes";
            } else
            {
                lblNotes.Text = _License.Notes;
            }

            lblIsAcitve.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License._DriverInfo._PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License._DriverInfo.DriverID.ToString();
            lblIsDetained.Text = "This will add later";

            string ImagePath = _License._DriverInfo._PersonInfo.ImagePath;
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

        public void LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);

            if (_License == null )
            {
                MessageBox.Show("Driver with license ID = " + _LicenseID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _FillDriverInformation();
        }
    }
}
