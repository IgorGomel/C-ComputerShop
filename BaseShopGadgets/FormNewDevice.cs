using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseShopGadgets
{
    public partial class FormNewDevice : Form
    {
        IQueryable<Device> deviceIQuer;
        IQueryable<Category> categoryIQuer;
        Category category;
        int Max;
        //public Device device;
        //public Form1 myForm1 = new Form1();
        BusinessLogicDevice busnLogicDevice = new BusinessLogicDevice();

        public FormNewDevice()
        {
            
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            this.busnLogicDevice.AddDevice();

            textBoxName.Clear();
            //textBoxCategory.Clear();
            textBoxPrice.Clear();
            textBoxDescript.Clear();
        }

        //обробщик добавлення девайсу до бази даних
        public void _Add_Divice_To_Base()
        {
            deviceIQuer = Form1.db.TableDevices;
            categoryIQuer = Form1.db.TableCategoryes;
            bool hasElements = deviceIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Devices");

            var tempCateg = categoryIQuer.Where(d =>string.Equals(d.Name, comboBoxCategory.Text));
            category = tempCateg.Single();

            Form1.db.TableDevices.Add(new Device()
                {
                    Name = textBoxName.Text,
                    IdCategory = category.Id, 
                    Price = Double.Parse(textBoxPrice.Text),
                    Descript = textBoxDescript.Text
                }
                    );
            Form1.db.SaveChanges();
        }

        //обробщик добавлення девайсу до DataGridView форми FormGoods
        public void _Add_Device_To_DataGridView_FormGoods()
        {
            //deviceIQuer = Form1.db.TableDevices;
            Max = deviceIQuer.Max(d => d.Id);

            Form1.formGoods.dataGridViewGoods.Rows.Add(Form1.formGoods.dataGridViewGoods.Rows.Count+1, Max, textBoxName.Text, comboBoxCategory.SelectedValue, textBoxDescript.Text, textBoxPrice.Text);    
        }

        //обробщик добавлення девайсу до репозиторія
        public void _Add_Device_To_Repozitory()
        {
            Form1.tempRepozit.ListDevices.Add(new Device()
            {
                Id = Max,
                Name = textBoxName.Text,
                IdCategory = category.Id,
                Price = Double.Parse(textBoxPrice.Text),
                Descript = textBoxDescript.Text
            });
        }


        
        private void FormNewDevice_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            this.busnLogicDevice.AddDeviceToBase += _Add_Divice_To_Base;
            this.busnLogicDevice.AddDeviceToDataGridView += _Add_Device_To_DataGridView_FormGoods;
            this.busnLogicDevice.AddDeviceToRepozitory += _Add_Device_To_Repozitory;
        }
    }
}
