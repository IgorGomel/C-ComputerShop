using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicProvider
    {
        public event Action AddProviderToBase;
        public event Action AddProviderToRepozitory;
        public event Action AddProviderToDataGridView;

        public event Action DeleteProviderFromBase;
        public event Action DeleteProviderFromRepozitory;
        public event Action DeleteProviderFromDataGridView;

        public event Action ChangeProviderInBase;
        public event Action ChangeProviderInRepozitory;
        public event Action ChangeProviderInDataGridView;

        public void AddProvider()
        {
            if (AddProviderToBase != null)
                AddProviderToBase();
            if (AddProviderToDataGridView != null)
                AddProviderToDataGridView();
            if (AddProviderToRepozitory != null)
                AddProviderToRepozitory();
        }

        public void DeleteProvider()
        {
            if (DeleteProviderFromBase != null)
                DeleteProviderFromBase();
            if (DeleteProviderFromDataGridView != null)
                DeleteProviderFromDataGridView();
            if (DeleteProviderFromRepozitory != null)
                DeleteProviderFromRepozitory();
        }

        public void ChangeProvider()
        {
            if (ChangeProviderInBase != null)
                ChangeProviderInBase();
            if (ChangeProviderInRepozitory != null)
                ChangeProviderInRepozitory();
            if (ChangeProviderInDataGridView != null)
                ChangeProviderInDataGridView();
        }
    }
}
