using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseShopGadgets
{
    public class BusinessLogicDelivery
    {
        public event Action LoadFormDeliviry;

        public event Action AddDeliveryToBaseAssortment;
        public event Action AddDeliveryToRepozitoryAssortment;
        public event Action AddDeliveryToBaseDeliveryesArchiv;
        public event Action AddDeliveryToDataGridViewMain;
        public event Action AddDeliveryToDataGridViewArchiv;


        public event Action DeleteDeliveryFromBaseDeliveryesArchiv;
        public event Action DeleteDeliveryFromBaseAssortment;
        public event Action DeleteDeliveryFromRepozitoryAssortment;
        public event Action DeleteDeliveryFromDataGridViewArchiv;
        public event Action DeleteDeliveryFromDataGridViewMain;

        public event Action ChangeDeliveryInBaseAssortment;
        public event Action ChangeDeliveryInBaseDeliveryesArchiv;
        public event Action ChangeDeliveryInRepozitoryAssortment;
        public event Action ChangeDeliveryInDataGridViewArchiv;
        public event Action ChangeDeliveryInDataGridViewMain;




        public void AddDelivery()
        {
            if (AddDeliveryToBaseAssortment != null)
                AddDeliveryToBaseAssortment();
            if (AddDeliveryToBaseDeliveryesArchiv != null)
                AddDeliveryToBaseDeliveryesArchiv();
            if (AddDeliveryToDataGridViewMain != null)
                AddDeliveryToDataGridViewMain();
            if (AddDeliveryToDataGridViewArchiv != null)
                AddDeliveryToDataGridViewArchiv();
            if (AddDeliveryToRepozitoryAssortment != null)
                AddDeliveryToRepozitoryAssortment();
         }

        public void DeleteDelivery()
        {
            if (Form1.formDelivery.dataGrViewDeliveryArchiv.CurrentRow.ReadOnly == false)
            {
                if (DeleteDeliveryFromBaseDeliveryesArchiv != null)
                    DeleteDeliveryFromBaseDeliveryesArchiv();
                if (DeleteDeliveryFromBaseAssortment != null)
                    DeleteDeliveryFromBaseAssortment();


                if (DeleteDeliveryFromRepozitoryAssortment != null)
                    DeleteDeliveryFromRepozitoryAssortment();

                if (DeleteDeliveryFromDataGridViewArchiv != null)
                    DeleteDeliveryFromDataGridViewArchiv();
                if (DeleteDeliveryFromDataGridViewMain != null)
                    DeleteDeliveryFromDataGridViewMain();
            }
            else
                MessageBox.Show("Дозволяється видаляти записи, які створені не більше 36 годин тому!");
        }


        public void ChangeDelivery()
        {
            if (Form1.formDelivery.dataGrViewDeliveryArchiv.CurrentRow.ReadOnly == false)
            {
                if (ChangeDeliveryInBaseDeliveryesArchiv != null)
                    ChangeDeliveryInBaseDeliveryesArchiv();
                if (ChangeDeliveryInBaseAssortment != null)
                    ChangeDeliveryInBaseAssortment();


                if (ChangeDeliveryInRepozitoryAssortment != null)
                    ChangeDeliveryInRepozitoryAssortment();

                if (ChangeDeliveryInDataGridViewArchiv != null)
                    ChangeDeliveryInDataGridViewArchiv();
                if (ChangeDeliveryInDataGridViewMain != null)
                    ChangeDeliveryInDataGridViewMain();
            }
            else
                MessageBox.Show("Дозволяється змінювати записи, які створені не більше 36 годин тому!");
        }
    }
}
