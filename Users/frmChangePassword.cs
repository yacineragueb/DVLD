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

namespace DVLD_project.Users
{
    public partial class frmChangePassword : Form
    {
        private bool _IsNewPasswordVisible = false;
        private bool _IsConfirmPasswordVisible = false;

        private int _UserID;

        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _User = clsUser.Find(_UserID);
            ctrlUserDetailsCard1.LoadData(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtbNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ValidateCurrentPassword(object sender, CancelEventArgs e)
        {
            if(txtbCurrentPassword.Text != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbCurrentPassword, "Current password is incorrect!");
            } else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtbCurrentPassword, "");
            }
        }

        private void txtbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtbNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbNewPassword, "New password cannot be a blank.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbNewPassword, "");
            }
        }

        private void txtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtbConfirmPassword.Text != txtbNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbConfirmPassword, "The password must be match.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbConfirmPassword, "");
            }
        }

        private void btnNewPasswordVisible_Click(object sender, EventArgs e)
        {
            if(!_IsNewPasswordVisible)
            {
                btnNewPasswordVisible.ImageIndex = 0;
                txtbNewPassword.PasswordChar = '\0';
            }
            else
            {
                btnNewPasswordVisible.ImageIndex = 1;
                txtbNewPassword.PasswordChar = '*';
            }

            _IsNewPasswordVisible = !_IsNewPasswordVisible;
        }

        private void btnConfirmPasswordVisible_Click(object sender, EventArgs e)
        {
            if (!_IsConfirmPasswordVisible)
            {
                btnConfirmPasswordVisible.ImageIndex = 0;
                txtbConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                btnConfirmPasswordVisible.ImageIndex = 1;
                txtbConfirmPassword.PasswordChar = '*';
            }

            _IsConfirmPasswordVisible = !_IsConfirmPasswordVisible;
        }
    }
}
