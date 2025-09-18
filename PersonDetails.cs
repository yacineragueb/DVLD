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

namespace DVLD_project
{
    public partial class PersonDetails : UserControl
    {
        clsPerson _Person;
        public PersonDetails()
        {
            InitializeComponent();
        }

        public void LoadData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                lblPersonID.Text = PersonID.ToString();
                lblName.Text = _Person.FullName();
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblNationalNo.Text = _Person.NationalNo;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

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

                if (_Person.ImagePath != "")
                {
                    pbPersonImage.Load(_Person.ImagePath);
                }

            } else
            {
                MessageBox.Show("Person not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LlblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson addEditPersonForm = new frmAddEditPerson(_Person.ID);
            addEditPersonForm.DataBack += AddEditPerson_DataBack; // Subscribe to the event
            addEditPersonForm.ShowDialog();
        }

        void AddEditPerson_DataBack(object sender, int PersonID)
        {
            LoadData(PersonID);
        }
    }
}
