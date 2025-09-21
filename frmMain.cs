using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_project.ApplicationType;
using DVLD_project.Users;
using DVLDBusinessLayer;

namespace DVLD_project
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain( frmLogin LoginForm)
        {
            InitializeComponent();
            _frmLogin = LoginForm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();
            frmListPeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frmListUsers = new frmListUsers();
            frmListUsers.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationType frm = new frmManageApplicationType();
            frm.ShowDialog();
        }
    }
}
