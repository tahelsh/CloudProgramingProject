using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Flavors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image_URL { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
