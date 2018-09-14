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
    public partial class FormGoods : Form
    {
        IQueryable<Device> deviceIQuer;
        IQueryable<Category> categoryIQuer;
        FormNewDevice newFormNewDevice;
        public FormGoodsChange formGoodsChange;
        Device device;
        Category category;
        public int row;
        int number;
        BusinessLogicDevice busnLogicDevice = new BusinessLogicDevice();
        public static FormCategoryes newFormCategoryes;

        public FormGoods()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            newFormNewDevice = new FormNewDevice();
            newFormNewDevice.ShowDialog();
        }

        private void FormGoods_Load(object sender, EventArgs e)
        {
            categoryIQuer = Form1.db.TableCategoryes;
            deviceIQuer = Form1.db.TableDevices;

            //int a = deviceIQuer.Count<Device>();
            //string b = Convert.ToString(a);
            //MessageBox.Show(b);

            foreach (Device dev in deviceIQuer)
            {
                //на кожній ітерації циклу відбираєсо запис з таблиці Categoryes, Id якого відповідає полю IdCategory
                //...чергового елемента dev
                var categTemp = categoryIQuer.Where(d => d.Id == dev.IdCategory).ToList();
                category = categTemp.Single();

                dataGridViewGoods.Rows.Add(dataGridViewGoods.RowCount+1, dev.Id, dev.Name, category.Name, dev.Descript, dev.Price);
            }



            foreach (Device dev in deviceIQuer)
            {
                //var devTemp = deviceIQuer.Where(d => d.Id == dev.Id).ToList();
                //device = devTemp.Single();
                var categTemp = categoryIQuer.Where(d => d.Id == dev.IdCategory).ToList();
                category = categTemp.Single();

                Form1.tempRepozit.ListDevices.Add(new Device()
                {
                    Id = dev.Id,
                    Name = dev.Name,
                    IdCategory = category.Id,//Convert.ToInt32(comboBoxCategory.SelectedIndex + 1),
                    Price = dev.Price,
                    Descript = dev.Descript
                });
            }

            this.busnLogicDevice.DeleteDeviceFromBase += _Delete_Device_From_Base;
            this.busnLogicDevice.DeleteDeviceFromDataGridView += _Delete_Device_From_DataGridView;
            this.busnLogicDevice.DeleteDeviceFromRepozitory += _Delete_Device_From_Repository;


        }

        private void BtnCategoryes_Click(object sender, EventArgs e)
        {
            newFormCategoryes = new FormCategoryes();
            newFormCategoryes.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.busnLogicDevice.DeleteDevice();
        }

        public void _Delete_Device_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(this.dataGridViewGoods.Rows[row].Cells[1].Value);
            device = Form1.db.TableDevices.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableDevices.Remove(device);
            Form1.db.SaveChanges();
        }

        public void _Delete_Device_From_DataGridView()
        {
            //видаляємо з датигрідвью поточний рядок
            number = this.dataGridViewGoods.CurrentRow.Index;
            this.dataGridViewGoods.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім...
            if (this.dataGridViewGoods.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < this.dataGridViewGoods.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridViewGoods.Rows[i].Cells[0].Value) > number)
                        this.dataGridViewGoods.Rows[i].Cells[0].Value = Convert.ToInt32(this.dataGridViewGoods.Rows[i].Cells[0].Value) - 1;
                }
            }
        }

        public void _Delete_Device_From_Repository()
        {
            for (int i = 0; i < Form1.tempRepozit.ListDevices.Count; i++)
            {
                if (Form1.tempRepozit.ListDevices[i].Id == number)
                    Form1.tempRepozit.ListDevices.RemoveAt(i);
            }
            //Form1.tempRepozit.ListDevices.RemoveAt(row);
        }

       
        private void dataGridViewGoods_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewGoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;    
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            formGoodsChange = new FormGoodsChange();
            formGoodsChange.Show();

        //    this.formGoodsChange.textBoxNameCh.Text = this.dataGridViewGoods.CurrentRow.Cells[1].Value.ToString();
        //    this.formGoodsChange.comboBoxCategoryCh.Text = this.dataGridViewGoods.CurrentRow.Cells[2].Value.ToString();
        //    this.formGoodsChange.textBoxPriceCh.Text = this.dataGridViewGoods.CurrentRow.Cells[3].Value.ToString();
        //    this.formGoodsChange.textBoxDescriptCh.Text = this.dataGridViewGoods.CurrentRow.Cells[4].Value.ToString();
        }
    }
    
}
