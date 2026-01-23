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

namespace DVLD_project.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private DataTable _dtDrivers = clsDriver.GetAllDrivers();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dgvDriversTable.DataSource = _dtDrivers;
            cbFilter.SelectedIndex = 0;

            lblRecords.Text = dgvDriversTable.Rows.Count.ToString();

            if(dgvDriversTable.Rows.Count > 0 )
            {
                dgvDriversTable.Columns[0].HeaderText = "Driver ID";
                dgvDriversTable.Columns[0].Width = 110;

                dgvDriversTable.Columns[1].HeaderText = "Person ID";
                dgvDriversTable.Columns[1].Width = 110;

                dgvDriversTable.Columns[2].HeaderText = "National No.";
                dgvDriversTable.Columns[2].Width = 110;

                dgvDriversTable.Columns[3].HeaderText = "Full Name";
                dgvDriversTable.Columns[3].Width = 220;

                dgvDriversTable.Columns[4].HeaderText = "Date";
                dgvDriversTable.Columns[4].Width = 160;

                dgvDriversTable.Columns[5].HeaderText = "Number Of Active Licenses";
                dgvDriversTable.Columns[5].Width = 170;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtDrivers.DefaultView.RowFilter = "";
            lblRecords.Text = dgvDriversTable.Rows.Count.ToString();

            if (cbFilter.SelectedIndex == 0) // None
            {
                txtbFilter.Visible = false;
            }
            else
            {
                txtbFilter.Visible = true;
                txtbFilter.Focus();
            }

            txtbFilter.Clear();
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                // Filter by DriverID OR Person ID
                case 1:
                case 2:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;

                // Filter by National No.
                case 3:
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
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "";
                    break;
            }

            // Reset the filter in case nothing selected or filter value contains nothing.
            if (txtbFilter.Text.Trim() == "" || FilterColumn == "")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDriversTable.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "DriverID")
            {
                // In this case we deal with integer not string.
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilter.Text.Trim());
            }
            else
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbFilter.Text.Trim());
            }

            lblRecords.Text = dgvDriversTable.Rows.Count.ToString();
        }
    }
}
