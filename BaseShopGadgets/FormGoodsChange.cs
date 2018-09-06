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
    public partial class FormGoodsChange : Form
    {
        IQueryable<Category> categoryIQuer;
        Category category;

        Device device;
        int number;
        BusinessLogicDevice busnLogicDeviceCh = new BusinessLogicDevice();

        public FormGoodsChange()
        {
            InitializeComponent();
        }

        private void FormGoodsChange_Load(object sender, EventArgs e)
        {
            this.busnLogicDeviceCh.ChangeDeviceInBase += _Change_Device_In_Base;
            this.busnLogicDeviceCh.ChangeDeviceInRepozitory += _Change_Device_In_Repositiry;
            this.busnLogicDeviceCh.ChangeDeviceInDataGridView += _Change_Device_In_DataGridView;

            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            Form1.formGoods.formGoodsChange.textBoxNameCh.Text = Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[2].Value.ToString();
            Form1.formGoods.formGoodsChange.comboBoxCategoryCh.Text = Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[3].Value.ToString();
            Form1.formGoods.formGoodsChange.textBoxDescriptCh.Text = Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[4].Value.ToString();
            Form1.formGoods.formGoodsChange.textBoxPriceCh.Text = Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnChangeGoods_Click(object sender, EventArgs e)
        {
            this.busnLogicDeviceCh.ChangeDevice();


        }

        public void _Change_Device_In_Base()
        {
            number = Convert.ToInt32(Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[1].Value);
            device = Form1.db.TableDevices.Where(o => o.Id == number).FirstOrDefault();
            device.Name = Form1.formGoods.formGoodsChange.textBoxNameCh.Text;
            device.Descript = Form1.formGoods.formGoodsChange.textBoxDescriptCh.Text;
            device.Price = Convert.ToDouble(Form1.formGoods.formGoodsChange.textBoxPriceCh.Text);

            Form1.db.SaveChanges();
        }

        public void _Change_Device_In_DataGridView()
        {
            Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[2].Value = Form1.formGoods.formGoodsChange.textBoxNameCh.Text;
            Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[3].Value = Form1.formGoods.formGoodsChange.comboBoxCategoryCh.Text;
            Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[4].Value = Form1.formGoods.formGoodsChange.textBoxDescriptCh.Text;
            Form1.formGoods.dataGridViewGoods.CurrentRow.Cells[5].Value = Form1.formGoods.formGoodsChange.textBoxPriceCh.Text;
            

        }

        public void _Change_Device_In_Repositiry()
        {
            categoryIQuer = Form1.db.TableCategoryes;
            var tempCateg = categoryIQuer.Where(d => string.Equals(d.Id, comboBoxCategoryCh.Text));
            category = tempCateg.Single();

            Form1.tempRepozit.ListDevices[Form1.formGoods.row].Name = Form1.formGoods.formGoodsChange.textBoxNameCh.Text;
            Form1.tempRepozit.ListDevices[Form1.formGoods.row].IdCategory = category.Id;
            Form1.tempRepozit.ListDevices[Form1.formGoods.row].Descript = Form1.formGoods.formGoodsChange.textBoxDescriptCh.Text;
            Form1.tempRepozit.ListDevices[Form1.formGoods.row].Price = Convert.ToDouble(Form1.formGoods.formGoodsChange.textBoxPriceCh.Text);
        }

        private void btnCloseCh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
