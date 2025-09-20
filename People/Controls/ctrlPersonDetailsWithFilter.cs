using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.People.Controls
{
    public partial class ctrlPersonDetailsWithFilter : UserControl
    {
        private int _PersonID = -1;

        private string _NationalNo = "";

        public ctrlPersonDetailsWithFilter()
        {
            InitializeComponent();

            cbFilter.SelectedIndex = 0;
        }

        public int GetSelectedPersonID()
        {
            return ctrlPersonDetails1.PersonID;
        }

        public clsPerson GetSelectedPerson()
        {
            return ctrlPersonDetails1.SelectedPersonInfo;
        }

        public void LoadData(int PersonID)
        {
            gbFilter.Enabled = false;
            ctrlPersonDetails1.LoadData(PersonID);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson Form = new frmAddEditPerson(-1);
            Form.DataBack += ctrlPersonDetailsWithFilter_DataBack;
            Form.ShowDialog();
        }

        private void ctrlPersonDetailsWithFilter_DataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;
            txtbFilter.Clear();
            cbFilter.SelectedIndex = 0;
            txtbFilter.Text = PersonID.ToString();
            ctrlPersonDetails1.LoadData(PersonID);
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbFilter.Text.Trim()))
            {
                if(cbFilter.Text == "Person ID")
                {
                    _PersonID = Convert.ToInt32(txtbFilter.Text.Trim());
                    if (clsPerson.IsPersonExistByID(_PersonID))
                    {
                        ctrlPersonDetails1.LoadData(_PersonID);
                    } else
                    {
                        MessageBox.Show("No person with Person ID = " + _PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    _NationalNo = txtbFilter.Text.Trim();
                    if (clsPerson.IsPersonExistByNationalNo(_NationalNo))
                    {
                        ctrlPersonDetails1.LoadData(_NationalNo);
                    }
                    else
                    {
                        MessageBox.Show("No person with National No. = " + _NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            } else
            {
                MessageBox.Show("You must enter a specific Person ID or National No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
