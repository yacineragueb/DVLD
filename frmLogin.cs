using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void _HandleSaveCredentials()
        {
            string Username = txtbUsername.Text;
            string Password = txtbPassword.Text;

            if(ckbRememberMe.Checked)
            {
                clsUtil.SaveCredentials(Username, Password);
            } else
            {
                if(File.Exists(clsGlobal.FilePath)) {
                    File.Delete(clsGlobal.FilePath);
                }
            }
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

            _HandleSaveCredentials();

            clsGlobal.CurrentUser = _User;

            this.Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var credentials = clsUtil.LoadCredentails();

            if(credentials.Username != null)
            {
                txtbUsername.Text = credentials.Username;
                txtbPassword.Text = credentials.Password;
                ckbRememberMe.Checked = true;
            } else
            {
                ckbRememberMe.Checked = false;
            }
        }
    }
}
