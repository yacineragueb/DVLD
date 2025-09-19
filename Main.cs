using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_project.Users;
using DVLDBusinessLayer;

namespace DVLD_project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        frmListPeople frmListPeople = new frmListPeople();
        frmListUsers frmListUsers = new frmListUsers();

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers.ShowDialog();
        }
    }
}
