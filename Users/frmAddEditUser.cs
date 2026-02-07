using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_project.Users
{
    public partial class frmAddEditUser : Form
    {
        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        enMode _Mode = enMode.AddNew;

        private bool _IsPasswordVisible = false;
        private bool _IsConfirmPasswordVisible = false;

        private int _UserID;

        private clsUser _User;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if(_UserID == -1)
            {
                _Mode = enMode.AddNew;
            } else
            {
                _Mode = enMode.Edit;
            }
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New User";
                lblTitle.Text = "Add New User";
                _User = new clsUser();
            }
            else
            {
                this.Text = "Edit User";
                lblTitle.Text = "Edit User";
            }
        }

        private void tbUserDetails_SelectedIndexChange(object sender, EventArgs e)
        {
            if(tbUserInfo.SelectedIndex == 0)
            {
                btnSave.Enabled = false;
            } else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _UserID.ToString();
            ctrlPersonDetailsWithFilter1.LoadData(_User.PersonID);
            txtbUsername.Text = _User.UserName;
            gbPasswordInformation.Visible = false;
            txtbPassword.Text = _User.Password;
            txtbConfirmPassword.Text = _User.Password;
            ckbIsActive.Checked = _User.IsActive;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Edit)
            {
                _LoadData();
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

        private void txtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtbConfirmPassword.Text != txtbPassword.Text)
            {
                e.Cancel=true;
                errorProvider1.SetError(txtbConfirmPassword, "The password must be match.");
            } else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbConfirmPassword, "");
            }
        }

        private bool _HandleSelectedPerson()
        {
            if (ctrlPersonDetailsWithFilter1.GetSelectedPerson() != null)
            {
                int selectedPersonID = ctrlPersonDetailsWithFilter1.GetSelectedPersonID();

                if (_Mode == enMode.Edit && selectedPersonID == _User.PersonID)
                {
                    return true;
                }

                if (!clsUser.IsUserExist(selectedPersonID))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Selected person is already a user, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUserInfo.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("You did not select a person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserInfo.SelectedIndex = 0;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                // Here we dont continue because the form is not valid
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleSelectedPerson()) return;

            int PersonID = ctrlPersonDetailsWithFilter1.GetSelectedPersonID();

            _User.UserName = txtbUsername.Text.Trim();

            if(_Mode == enMode.AddNew)
            {
                string Password = txtbPassword.Text.Trim();
                _User.Password = clsUtil.ComputeHash(Password);
            }

            _User.IsActive = ckbIsActive.Checked;
            _User.PersonID = PersonID;
            

            if (_User.Save())
            {
                _Mode = enMode.Edit;
                lblTitle.Text = "Edit User";
                lblUserID.Text = _User.UserID.ToString();
                gbPasswordInformation.Enabled = false;

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           tbUserInfo.SelectedIndex = 1;
           btnSave.Enabled = true;
        }

        private void btnPasswordVisible_Click(object sender, EventArgs e)
        {
            if (!_IsPasswordVisible)
            {
                btnPasswordVisible.ImageIndex = 1; // Opened eye
                txtbPassword.PasswordChar = '\0';
            }
            else
            {
                btnPasswordVisible.ImageIndex = 0; // Closed eye
                txtbPassword.PasswordChar = '*';
            }

            _IsPasswordVisible = !_IsPasswordVisible;
        }

        private void btnConfirmPasswordVisible_Click(object sender, EventArgs e)
        {
            if (!_IsConfirmPasswordVisible)
            {
                btnConfirmPasswordVisible.ImageIndex = 1; // Opened eye
                txtbConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                btnConfirmPasswordVisible.ImageIndex = 0; // Closed eye
                txtbConfirmPassword.PasswordChar = '*';
            }

            _IsConfirmPasswordVisible = !_IsConfirmPasswordVisible;
        }
    }
}
