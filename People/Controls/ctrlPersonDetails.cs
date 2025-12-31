using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;
using DVLD_project.Properties;
using DVLDBusinessLayer;
using System.IO;

namespace DVLD_project
{
    public partial class ctrlPersonDetails : UserControl
    {
        clsPerson _Person = null;

        private int _PersonID = -1;

        public int PersonID
        {
            get {  return _Person.ID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return _Person;
            }
        }

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }

        public void LoadData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                _PersonID = _Person.ID;
                lblPersonID.Text = PersonID.ToString();
                lblName.Text = _Person.FullName();
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblNationalNo.Text = _Person.NationalNo;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
                LlblEditPerson.Enabled = true;

                switch (_Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        pbGender.Image = Resources.Male;
                        pbPersonImage.Image = Resources.MalePerson;
                        lblGender.Text = "Male";
                        break;
                    case clsPerson.enGender.Female:
                        pbGender.Image = Resources.Female;
                        pbPersonImage.Image = Resources.FemalePerson;
                        lblGender.Text = "Female";
                        break;
                }

                string ImagePath = _Person.ImagePath;
                if (ImagePath != "")
                {
                    if(File.Exists(ImagePath))
                    {
                        pbPersonImage.ImageLocation = ImagePath;
                    }
                    else
                    {
                        MessageBox.Show("Could not find this image = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            } else
            {
                MessageBox.Show("Person with ID = " + PersonID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void LoadData(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person != null)
            {
                _PersonID = _Person.ID;
                lblPersonID.Text = _Person.ID.ToString();
                lblName.Text = _Person.FullName();
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblNationalNo.Text = NationalNo;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
                LlblEditPerson.Enabled = true;

                switch (_Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        pbGender.Image = Resources.Male;
                        pbPersonImage.Image = Resources.MalePerson;
                        lblGender.Text = "Male";
                        break;
                    case clsPerson.enGender.Female:
                        pbGender.Image = Resources.Female;
                        pbPersonImage.Image = Resources.FemalePerson;
                        lblGender.Text = "Female";
                        break;
                }

                string ImagePath = _Person.ImagePath;
                if (ImagePath != "")
                {
                    if (File.Exists(ImagePath))
                    {
                        pbPersonImage.ImageLocation = ImagePath;
                    }
                    else
                    {
                        MessageBox.Show("Could not find this image = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Person with NationalNo = " + NationalNo + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LlblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson addEditPersonForm = new frmAddEditPerson(_PersonID);
            addEditPersonForm.DataBack += AddEditPerson_DataBack; // Subscribe to the event
            addEditPersonForm.ShowDialog();
        }

        void AddEditPerson_DataBack(object sender, int PersonID)
        {
            LoadData(PersonID);
        }

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            if(lblPersonID.Text == "N/A")
            {
                LlblEditPerson.Enabled = false;
            }
        }
    }
}
