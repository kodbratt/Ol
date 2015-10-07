using BeerShelf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShelf.Data
{
    public class BeerShelfDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BeerShelfDbContext>
    {
        protected override void Seed(BeerShelfDbContext dbcontext)
        {
            var bottles = new List<Bottle>
            {
                new Bottle{Id=1,Name="American Pale Ale",Brand="Popples Bryggeri",Country="Sweden",Alcohol=5,Price=25},
                new Bottle{Id=1,Name="Kärlek Pale Ale",Brand="Mikkeller",Country="Danmark",Alcohol=4.5,Price=20},
                new Bottle{Id=1,Name="Single Hop Ale",Brand="Oppigårds",Country="Sweden",Alcohol=4.8,Price=25},
                new Bottle{Id=1,Name="Twisted Thistle Ipa",Brand="Belhaven Brewery",Country="Scotland",Alcohol=5.6,Price=25}
            };

            bottles.ForEach(b => dbcontext.Bottles.Add(b));
            dbcontext.SaveChanges();

        }
    }
}
