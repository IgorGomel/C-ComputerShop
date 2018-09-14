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
    public partial class FormNewProvider : Form
    {
        IQueryable<Provider> providerIQuer;
        int Max;
        BusinessLogicProvider businessLogicProvider = new BusinessLogicProvider();

        public FormNewProvider()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.businessLogicProvider.AddProvider();

            this.textBoxName.Clear();
            this.textBoxAddress.Clear();
            this.textBoxPhone.Clear();
        }

        public void _Add_Provider_To_Base()
        {
            providerIQuer = Form1.db.TableProviders;
            bool hasElements = providerIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Providers");

            Form1.db.TableProviders.Add(new Provider()
            {
                Name = textBoxName.Text,
                Address = textBoxAddress.Text,
                Phone = textBoxPhone.Text
            }
                    );
            Form1.db.SaveChanges();
        }

        public void _Add_Provider_To_DataGridView()
        {
            Max = providerIQuer.Max(d => d.Id);

            Form1.formProviders.dataGridViewProviders.Rows.Add(Max, Form1.formProviders.dataGridViewProviders.Rows.Count+1, textBoxName.Text, textBoxAddress.Text, textBoxPhone.Text);
        }

        public void _Add_Provider_To_Repozitory()
        {
            Form1.tempRepozit.ListProviders.Add(new Provider()
            {
                Id = Max,
                Name = textBoxName.Text,
                Address = textBoxAddress.Text,
                Phone = textBoxPhone.Text
            });
        }

        private void FormNewProvider_Load(object sender, EventArgs e)
        {
            this.businessLogicProvider.AddProviderToBase += _Add_Provider_To_Base;
            this.businessLogicProvider.AddProviderToDataGridView += _Add_Provider_To_DataGridView;
            this.businessLogicProvider.AddProviderToRepozitory += _Add_Provider_To_Repozitory;
        }
    }
}
