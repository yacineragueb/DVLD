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
            AddEditPerson addEditPersonForm = new AddEditPerson(-1);
            addEditPersonForm.ShowDialog();
            _RefreshContactsList();
        }
    }
}
