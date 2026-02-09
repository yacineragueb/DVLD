using ContactsBusinessLayer;
using DVLD_project.Properties;
using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;


namespace DVLD_project
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode _Mode = enMode.AddNew;

        int _PersonID;
        clsPerson _Person;

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if( _PersonID == -1 )
            {
                _Mode = enMode.AddNew;
            } else
            {
                _Mode = enMode.Edit;
            }
        }

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Person";
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            } else
            {
                this.Text = "Edit Person";
                lblTitle.Text = "Edit Person";
            }

            if (rbtnMale.Checked)
            {
                pbPersonImage.Image = Resources.MalePerson;
            }
            else
            {
                pbPersonImage.Image = Resources.FemalePerson;
            }

            LlblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            // Set Default Country To Algeria
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

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
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.Gender == clsPerson.enGender.Male)
            {
                rbtnMale.Checked = true;
                pbGender.Image = Resources.Male;
            } else
            {
                rbtnFemale.Checked = true;
                pbGender.Image = Resources.Female;
            }

            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            LlblRemoveImage.Visible = (_Person.ImagePath != "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Edit)
            {
                _LoadData();
            }
        }

        private void LlblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                pbPersonImage.ImageLocation = selectedFilePath;

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

        private bool _HandlePersonImage()
        {
            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    } catch (Exception ex)
                    {
                        clsLogger.LogError(ex, "_HandlePersonImage failed");
                    }
                }

                if(pbPersonImage.ImageLocation != null)
                {
                   string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if(clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                // Here we dont continue because the form is not valid
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage()) return;

            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.FirstName = txtbFirstName.Text.Trim();
            _Person.SecondName = txtbSecondName.Text.Trim();
            _Person.ThirdName = txtbThirdName.Text.Trim();
            _Person.LastName = txtbLastName.Text.Trim();
            _Person.NationalNo = txtbNationalNo.Text.Trim();
            
            if(rbtnMale.Checked)
            {
                _Person.Gender = clsPerson.enGender.Male;
            } else
            {
                _Person.Gender = clsPerson.enGender.Female;
            }

            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = txtbAddress.Text.Trim();
            _Person.Email = txtbEmail.Text.Trim();
            _Person.Phone = txtbPhone.Text.Trim();
            _Person.NationalityCountryID = CountryID;

            if(pbPersonImage.ImageLocation != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            } else
            {
                _Person.ImagePath = "";
            }

            if (_Person.Save())
            {
                _Mode = enMode.Edit;
                lblTitle.Text = "Edit Person";
                lblPersonID.Text = _Person.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to PersonDetails
                DataBack?.Invoke(this, _Person.ID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Validate National Number
        private void txtbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if(clsPerson.IsPersonExistByNationalNo(txtbNationalNo.Text.Trim()) && txtbNationalNo.Text.Trim() != _Person.NationalNo)
            {
                errorProvider1.SetError(txtbNationalNo, "This National No is aleardy exists");
                txtbNationalNo.Focus();
            } else
            {
                errorProvider1.SetError(txtbNationalNo, "");
            }
        }

        // Validate Email
        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var add = new MailAddress(txtbEmail.Text);
                errorProvider1.SetError(txtbEmail, "");
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex, "txtbEmail_TextChanged failed");
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
