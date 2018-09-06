using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicStorage
    {
        public event Action AddStorageToBase;
        public event Action AddStorageToRepozitory;
        public event Action AddStorageToDataGridView;

        public event Action DeleteStorageFromBase;
        public event Action DeleteStorageFromRepozitory;
        public event Action DeleteStorageFromDataGridView;

        public event Action ChangeStorageInBase;
        public event Action ChangeStorageInRepozitory;
        public event Action ChangeStorageInDataGridView;

        public void AddStorage()
        {
            if (AddStorageToBase != null)
                AddStorageToBase();
            if (AddStorageToDataGridView != null)
                AddStorageToDataGridView();
            if (AddStorageToRepozitory != null)
                AddStorageToRepozitory();
        }

        public void DeleteStorage()
        {
            if (DeleteStorageFromBase != null)
                DeleteStorageFromBase();
            if (DeleteStorageFromRepozitory != null)
                DeleteStorageFromRepozitory();
            if (DeleteStorageFromDataGridView != null)
                DeleteStorageFromDataGridView();
        }

        public void ChangeStorage()
        {
            if (ChangeStorageInBase != null)
                ChangeStorageInBase();
            if (ChangeStorageInRepozitory != null)
                ChangeStorageInRepozitory();
            if (ChangeStorageInDataGridView != null)
                ChangeStorageInDataGridView();
        }
    }
}
