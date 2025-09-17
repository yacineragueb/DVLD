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
    public partial class ManagePeopleForm : Form
    {

        private void FormatDvgPeopleTable()
        {
            dgvPeopleTable.Columns["NationalNo"].HeaderText = "National No";
            dgvPeopleTable.Columns["FirstName"].HeaderText = "First Name";
            dgvPeopleTable.Columns["SecondName"].HeaderText = "Second Name";
            dgvPeopleTable.Columns["ThirdName"].HeaderText = "Third Name";
            dgvPeopleTable.Columns["LastName"].HeaderText = "Last Name";
            dgvPeopleTable.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvPeopleTable.Columns["Gendor"].HeaderText = "Gender";
            dgvPeopleTable.Columns["NationalityCountryID"].HeaderText = "Nationality";
            dgvPeopleTable.Columns["ImagePath"].Visible = false;
        }

        private void _RefreshContactsList()
        {
            dgvPeopleTable.DataSource = clsPerson.GetAllPeople();
            lblRecords.Text = dgvPeopleTable.Rows.Count.ToString();
        }

        void ShowPersonDetails()
        {
            ShowPersonDetails Form = new ShowPersonDetails((int)dgvPeopleTable.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _RefreshContactsList();
        }

        void _AddEditPerson(int PersonID)
        {
            AddEditPerson addEditPersonForm = new AddEditPerson(PersonID);
            addEditPersonForm.ShowDialog();
            _RefreshContactsList();
        }

        public ManagePeopleForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshContactsList();
            FormatDvgPeopleTable();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonDetails();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            _AddEditPerson(-1);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddEditPerson(-1);
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
                    MessageBox.Show("User Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshContactsList();
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

        private void dgvPeopleTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPeopleTable.Columns[e.ColumnIndex].Name == "Gendor")
            {
                if(e.Value.ToString() == "0")
                {
                    e.Value = "Male";
                    e.FormattingApplied = true;
                } else
                {
                    e.Value = "Female";
                    e.FormattingApplied = true;
                }
            }

            if (dgvPeopleTable.Columns[e.ColumnIndex].Name == "NationalityCountryID")
            {
                e.Value = clsCountry.Find(Convert.ToInt32(e.Value)).CountryName;
                e.FormattingApplied = true;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtbFilter.Visible = false;
                dtpFilterByDate.Visible = false;
            } else if(cbFilter.SelectedIndex == 7)
            {
                txtbFilter.Visible = false;
                dtpFilterByDate.Visible = true;
            } else
            {
                txtbFilter.Visible = true;
                dtpFilterByDate.Visible = false;
            }

            txtbFilter.Clear();
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(cbFilter.SelectedIndex)
            {
                // Filter by National No
                case 1:
                    break;

                case 7:
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
            DataTable dt = clsPerson.GetAllPeople();
            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(txtbFilter.Text))
            {

                switch (cbFilter.SelectedIndex)
                {
                    case 0:
                        dv.RowFilter = "";
                        break;
                    case 1:
                        dv.RowFilter = $"NationalNo LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"FirstName LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"SecondName LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"ThirdName LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 5:
                        dv.RowFilter = $"LastName LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 6:
                        if (txtbFilter.Text.ToLower() == "m")
                        {
                            dv.RowFilter = $"Gendor = 0";
                        }
                        else if (txtbFilter.Text.ToLower() == "f")
                        {
                            dv.RowFilter = $"Gendor = 1";
                        }
                        else
                        {
                            dv.RowFilter = "";
                        }
                        break;
                    case 7:
                        //DateTime selectedDate = dtpFilterByDate.Value.Date;
                        //DateTime nextDate = selectedDate.AddDays(1);
                        //dv.RowFilter = $"DateOfBirth >= #{selectedDate:MM/dd/yyyy}# AND DateOfBirth < #{nextDate:MM/dd/yyyy}#";
                        break;
                    case 8:
                        dv.RowFilter = $"Phone LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 9:
                        dv.RowFilter = $"Address LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 10:
                        dv.RowFilter = $"Email LIKE '%{txtbFilter.Text}%'";
                        break;
                    case 11:
                        clsCountry Country = clsCountry.Find(txtbFilter.Text);
                        if (Country != null) {
                            dv.RowFilter = $"NationalityCountryID = {Country.ID}"; 
                        }
                        break;
                }
            }

            dgvPeopleTable.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();
        }
    }
}
