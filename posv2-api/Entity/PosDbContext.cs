using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class PosDbContext : DbContext
    {
        public PosDbContext() : base("PosDbContext") { }

        // Masters
        public DbSet<MstTableGroup> MstTableGroups { get; set; }
        public DbSet<MstTable> MstTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}