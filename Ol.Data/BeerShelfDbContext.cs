using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerShelf.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BeerShelf.Data
{
    public class BeerShelfDbContext : DbContext
    {
        public BeerShelfDbContext()
            : base(nameOrConnectionString: "BeerShelfDb") { }

        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<User> Users { get; set; }

        static BeerShelfDbContext()
        {
            Database.SetInitializer(new BeerShelfDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
