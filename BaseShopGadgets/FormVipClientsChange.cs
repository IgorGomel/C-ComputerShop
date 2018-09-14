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
    public partial class FormVipClientsChange : Form
    {
        IQueryable<Discount> discountIQuer;
        Discount discount;
        VipClient vipClient;
        int number;
        BusinessLogicVipClient businessLogicVipClient = new BusinessLogicVipClient();

        public FormVipClientsChange()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.businessLogicVipClient.ChangeVipClient();
        }

        public void _Change_VipClient_In_Base()
        {
            discountIQuer = Form1.db.TableDiscounts;
            var tempDiscount = discountIQuer.Where(d => string.Equals(d.Name, this.comboBoxDiscountCh.Text));
            discount = tempDiscount.Single();

            number = Convert.ToInt32(Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[0].Value);
            vipClient = Form1.db.TableVipClients.Where(o => o.Id == number).FirstOrDefault();
            vipClient.Name = Form1.formVipClients.formVipClientsChange.textBoxNameCh.Text;
            vipClient.LastName = Form1.formVipClients.formVipClientsChange.textBoxLastNameCh.Text;
            vipClient.Passport = Form1.formVipClients.formVipClientsChange.textBoxPassportCh.Text;
            vipClient.IdDisk = discount.Id;

            Form1.db.SaveChanges();
        }

        public void _Change_VipClient_In_DataGridView()
        {
            Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[2].Value = this.textBoxNameCh.Text;
            Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[3].Value = this.textBoxLastNameCh.Text;
            Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[4].Value = this.textBoxPassportCh.Text;
            Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[5].Value = this.comboBoxDiscountCh.SelectedValue;
        }

        public void _Change_VipClient_In_Repozitory()
        {
            var temp = Form1.tempRepozit.ListVipClients.Where(d => d.Id == number).ToList();
            VipClient tempVipClient = temp.Single();
            int indexEl = Form1.tempRepozit.ListVipClients.IndexOf(tempVipClient);

            Form1.tempRepozit.ListVipClients[indexEl].Name = this.textBoxNameCh.Text;
            Form1.tempRepozit.ListVipClients[indexEl].LastName = this.textBoxLastNameCh.Text;
            Form1.tempRepozit.ListVipClients[indexEl].Passport = this.textBoxPassportCh.Text;
            Form1.tempRepozit.ListVipClients[indexEl].IdDisk = discount.Id;
        }

        private void FormVipClientsChange_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Discounts". При необходимости она может быть перемещена или удалена.
            this.discountsTableAdapter.Fill(this.modelBaseShopDataSet1.Discounts);
            this.businessLogicVipClient.ChangeVipClientInBase += _Change_VipClient_In_Base;
            this.businessLogicVipClient.ChangeVipClientInDataGridView += _Change_VipClient_In_DataGridView;
            this.businessLogicVipClient.ChangeVipClientInRepozitory += _Change_VipClient_In_Repozitory;

            this.textBoxNameCh.Text = Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[2].Value.ToString();
            this.textBoxLastNameCh.Text = Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[3].Value.ToString();
            this.textBoxPassportCh.Text = Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[4].Value.ToString();
            this.comboBoxDiscountCh.Text = Form1.formVipClients.dataGridViewVipClients.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
