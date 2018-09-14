using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseShopGadgets
{
    static class Program
    {
        public static Form1 ff;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var context = new ModelBaseShop())
            //{
            //    var isAny = context.TableProviders.Any();
            //}
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ff = new Form1();
            //Application.Run( new Form1());
            Application.Run(ff);
            //Form1.formDelivery.busnLogicDelivery.AddDeliveryToBaseAssortment += Form1.formDelivery._Add_Delivery_To_Base_Assortment;

        }
    }
}
