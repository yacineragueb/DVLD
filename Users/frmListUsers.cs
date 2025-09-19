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

namespace DVLD_project.Users
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers = clsUser.GetAllUsers();

        // Only select the columns that you want to show in the grid
        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

            dgvUsersTable.DataSource = _dtUsers;
            lblRecords.Text = dgvUsersTable.Rows.Count.ToString();
        }

        private void _ShowUserDetails()
        {
            int UserID = (int)dgvUsersTable.CurrentRow.Cells[0].Value;
            frmShowUserDetails Form = new frmShowUserDetails(UserID);
            Form.ShowDialog();
            _RefreshUsersList();
        }

        private void _AddEditUser(int UserID)
        {
            //frmAddEditPerson addEditPersonForm = new frmAddEditPerson(PersonID);
            //addEditPersonForm.ShowDialog();
            _RefreshUsersList();
        }
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvUsersTable.DataSource = _dtUsers;
            cbFilter.SelectedIndex = 0;

            lblRecords.Text = dgvUsersTable.Rows.Count.ToString();

            if (dgvUsersTable.Rows.Count > 0)
            {
                dgvUsersTable.Columns[0].HeaderText = "User ID";
                dgvUsersTable.Columns[0].Width = 110;

                dgvUsersTable.Columns[1].HeaderText = "Person ID";
                dgvUsersTable.Columns[1].Width = 110;

                dgvUsersTable.Columns[2].HeaderText = "Full Name";
                dgvUsersTable.Columns[2].Width = 220;

                dgvUsersTable.Columns[3].HeaderText = "Username";
                dgvUsersTable.Columns[3].Width = 120;

                dgvUsersTable.Columns[4].HeaderText = "Is Active";
                dgvUsersTable.Columns[4].Width = 110;
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User?", "Delete User", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsersTable.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Faild to delete this User because it has a data linked with it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowUserDetails();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            _AddEditUser(UserID);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            _AddEditUser(UserID);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsersTable.CurrentRow.Cells[0].Value;
            _AddEditUser(UserID);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
