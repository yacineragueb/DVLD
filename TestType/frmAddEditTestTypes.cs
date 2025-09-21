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

namespace DVLD_project.TestType
{
    public partial class frmAddEditTestTypes : Form
    {
        private clsTestTypes _TestType;

        private int _TestTypeID;

        enum enMode
        {
            AddNew = 0,
            Edit = 1
        }

        private enMode _Mode = enMode.AddNew;
        public frmAddEditTestTypes(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;

            if(_TestTypeID == -1)
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
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

        private void LoadData()
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("This form will be closed because No Test Type with ID = " + _TestTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTestTypeID.Text = _TestTypeID.ToString();
            txtbTitle.Text = _TestType.Title;
            txtbDescription.Text = _TestType.Description;
            txtbFee.Text = _TestType.Fee.ToString();
        }

        private void frmAddEditTestTypes_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Edit)
            {
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!." + Environment.NewLine + "Put the mouse over the red icon to show what you miss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtbTitle.Text.Trim();
            _TestType.Description = txtbDescription.Text.Trim();
            _TestType.Fee = Convert.ToDecimal(txtbFee.Text.Trim());

            if (_TestType.Save())
            {
                _Mode = enMode.Edit;

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTitle, "Title is required");
            }
            else
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
                errorProvider1.SetError(txtbFee, "Fee is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbFee, "");
            }
        }

        private void txtbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbDescription, "Description is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbDescription, "");
            }
        }
    }
}
