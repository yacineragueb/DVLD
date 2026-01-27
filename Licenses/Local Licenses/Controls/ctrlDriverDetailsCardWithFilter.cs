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

namespace DVLD_project.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverDetailsCardWithFilter : UserControl
    {

        // Define a custom event handler delegate with paramaters
        public event Action<int> OnLicenseSelected;

        // Create a protecte method to raise the event with a paramater
        protected virtual void LicenseSelected(int licenseID)
        {
            Action<int> Handler = OnLicenseSelected;

            if(Handle != null)
            {
                Handler(licenseID); // Raise the event with a paramater
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDriverDetailsCard.SelectedLicenseInfo;
            }
        }

        public bool EnableFilter
        {
            set
            {
                gbFilter.Enabled = value;
            }
        }

        public ctrlDriverDetailsCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;
            ctrlDriverDetailsCard.LoadData(_LicenseID);
        }

        private void txtbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbFilter.Text.Trim()))
            {
                _LicenseID = Convert.ToInt32(txtbFilter.Text.Trim());
                if (clsLicense.IsLicenseExistByID(_LicenseID))
                {
                    ctrlDriverDetailsCard.LoadData(_LicenseID);
                    if(OnLicenseSelected != null)
                    {
                        // Raise the event with paramater
                        LicenseSelected(ctrlDriverDetailsCard.LicenseID);
                    }
                }
                else
                {
                    MessageBox.Show("No License with ID = " + _LicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must enter a specific License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
