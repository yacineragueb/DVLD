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

namespace DVLD_project
{
    public partial class frmLogin : Form
    {
        private bool _IsPasswordVisible = false;

        private clsUser _User;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPasswordVisible_Click(object sender, EventArgs e)
        {
            if (!_IsPasswordVisible)
            {
                btnPasswordVisible.ImageIndex = 0; // Opened eye
                txtbPassword.PasswordChar = '\0';
            }
            else
            {
                btnPasswordVisible.ImageIndex = 1; // Closed eye
                txtbPassword.PasswordChar = '*';
            }

            _IsPasswordVisible = !_IsPasswordVisible;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = clsUser.FindUserByUserNameAndPassword(txtbUsername.Text, txtbPassword.Text);

            if(_User == null)
            {
                MessageBox.Show("Incorrect Username or Password. Please try again.", "Faild To Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!_User.IsActive)
            {
                MessageBox.Show("Sorry, Looks like you account is not active." + Environment.NewLine + "Contact you admin for more details.", "Faild To Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.CurrentUser = _User;

            frmMain frm = new frmMain(this);
            frm.Show();

            this.Hide();
        }
    }
}
