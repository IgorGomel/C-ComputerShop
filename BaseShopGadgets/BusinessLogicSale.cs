using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseShopGadgets
{
    public  class BusinessLogicSale
    {
        public event Action AddSaleToBaseAssortment;
        public event Action AddSaleToRepozitoryAssortment;
        public event Action AddSaleToDataGridViewMain;
        public event Action AddSaleToDataGridViewArchiv;
        public event Action AddSaleToBaseSalesArchiv;

        public event Action DeleteSaleFromBaseSalesArchiv;
        public event Action DeleteSaleFromBaseSalesAssortment;
        public event Action DeleteSaleFromRepozitoryAssortment;
        public event Action DeleteSaleFromDataGridViewArchiv;
        public event Action DeleteSaleFromDataGridViewMain;


        public event Action ChangeSaleInBaseAssortment;
        public event Action ChangeSaleInBaseSalesArchiv;
        public event Action ChangeSaleInRepozitoryAssortment;
        public event Action ChangeSaleInDataGridViewMain;
        public event Action ChangeSaleInDataGridViewArchiv;

        public void AddSale()
        {
            if (AddSaleToBaseAssortment != null)
                AddSaleToBaseAssortment();
            if (AddSaleToBaseSalesArchiv != null)
                AddSaleToBaseSalesArchiv();
            if (AddSaleToDataGridViewMain != null)
                AddSaleToDataGridViewMain();
            if (AddSaleToDataGridViewArchiv != null)
                AddSaleToDataGridViewArchiv();
            if (AddSaleToRepozitoryAssortment != null)
                AddSaleToRepozitoryAssortment();
        }

        public void DeleteSale()
        {
            if (Form1.formSale.dataGridViewSales.CurrentRow.ReadOnly == false)
            {
                if (DeleteSaleFromBaseSalesAssortment != null)
                    DeleteSaleFromBaseSalesAssortment();
                if (DeleteSaleFromBaseSalesArchiv != null)
                    DeleteSaleFromBaseSalesArchiv();

                if (DeleteSaleFromRepozitoryAssortment != null)
                    DeleteSaleFromRepozitoryAssortment();

                if (DeleteSaleFromDataGridViewArchiv != null)
                    DeleteSaleFromDataGridViewArchiv();
                if (DeleteSaleFromDataGridViewMain != null)
                    DeleteSaleFromDataGridViewMain();
            }
            else
                MessageBox.Show("Дозволяється видаляти записи, які створені не більше 36 годин тому!");
            
        }

        public void ChangeSale()
        {
            if (Form1.formSale.dataGridViewSales.CurrentRow.ReadOnly == false)
            {
                if (ChangeSaleInBaseAssortment != null)
                    ChangeSaleInBaseAssortment();
                if (ChangeSaleInBaseSalesArchiv != null)
                    ChangeSaleInBaseSalesArchiv();

                if (ChangeSaleInRepozitoryAssortment != null)
                    ChangeSaleInRepozitoryAssortment();

                if (ChangeSaleInDataGridViewArchiv != null)
                    ChangeSaleInDataGridViewArchiv();
                if (ChangeSaleInDataGridViewMain != null)
                    ChangeSaleInDataGridViewMain();
            }
            else
                MessageBox.Show("Дозволяється змінювати записи, які створені не більше 36 годин тому!");
        }
    }
}
