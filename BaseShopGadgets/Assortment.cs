using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
   public class Assortment : IdEntity
    {
        //public string Name { get; set; }
        public int IdDevice { get; set; }
        //public int IdProvider { get; set; }
        public int IdStorage { get; set; }
        public string Describe { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
