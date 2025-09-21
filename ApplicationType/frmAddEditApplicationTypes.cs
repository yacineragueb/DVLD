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

namespace DVLD_project.ApplicationType
{
    public partial class frmAddEditApplicationTypes : Form
    {
        private clsApplicationTypes _ApplicationType;

        private int _ApplicationTypeID;

        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        private enMode _Mode = enMode.AddNew;

        public frmAddEditApplicationTypes( int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;

            if(_ApplicationTypeID == -1)
            {
                _Mode = enMode.AddNew;
            } else
            {
                _Mode = enMode.Edit;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void _ResetDefaultValues()
        {
            txtbFee.Clear();
            txtbTitle.Clear();
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("This form will be closed because No Application Type with ID = " + _ApplicationTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtbTitle.Text = _ApplicationType.Title;
            txtbFee.Text = _ApplicationType.Fee.ToString();
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Edit)
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.Title = txtbTitle.Text.Trim();
            _ApplicationType.Fee = Convert.ToDecimal(txtbFee.Text.Trim());

            if(_ApplicationType.Save())
            {
                _Mode = enMode.Edit;

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTitle, "Title is required");
            } else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbTitle, "");
            }
        }

        private void txtbFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbFee.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTitle, "Fee is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbTitle, "");
            }
        }
    }
}
