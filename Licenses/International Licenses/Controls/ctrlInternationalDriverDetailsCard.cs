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

namespace DVLD_project.Licenses.International_Licenses.Controls
{
    public partial class ctrlInternationalDriverDetailsCard : UserControl
    {
        private clsInternationalLicenseApplication _InternationalLicenseApplication;

        public ctrlInternationalDriverDetailsCard()
        {
            InitializeComponent();
        }

        private void _FillInternationalDriverInformation()
        {
            lblName.Text = _InternationalLicenseApplication.Person.FullName();
            lblInternationalLicenseID.Text = _InternationalLicenseApplication.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalLicenseApplication.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicenseApplication.Person.NationalNo;

            clsPerson.enGender Gender = _InternationalLicenseApplication.Person.Gender;

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

            lblIssueDate.Text = _InternationalLicenseApplication.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _InternationalLicenseApplication.ExpirationDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicenseApplication.ApplicationID.ToString();
            lblIsAcitve.Text = _InternationalLicenseApplication.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicenseApplication.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicenseApplication._DriverInfo.DriverID.ToString();

            string ImagePath = _InternationalLicenseApplication.Person.ImagePath;
            if (!string.IsNullOrEmpty(ImagePath))
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

        public void LoadData(int InternationalLicenseApplicationID)
        {
            _InternationalLicenseApplication = clsInternationalLicenseApplication.Find(InternationalLicenseApplicationID);

            if (_InternationalLicenseApplication == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + InternationalLicenseApplicationID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInternationalDriverInformation();
        }
    }
}
