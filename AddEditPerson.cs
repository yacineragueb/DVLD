using ContactsBusinessLayer;
using DVLD_project.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_project
{
    public partial class AddEditPerson : Form
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode Mode = enMode.AddNew;

        int _PersonID;
        clsPerson _Person;

        public AddEditPerson( int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if( _PersonID == -1 )
            {
                Mode = enMode.AddNew;
            } else
            { 
                Mode = enMode.Edit;
            }
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable table = clsCountry.GetAllCountries();

            foreach(DataRow row in table.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            cbCountry.SelectedIndex = 0;

            if(Mode == enMode.AddNew)
            {
                this.Text = "Add New Person";
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Edit Person";
            lblTitle.Text = "Edit Person";
            txtbFirstName.Text = _Person.FirstName;
            txtbSecondName.Text = _Person.SecondName;
            txtbThirdName.Text = _Person.ThirdName;
            txtbLastName.Text = _Person.LastName;
            txtbNationalNo.Text = _Person.NationalNo;
            txtbEmail.Text = _Person.Email;
            txtbAddress.Text = _Person.Address;
            txtbPhone.Text = _Person.Phone;
            lblPersonID.Text = _PersonID.ToString();
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if(_Person.Gender == clsPerson.enGender.Male)
            {
                rbtnMale.Checked = true;
                pbGender.Image = Resources.Male;
                pbPersonImage.Image = Resources.MalePerson;
            } else
            {
                rbtnFemale.Checked = true;
                pbGender.Image = Resources.Female;
                pbPersonImage.Image = Resources.FemalePerson;
            }

            if (_Person.ImagePath != "")
            {
                pbPersonImage.Load(_Person.ImagePath);
            } else
            {
                if(_Person.Gender == clsPerson.enGender.Male)
                {
                    pbPersonImage.Image = Resources.MalePerson;
                } else
                {
                    pbPersonImage.Image = Resources.FemalePerson;
                }
            }

            LlblRemoveImage.Visible = (_Person.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void LlblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                pbPersonImage.Load(selectedFilePath);
                LlblRemoveImage.Visible = true;
            }
        }

        private void LlblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbtnMale.Checked) 
            { 
                pbPersonImage.Image = Resources.MalePerson;
            } else
            {
                pbPersonImage.Image = Resources.FemalePerson;
            }

            LlblRemoveImage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.FirstName = txtbFirstName.Text;
            _Person.SecondName = txtbSecondName.Text;
            _Person.ThirdName = txtbThirdName.Text;
            _Person.LastName = txtbLastName.Text;
            _Person.NationalNo = txtbNationalNo.Text;
            
            if(rbtnMale.Checked)
            {
                _Person.Gender = clsPerson.enGender.Male;
            } else
            {
                _Person.Gender = clsPerson.enGender.Female;
            }

            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = txtbAddress.Text;
            _Person.Email = txtbEmail.Text;
            _Person.Phone = txtbPhone.Text;
            _Person.NationalityCountryID = CountryID;

            if(pbPersonImage.Image == Resources.FemalePerson || pbPersonImage.Image == Resources.MalePerson || string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                _Person.ImagePath = string.Empty;
            } else
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }

            if (_Person.Save())
                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Mode = enMode.Edit;
            lblTitle.Text = "Edit Person";
            lblPersonID.Text = _Person.ID.ToString();
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.Female;
            pbPersonImage.Image = Resources.FemalePerson;
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.Male;
            pbPersonImage.Image = Resources.MalePerson;
        }
    }
}
