using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    //знижка
    public class Discount : IdEntity
    {
        public string Name { get; set; }
        public int Percent { get; set; }
    }
}
