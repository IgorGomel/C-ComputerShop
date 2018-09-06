using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseShopGadgets
{
    public class BusinessLogicDevice
    {
        public event Action AddDeviceToBase;
        public event Action AddDeviceToRepozitory;
        public event Action AddDeviceToDataGridView;

        public event Action DeleteDeviceFromBase;
        public event Action DeleteDeviceFromRepozitory;
        public event Action DeleteDeviceFromDataGridView;

        public event Action ChangeDeviceInBase;
        public event Action ChangeDeviceInRepozitory;
        public event Action ChangeDeviceInDataGridView;

        public void AddDevice()
        {
            if (AddDeviceToBase != null)
                AddDeviceToBase();
            if (AddDeviceToDataGridView != null)
                AddDeviceToDataGridView();
            if (AddDeviceToRepozitory != null)
                AddDeviceToRepozitory();
        }

        public void DeleteDevice()
        {
            if (DeleteDeviceFromBase != null)
                DeleteDeviceFromBase();
            if (DeleteDeviceFromRepozitory != null)
                DeleteDeviceFromRepozitory();
            if (DeleteDeviceFromDataGridView != null)
                DeleteDeviceFromDataGridView();
        }

        public void ChangeDevice()
        {
            if (ChangeDeviceInBase != null)
                ChangeDeviceInBase();
            if (ChangeDeviceInRepozitory != null)
                ChangeDeviceInRepozitory();
            if (ChangeDeviceInDataGridView != null)
                ChangeDeviceInDataGridView();
        }
    }
}
