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
    public partial class FormNewVipClient : Form
    {
        IQueryable<VipClient> vipClientIQuer;
        IQueryable<Discount> discountIQuer;
        Discount discount;
        int Max;
        public BusinessLogicVipClient busnLogicVipClient = new BusinessLogicVipClient();

        public FormNewVipClient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.busnLogicVipClient.AddVipClient();

            this.textBoxName.Clear();
            this.textBoxLastName.Clear();
            this.textBoxPassport.Clear();
        }


        public void _Add_VipClient_To_Base()
        {
            vipClientIQuer = Form1.db.TableVipClients;
            discountIQuer = Form1.db.TableDiscounts;

            bool hasElements = vipClientIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.VipClients");

            var tempDiscount = discountIQuer.Where(d => string.Equals(d.Name, comboBoxDiscount.Text));
            discount = tempDiscount.Single();

            Form1.db.TableVipClients.Add(new VipClient()
            {
                Name = textBoxName.Text,
                LastName = textBoxLastName.Text,
                Passport = textBoxPassport.Text,
                IdDisk = discount.Id
            }
                );
            Form1.db.SaveChanges();
        }

        public void _Add_VipClient_To_Repository()
        {
            Form1.tempRepozit.ListVipClients.Add(new VipClient()
            {
                Id = Max,
                Name = textBoxName.Text,
                LastName = textBoxLastName.Text,
                Passport = textBoxPassport.Text,
                IdDisk = discount.Id
            }
                );
        }
        
        public void _Add_VipClient_To_DataGridView()
        {
            Max = vipClientIQuer.Max(d => d.Id);
            Form1.formVipClients.dataGridViewVipClients.Rows.Add(Max, Form1.formVipClients.dataGridViewVipClients.Rows.Count+1, textBoxName.Text, textBoxLastName.Text, textBoxPassport.Text, comboBoxDiscount.SelectedValue);
        }

        private void FormNewVipClient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Discounts". При необходимости она может быть перемещена или удалена.
            this.discountsTableAdapter.Fill(this.modelBaseShopDataSet.Discounts);

            this.busnLogicVipClient.AddVipClientToBase += _Add_VipClient_To_Base;
            this.busnLogicVipClient.AddVipClientToDataGridView += _Add_VipClient_To_DataGridView;
            this.busnLogicVipClient.AddVipClientToRepozitory += _Add_VipClient_To_Repository;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //tempComboDiscount = (int)comboBoxDiscount.SelectedValue;
        //}
    }
}
