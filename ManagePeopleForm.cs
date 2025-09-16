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

namespace DVLD_project
{
    public partial class ManagePeopleForm : Form
    {
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
    }
}
