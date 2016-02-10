using DrivingLicense.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DrivingLicense.DataAccessLayer
{
    public class DLContext : DbContext
    {
        public DLContext()
            : base("DLContext")
        {
        }

        public DbSet<DLDetails> DLDetailss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}