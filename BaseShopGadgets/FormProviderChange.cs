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
    public partial class FormProviderChange : Form
    {
        Provider provider;
        int number;
        BusinessLogicProvider businessLogicProvider = new BusinessLogicProvider();

        public FormProviderChange()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.businessLogicProvider.ChangeProvider();
        }

        public void _Change_Privider_In_Base()
        {
            number = Convert.ToInt32(Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[0].Value);
            provider = Form1.db.TableProviders.Where(o => o.Id == number).FirstOrDefault();
            provider.Name = Form1.formProviders.formProviderChange.textBoxNameCh.Text;
            provider.Address = Form1.formProviders.formProviderChange.textBoxAddressCh.Text;
            provider.Phone = Form1.formProviders.formProviderChange.textBoxPhoneCh.Text;

            Form1.db.SaveChanges();
        }

        public void _Change_Privider_In_DataGridView()
        {
            Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[2].Value = Form1.formProviders.formProviderChange.textBoxNameCh.Text;
            Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[3].Value = Form1.formProviders.formProviderChange.textBoxAddressCh.Text;
            Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[4].Value = Form1.formProviders.formProviderChange.textBoxPhoneCh.Text;
        }

        public void _Change_Privider_In_Repozitory()
        {
            var temp = Form1.tempRepozit.ListProviders.Where(d => d.Id == number).ToList();
            Provider tempProv = temp.Single();
            int indexEl = Form1.tempRepozit.ListProviders.IndexOf(tempProv);

            Form1.tempRepozit.ListProviders[indexEl].Name = Form1.formProviders.formProviderChange.textBoxNameCh.Text;
            Form1.tempRepozit.ListProviders[indexEl].Address = Form1.formProviders.formProviderChange.textBoxAddressCh.Text;
            Form1.tempRepozit.ListProviders[indexEl].Phone = Form1.formProviders.formProviderChange.textBoxPhoneCh.Text;
        }

        private void FormProviderChange_Load(object sender, EventArgs e)
        {
            this.businessLogicProvider.ChangeProviderInBase += _Change_Privider_In_Base;
            this.businessLogicProvider.ChangeProviderInDataGridView += _Change_Privider_In_DataGridView;
            this.businessLogicProvider.ChangeProviderInRepozitory += _Change_Privider_In_Repozitory;

            this.textBoxNameCh.Text = Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[2].Value.ToString();
            this.textBoxAddressCh.Text = Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[3].Value.ToString();
            this.textBoxPhoneCh.Text = Form1.formProviders.dataGridViewProviders.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
