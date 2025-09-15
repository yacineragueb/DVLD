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
    public partial class ShowPersonDetails : Form
    {
        private int _PersonID;
        public ShowPersonDetails(int PersonID)
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
            personDetails1.LoadData(_PersonID);
        }
    }
}
