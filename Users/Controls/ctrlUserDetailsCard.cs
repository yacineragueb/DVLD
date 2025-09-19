using ContactsBusinessLayer;
using DVLD_project.Properties;
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
using static DVLDBusinessLayer.clsPerson;

namespace DVLD_project.Users.Controls
{
    public partial class ctrlUserDetailsCard : UserControl
    {
        private clsUser _User;

        private int _UserID = -1;

        public ctrlUserDetailsCard()
        {
            InitializeComponent();
        }

        public void LoadData(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User != null)
            {
                _UserID = _User.UserID;
                lblUserID.Text = _User.UserID.ToString();
                lblUsername.Text = _User.UserName;
                lblIsActive.Text = _User.IsActive ? "Yes" : "No";
                ctrlPersonDetails1.LoadData(_User.PersonID);
            }
            else
            {
                MessageBox.Show("Person with ID = " + _UserID + " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
