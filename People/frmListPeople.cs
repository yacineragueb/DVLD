using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;
using DVLDBusinessLayer;

namespace DVLD_project
{
    public partial class frmListPeople : Form
    {

        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        // Only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GenderCaption", "DateOfBirth", "CountryName", "Phone", "Email");

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeopleTable.DataSource = _dtPeople;
            lblRecords.Text = dgvPeopleTable.Rows.Count.ToString();
        }

        private void _ShowPersonDetails()
        {
            int PersonID = (int)dgvPeopleTable.CurrentRow.Cells[0].Value;
            frmShowPersonDetails Form = new frmShowPersonDetails(PersonID);
            Form.ShowDialog();
            _RefreshPeopleList();
        }

        private void _AddEditPerson(int PersonID)
        {
            frmAddEditPerson addEditPersonForm = new frmAddEditPerson(PersonID);
            addEditPersonForm.ShowDialog();
            _RefreshPeopleList();
        }

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            dgvPeopleTable.DataSource = _dtPeople;
            cbFilter.SelectedIndex = 0;

            lblRecords.Text = dgvPeopleTable.Rows.Count.ToString();

            if(dgvPeopleTable.Rows.Count > 0)
            {
                dgvPeopleTable.Columns[0].HeaderText = "Person ID";
                dgvPeopleTable.Columns[0].Width = 110;

                dgvPeopleTable.Columns[1].HeaderText = "National No.";
                dgvPeopleTable.Columns[1].Width = 120;

                dgvPeopleTable.Columns[2].HeaderText = "First Name";
                dgvPeopleTable.Columns[2].Width = 120;

                dgvPeopleTable.Columns[3].HeaderText = "Second Name";
                dgvPeopleTable.Columns[3].Width = 120;

                dgvPeopleTable.Columns[4].HeaderText = "Third Name";
                dgvPeopleTable.Columns[4].Width = 120;

                dgvPeopleTable.Columns[5].HeaderText = "Last Name";
                dgvPeopleTable.Columns[5].Width = 120;

                dgvPeopleTable.Columns[6].HeaderText = "Gender";
                dgvPeopleTable.Columns[6].Width = 120;

                dgvPeopleTable.Columns[7].HeaderText = "Date Of Birth";
                dgvPeopleTable.Columns[7].Width = 140;

                dgvPeopleTable.Columns[8].HeaderText = "Nationality";
                dgvPeopleTable.Columns[8].Width = 120;

                dgvPeopleTable.Columns[9].HeaderText = "Phone";
                dgvPeopleTable.Columns[9].Width = 120;

                dgvPeopleTable.Columns[10].HeaderText = "Email";
                dgvPeopleTable.Columns[10].Width = 170;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetails();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            _AddEditPerson(PersonID);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            _AddEditPerson(PersonID);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddEditPerson((int)dgvPeopleTable.CurrentRow.Cells[0].Value);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsPerson.DeletePerson((int)dgvPeopleTable.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Faild to delete this person because it has a data linked with it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
            } else
            {
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            txtbFilter.Clear();
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(cbFilter.SelectedIndex)
            {
                // Filter by PersonID
                case 1:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                // Filter by National No
                case 2:
                    break;

                // Filter by Phone number
                case 8:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
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
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if(txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecords.Text = dgvPeopleTable.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "PersonID")
            {
                // In this case we deal with integer not string.
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());
            } else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbFilter.Text.Trim());
            }

            lblRecords.Text = dgvPeopleTable.Rows.Count.ToString();
        }
    }
}
