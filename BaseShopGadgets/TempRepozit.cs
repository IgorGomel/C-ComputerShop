using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    //віртуальне хранилище обєктів
    public class TempRepozit<A, B, C, D, E, F, G, H, I>
    {
        public List<Device> ListDevices = new List<Device>();
        public List<Category> ListCaregoryes = new List<Category>();
        public List<Provider> ListProviders = new List<Provider>();
        public List<Storage> ListStorages = new List<Storage>();
        public List<VipClient> ListVipClients = new List<VipClient>();
        public List<Discount> ListDiscounts = new List<Discount>();
        public List<Assortment> ListAssortment = new List<Assortment>();
        public List<DeliveryesArchiv> ListDeliveryes = new List<DeliveryesArchiv>();
        public List<SalesArchiv> ListSales = new List<SalesArchiv>();
    }
}
