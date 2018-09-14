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
    public partial class FormProviders : Form
    {
        public FormProviderChange formProviderChange;
        IQueryable<Provider> providerIQuer;
        Provider provider;
        int number;
        public int row;
        BusinessLogicProvider businessLogicProvider = new BusinessLogicProvider();

        private ToolStrip toolStrip1;
        private ToolStripButton BtnDelete;
        private ToolStripButton BtnChange;
        public DataGridView dataGridViewProviders;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Phone;
        private ToolStripButton BtnAdd;

        public FormProviders()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProviders));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnChange = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewProviders = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDelete,
            this.BtnChange});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(66, 22);
            this.BtnAdd.Text = "Додати";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(79, 22);
            this.BtnDelete.Text = "Видалити";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.Image = ((System.Drawing.Image)(resources.GetObject("BtnChange.Image")));
            this.BtnChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(72, 22);
            this.BtnChange.Text = "Змінити";
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // dataGridViewProviders
            // 
            this.dataGridViewProviders.AllowUserToAddRows = false;
            this.dataGridViewProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProviders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.Name,
            this.Address,
            this.Phone});
            this.dataGridViewProviders.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewProviders.Name = "dataGridViewProviders";
            this.dataGridViewProviders.Size = new System.Drawing.Size(620, 270);
            this.dataGridViewProviders.TabIndex = 1;
            this.dataGridViewProviders.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProviders_RowEnter);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 30;
            // 
            // N
            // 
            this.N.HeaderText = "N";
            this.N.Name = "N";
            this.N.Width = 30;
            // 
            // Name
            // 
            this.Name.HeaderText = "Назва постачальника";
            this.Name.Name = "Name";
            this.Name.Width = 200;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адреса";
            this.Address.Name = "Address";
            this.Address.Width = 250;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Номер телефона";
            this.Phone.Name = "Phone";
            // 
            // FormProviders
            // 
            this.ClientSize = new System.Drawing.Size(633, 300);
            this.Controls.Add(this.dataGridViewProviders);
            this.Controls.Add(this.toolStrip1);
            //this.Name = "FormProviders";
            this.Text = "Постачальники";
            this.Load += new System.EventHandler(this.FormProviders_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormNewProvider formNewProvider = new FormNewProvider();
            formNewProvider.ShowDialog();
        }

        private void dataGridViewProviders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewProviders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.businessLogicProvider.DeleteProvider();
        }

        public void _Delete_Provider_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(this.dataGridViewProviders.Rows[row].Cells[0].Value);
            provider = Form1.db.TableProviders.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableProviders.Remove(provider);
            Form1.db.SaveChanges();
        }

        public void _Delete_Provider_From_DataGridView()
        {
            //видаляємо з датигрідвью поточний рядок
            number = this.dataGridViewProviders.CurrentRow.Index;
            this.dataGridViewProviders.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім... 
            if (this.dataGridViewProviders.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < this.dataGridViewProviders.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridViewProviders.Rows[i].Cells[1].Value) > number)
                        this.dataGridViewProviders.Rows[i].Cells[1].Value = Convert.ToInt32(this.dataGridViewProviders.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        public void _Delete_Provider_From_Repozitory()
        {
            //Form1.tempRepozit.ListProviders.RemoveAt(number);
            for (int i = 0; i < Form1.tempRepozit.ListProviders.Count; i++)
            {
                if (Form1.tempRepozit.ListProviders[i].Id == number)
                    Form1.tempRepozit.ListProviders.RemoveAt(i);
            }
        }

        private void FormProviders_Load(object sender, EventArgs e)
        {
            providerIQuer = Form1.db.TableProviders;

            foreach (Provider prov in providerIQuer)
                dataGridViewProviders.Rows.Add(prov.Id, dataGridViewProviders.RowCount+1, prov.Name, prov.Address, prov.Phone);

            foreach (Provider prov in providerIQuer)
            {
                Form1.tempRepozit.ListProviders.Add(new Provider()
                {
                    Id = prov.Id,
                    Name = prov.Name,
                    Address = prov.Address,
                    Phone = prov.Phone
                });
            }

            this.businessLogicProvider.DeleteProviderFromBase += _Delete_Provider_From_Base;
            this.businessLogicProvider.DeleteProviderFromDataGridView += _Delete_Provider_From_DataGridView;
            this.businessLogicProvider.DeleteProviderFromRepozitory += _Delete_Provider_From_Repozitory;
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            formProviderChange = new FormProviderChange();
            formProviderChange.Show();
        }
    }
}
