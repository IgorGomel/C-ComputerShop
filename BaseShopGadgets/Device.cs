using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    //гаджет
    public class Device : IdEntity
    {
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public double Price { get; set; }
        public String Descript { get; set; }//опис
    }
}
