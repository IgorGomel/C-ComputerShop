using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicVipClient
    {
        public event Action AddVipClientToBase;
        public event Action AddVipClientToRepozitory;
        public event Action AddVipClientToDataGridView;

        public event Action DeleteVipClientFromBase;
        public event Action DeleteVipClientFromRepozitory;
        public event Action DeleteVipClientFromDataGridView;

        public event Action ChangeVipClientInBase;
        public event Action ChangeVipClientInRepozitory;
        public event Action ChangeVipClientInDataGridView;

        public void AddVipClient()
        {
            if (AddVipClientToBase != null)
                AddVipClientToBase();
            if (AddVipClientToDataGridView != null)
                AddVipClientToDataGridView();
            if (AddVipClientToRepozitory != null)
                AddVipClientToRepozitory();
        }

        public void DeleteVipClient()
        {
            if (DeleteVipClientFromBase != null)
                DeleteVipClientFromBase();
            if (DeleteVipClientFromDataGridView != null)
                DeleteVipClientFromDataGridView();
            if (DeleteVipClientFromRepozitory != null)
                DeleteVipClientFromRepozitory();
        }

        public void ChangeVipClient()
        {
            if (ChangeVipClientInBase != null)
                ChangeVipClientInBase();
            if (ChangeVipClientInDataGridView != null)
                ChangeVipClientInDataGridView();
            if (ChangeVipClientInRepozitory != null)
                ChangeVipClientInRepozitory();
        }
    }
}
