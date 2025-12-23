using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLicense
    {
        public enum Mode { AddNew = 0, Update = 1 }

        public enum enIssueReason
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamage = 3,
            ReplacementForLost = 4
        }

        public Mode _Mode = Mode.AddNew;

        public int ApplicationID { get; set; }

        public clsApplication _Application;

        public clsLicenseClasses _LicenseClass;

        public int DriverID { get; set; }

        public int LicenseClassID { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive {  get; set; }

        enIssueReason IssueReason { get; set; }

        public int CreatedByUserId {  get; set; }
    }
}
