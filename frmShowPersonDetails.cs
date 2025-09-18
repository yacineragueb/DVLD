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
    public partial class frmShowPersonDetails : Form
    {
        private int _PersonID;
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPersonDetails_Load(object sender, EventArgs e)
        {
            if (clsPerson.IsPersonExistByID(_PersonID)) {
                personDetails1.LoadData(_PersonID);
            } else
            {
                this.Close();
            }
            
        }
    }
}
