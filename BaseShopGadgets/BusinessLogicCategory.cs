using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicCategory
    {
        public event Action AddCategoryToBase;
        public event Action AddCategoryToRepozitory;
        public event Action AddCategoryToDataGridView;

        public event Action DeleteCategoryFromBase;
        public event Action DeleteCategoryFromRepozitory;
        public event Action DeleteCategoryFromDataGridView;

        public event Action ChangeCategoryInBase;
        public event Action ChangeCategoryInRepozitory;
        public event Action ChangeCategoryInDataGridView;

        public void AddCategory()
        {
            if (AddCategoryToBase != null)
                AddCategoryToBase();
            if (AddCategoryToDataGridView != null)
                AddCategoryToDataGridView();
            if (AddCategoryToRepozitory != null)
                AddCategoryToRepozitory();
        }

        public void DeleteCategory()
        {
            if (DeleteCategoryFromBase != null)
                DeleteCategoryFromBase();
            if (DeleteCategoryFromRepozitory != null)
                DeleteCategoryFromRepozitory();
            if (DeleteCategoryFromDataGridView != null)
                DeleteCategoryFromDataGridView();
        }

        public void ChangeCategory()
        {
            if (ChangeCategoryInBase != null)
                ChangeCategoryInBase();
            if (ChangeCategoryInRepozitory != null)
                ChangeCategoryInRepozitory();
            if (ChangeCategoryInDataGridView != null)
                ChangeCategoryInDataGridView();
        }
    }
}
