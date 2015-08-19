using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ol.Model
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public double Alcohol { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
