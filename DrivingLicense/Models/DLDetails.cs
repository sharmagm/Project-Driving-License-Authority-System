using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrivingLicense.Models
{
    public class DLDetails
    {
        [Key]
        public string DLNumber { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string Address { get; set; }
        public int Pin { get; set; }
        public string BloodGroup { get; set; }
        public DateTime DOB { get; set; }
        public string DeptName { get; set; }
        public string State { get; set; }
        public string IssuingID { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidTill { get; set; }
        public string COV1 { get; set; }
        public string COV2 { get; set; }
    }
}