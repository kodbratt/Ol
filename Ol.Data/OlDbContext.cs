using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ol.Data
{
    public class OlDbContext : DbContext
    {
        public OlDbContext()
            : base(nameOrConnectionString: "OlDb") { }

        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<User> Users { get; set; }

        static OlDbContext()
        {
            Database.SetInitializer(new OlDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
