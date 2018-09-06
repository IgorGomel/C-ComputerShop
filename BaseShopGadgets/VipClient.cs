using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class VipClient : IdEntity
    {
        public string Name { get; set; }//ім'я
        public string LastName { get; set; }//прізвище
        public string Passport { get; set; }//серія та номер паспорта
        public int IdDisk { get; set; }
    }
}
