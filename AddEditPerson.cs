using ContactsBusinessLayer;
using DVLD_project.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        private string _newImagePath = null;

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
            cbCountry.SelectedIndex = 2;

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

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);
        }

        private void _ChangeImagePath()
        {
            if (!string.IsNullOrEmpty(_newImagePath))
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }

                string destinationFolder = @"D:\DVLD\Images";
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_newImagePath);
                string destinationPath = Path.Combine(destinationFolder, fileName);

                File.Copy(_newImagePath, destinationPath, true);

                _Person.ImagePath = destinationPath;

                _newImagePath = null;
            }
            else
            {
               _Person.ImagePath = string.Empty;
            }
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
                _newImagePath = openFileDialog1.FileName;

                pbPersonImage.Load(_newImagePath);

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

            pbPersonImage.ImageLocation = null;
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

            _ChangeImagePath();

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
            if(string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                pbPersonImage.Image = Resources.FemalePerson;
            }
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.Male;
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                pbPersonImage.Image = Resources.MalePerson;
            }
            
        }

        private void ValidateRequiring(TextBox TxtBox, string TxtBoxName, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBox.Text))
            {
                e.Cancel = true;
                TxtBox.Focus();
                errorProvider1.SetError(TxtBox, TxtBoxName + " is Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TxtBox, "");
            }
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            ValidateRequiring(txtBox, txtBox.Tag.ToString(), e);
        }

        private void txtbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if(clsPerson.IsPersonExistByNationalNo(txtbNationalNo.Text) && Mode == enMode.AddNew)
            {
                errorProvider1.SetError(txtbNationalNo, "This National No is aleardy exists");
                txtbNationalNo.Focus();
            } else
            {
                errorProvider1.SetError(txtbNationalNo, "");
            }
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var add = new MailAddress(txtbEmail.Text);
                errorProvider1.SetError(txtbEmail, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtbEmail, "Enter a valide email");
                txtbEmail.Focus();
            }
        }

        private void AllowDigitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AllowLettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
