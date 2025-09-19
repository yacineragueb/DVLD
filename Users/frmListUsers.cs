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

        private void ChangePasswordToolStripMenuItme_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtUsers.DefaultView.RowFilter = "";
            lblRecords.Text = dgvUsersTable.Rows.Count.ToString();

            if (cbFilter.SelectedIndex == 0) // None
            {
                txtbFilter.Visible = false;
                cbFilterByIsActive.Visible = false;
            } else if (cbFilter.SelectedIndex == 5) // filter by Is Active
            {
                txtbFilter.Visible = false;
                cbFilterByIsActive.Visible = true;
            }
            else
            {
                cbFilterByIsActive.Visible = false;
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            cbFilterByIsActive.SelectedIndex = 0;
            txtbFilter.Clear();
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                // Filter by UserID
                case 1:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                // Filter by PersonID
                case 2:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;

                // Filter by UserName
                case 4:
                    break;

                default:
                    if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void txtbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "UserName";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if (txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvUsersTable.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                // In this case we deal with integer not string.
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbFilter.Text.Trim());
            }

            lblRecords.Text = dgvUsersTable.Rows.Count.ToString();
        }

        private void cbFilterByIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            if (cbFilter.Text == "Is Active")
            {
                FilterColumn = "IsActive";

                if (cbFilterByIsActive.Text == "All")
                {
                    _dtUsers.DefaultView.RowFilter = "";
                }
                else if (cbFilterByIsActive.Text == "Yes")
                {
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, true);
                }
                else
                {
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, false);
                }

                lblRecords.Text = dgvUsersTable.Rows.Count.ToString();
            }
        }
    }
}
