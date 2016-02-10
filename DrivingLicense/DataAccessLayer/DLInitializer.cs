using DrivingLicense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrivingLicense.DataAccessLayer
{
    public class DLInitializer : System.Data.Entity.DropCreateDatabaseAlways<DLContext>
    {
        protected override void Seed(DLContext context)
        {
            var candidates = new List<DLDetails>
            {
                new DLDetails{ DLNumber = "MH43 20090024412", Name="PRATEEK KHANNA", Address = "BALAJI GARDEN CHS, KOPARKHAIRANE, NAVI MUMBAI", BloodGroup = "A+", COV1 = "MCWG",
                 COV2="LMV", DateOfIssue= DateTime.Parse("2002-09-01"), DeptName="THE UNION OF INDIA", DOB=DateTime.Parse("2002-09-01"), FathersName="PANKAJ KHANNA", IssuingID="MH43 20090024412", Pin=400709, 
                 State="MAHARASHTRA STATE MOTOR DRIVNG LICENSE", ValidTill=DateTime.Parse("2002-09-01") },
                 new DLDetails{ DLNumber = "MH43 20090024413", Name="PRATEEK KHANNA", Address = "BALAJI GARDEN CHS, KOPARKHAIRANE, NAVI MUMBAI", BloodGroup = "A+", COV1 = "MCWG",
                 COV2="LMV", DateOfIssue= DateTime.Parse("2002-09-01"), DeptName="THE UNION OF INDIA", DOB=DateTime.Parse("2002-09-01"), FathersName="PANKAJ KHANNA", IssuingID="MH43 20090024412", Pin=400709, 
                 State="MAHARASHTRA STATE MOTOR DRIVNG LICENSE", ValidTill=DateTime.Parse("2002-09-01") }
            };

            candidates.ForEach(s => context.DLDetailss.Add(s));
            context.SaveChanges();
        }
    }
}