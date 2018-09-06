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
    public partial class FormVipClients : Form
    {
        public FormVipClientsChange formVipClientsChange;
        FormNewVipClient formNewVipClient;
        IQueryable<VipClient> vipClientIQuer;
        IQueryable<Discount> discountIQuer;
        VipClient vipClient;
        Discount discount;
        int number;
        public int row;
        BusinessLogicVipClient businessLogicVipClient = new BusinessLogicVipClient();

        public FormVipClients()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            formNewVipClient = new FormNewVipClient();
            formNewVipClient.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.businessLogicVipClient.DeleteVipClient();
        }

        public void _Delete_VipClients_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(this.dataGridViewVipClients.Rows[row].Cells[0].Value);
            vipClient = Form1.db.TableVipClients.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableVipClients.Remove(vipClient);
            Form1.db.SaveChanges();
        }

        public void _Delete_VipClients_From_DataGridView()
        {
            //видаляємо з датигрідвью поточний рядок
            number = this.dataGridViewVipClients.CurrentRow.Index;
            this.dataGridViewVipClients.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім... 
            if (this.dataGridViewVipClients.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < this.dataGridViewVipClients.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridViewVipClients.Rows[i].Cells[1].Value) > number)
                        this.dataGridViewVipClients.Rows[i].Cells[1].Value = Convert.ToInt32(this.dataGridViewVipClients.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        public void _Delete_VipClients_From_Repozitory()
        {
            Form1.tempRepozit.ListVipClients.RemoveAt(number);
        }

        private void dataGridViewVipClients_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewVipClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            formVipClientsChange = new FormVipClientsChange();
            formVipClientsChange.Show();
        }

        private void FormVipClients_Load(object sender, EventArgs e)
        {
            vipClientIQuer = Form1.db.TableVipClients;
            discountIQuer = Form1.db.TableDiscounts;

            foreach (VipClient vipClt in vipClientIQuer)
            {
                var discountTemp = discountIQuer.Where(d => d.Id == vipClt.IdDisk).ToList();
                discount = discountTemp.Single();

                dataGridViewVipClients.Rows.Add(vipClt.Id, dataGridViewVipClients.RowCount, vipClt.Name, vipClt.LastName, vipClt.Passport, discount.Percent);
            }

            this.businessLogicVipClient.DeleteVipClientFromBase += _Delete_VipClients_From_Base;
            this.businessLogicVipClient.DeleteVipClientFromDataGridView += _Delete_VipClients_From_DataGridView;
            this.businessLogicVipClient.DeleteVipClientFromRepozitory += _Delete_VipClients_From_Repozitory;
        }
    }
}
