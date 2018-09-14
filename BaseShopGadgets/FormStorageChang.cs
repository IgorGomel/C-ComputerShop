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
    public partial class FormStorageChang : Form
    {
        Storage storage;
        int number;
        BusinessLogicStorage busnLogicStorageCh = new BusinessLogicStorage();

        public FormStorageChang()
        {
            InitializeComponent();
        }

        private void btnCloseStorage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeStorage_Click(object sender, EventArgs e)
        {
            this.busnLogicStorageCh.ChangeStorage();
        }

        public void _Change_Storage_In_Base()
        {
            number = Convert.ToInt32(Form1.formStorages.dataGridViewStorages.CurrentRow.Cells[0].Value);
            storage = Form1.db.TableStorages.Where(o => o.Id == number).FirstOrDefault();
            storage.Name = Form1.formStorages.formStorageChange.textBoxNameCh.Text;
            storage.Address = Form1.formStorages.formStorageChange.textBoxAddressCh.Text;
            
            Form1.db.SaveChanges();
        }

        public void _Change_Storage_In_DataGridView()
        {
            Form1.formStorages.dataGridViewStorages.CurrentRow.Cells[2].Value = Form1.formStorages.formStorageChange.textBoxNameCh.Text;
            Form1.formStorages.dataGridViewStorages.CurrentRow.Cells[3].Value = Form1.formStorages.formStorageChange.textBoxAddressCh.Text;
        }

        public void _Change_Storage_In_Repozitory()
        {
            var temp = Form1.tempRepozit.ListStorages.Where(d => d.Id == number).ToList();
            Storage tempStore = temp.Single();
            int indexEl = Form1.tempRepozit.ListStorages.IndexOf(tempStore);

            Form1.tempRepozit.ListStorages[indexEl].Name = Form1.formStorages.formStorageChange.textBoxNameCh.Text;
            Form1.tempRepozit.ListStorages[indexEl].Address = Form1.formStorages.formStorageChange.textBoxAddressCh.Text;
        }

        private void FormStorageChang_Load(object sender, EventArgs e)
        {
            this.busnLogicStorageCh.ChangeStorageInBase += _Change_Storage_In_Base;
            this.busnLogicStorageCh.ChangeStorageInDataGridView += _Change_Storage_In_DataGridView;
            this.busnLogicStorageCh.ChangeStorageInRepozitory += _Change_Storage_In_Repozitory;

            Form1.formStorages.formStorageChange.textBoxNameCh.Text = Form1.formStorages.dataGridViewStorages.CurrentRow.Cells[2].Value.ToString();
            Form1.formStorages.formStorageChange.textBoxAddressCh.Text = Form1.formStorages.dataGridViewStorages.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
