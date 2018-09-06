using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicDiscount
    {
        public event Action AddDiscountToBase;
        public event Action AddDiscountToRepozitory;
        public event Action AddDiscountToDataGridView;

        public event Action DeleteDiscountFromBase;
        public event Action DeleteDiscountFromRepozitory;
        public event Action DeleteDiscountFromDataGridView;

        public event Action ChangeDiscountInBase;
        public event Action ChangeDiscountInRepozitory;
        public event Action ChangeDiscountInDataGridView;

        public void AddDiscount()
        {
            if (AddDiscountToBase != null)
                AddDiscountToBase();
            if (AddDiscountToDataGridView != null)
                AddDiscountToDataGridView();
            if (AddDiscountToRepozitory != null)
                AddDiscountToRepozitory();
        }


        public void DeleteDiscount()
        {
            if (DeleteDiscountFromBase != null)
                DeleteDiscountFromBase();
            if (DeleteDiscountFromDataGridView != null)
                DeleteDiscountFromDataGridView();
            if (DeleteDiscountFromRepozitory != null)
                DeleteDiscountFromRepozitory();
        }

        public void ChangeDiscount()
        {
            if (ChangeDiscountInBase != null)
                ChangeDiscountInBase();
            if (ChangeDiscountInDataGridView != null)
                ChangeDiscountInDataGridView();
            if (ChangeDiscountInRepozitory != null)
                ChangeDiscountInRepozitory();
        }
    }
}
