using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                lblPersonID.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblNationalNo.Text = _Person.NationalNo;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();

                switch (_Person.Gender)
                {
                    case clsPerson.enGender.Male:
                        lblGender.Text = "Male";
                        break;
                    case clsPerson.enGender.Female:
                        lblGender.Text = "Female";
                        break;
                }

                if (_Person.ImagePath != "")
                {
                    pbPersonImage.Load(_Person.ImagePath);
                }

                // Country will be here!!

            } else
            {
                MessageBox.Show("Person not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
