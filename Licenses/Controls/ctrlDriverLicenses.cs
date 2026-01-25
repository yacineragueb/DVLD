using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _PersonID;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void LoadLocalLicenses()
        {
            dgvLocalLicensesHistory.DataSource = clsLicense.GetDriverLicenses(_PersonID);

            lblRecordsOfLocalLicenses.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "License ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 200;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 120;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 120;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 70;
            }
        }

        private void LoadInternationalLicenses()
        {
            dgvInternationalLicensesHistory.DataSource = clsLicense.GetDriverInternationalLicenses(_PersonID);

            lblRecordsOfInternationalLicenses.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 110;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 110;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 110;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 130;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 130;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;

            }
        }

        public void LoadData(int PersonID)
        {
            _PersonID = PersonID;

            LoadLocalLicenses();
            LoadInternationalLicenses();
        }
    }
}
