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
    public partial class FormStorages : Form
    {
        public FormStorageChang formStorageChange;
        IQueryable<Storage> storageIQuer;
        Storage storage;
        public int row;
        int number;
        BusinessLogicStorage businessLogicStorage = new BusinessLogicStorage();

        private ToolStripButton BtnAdd;
        private ToolStripButton BtnDelete;
        private ToolStripButton BtnChange;
        public DataGridView dataGridViewStorages;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Address;
        private ToolStrip toolStrip1;

        public FormStorages()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStorages));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnChange = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(540, 25);
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
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.Name,
            this.Address});
            this.dataGridViewStorages.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.Size = new System.Drawing.Size(526, 203);
            this.dataGridViewStorages.TabIndex = 1;
            this.dataGridViewStorages.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStorages_RowEnter);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
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
            this.Name.HeaderText = "Назва склада";
            this.Name.Name = "Name";
            this.Name.Width = 200;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адреса місцезнаходження";
            this.Address.Name = "Address";
            this.Address.Width = 250;
            // 
            // FormStorages
            // 
            this.ClientSize = new System.Drawing.Size(540, 234);
            this.Controls.Add(this.dataGridViewStorages);
            this.Controls.Add(this.toolStrip1);
            //this.Name = "FormStorages";
            this.Text = "Склади";
            this.Load += new System.EventHandler(this.FormStorages_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormNewStorage formNewStorage = new FormNewStorage();
            formNewStorage.ShowDialog();
        }



        private void FormStorages_Load(object sender, EventArgs e)
        {
            storageIQuer = Form1.db.TableStorages;

            foreach (Storage stor in storageIQuer)
            {
                dataGridViewStorages.Rows.Add(stor.Id, dataGridViewStorages.RowCount, stor.Name, stor.Address);
            }

            this.businessLogicStorage.DeleteStorageFromBase += _Delete_Storage_From_Base;
            this.businessLogicStorage.DeleteStorageFromDataGridView += _Delete_Storage_From_DataGridView;
            this.businessLogicStorage.DeleteStorageFromRepozitory += _Delete_Storage_From_Repozitory;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.businessLogicStorage.DeleteStorage();
        }

        public void _Delete_Storage_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(this.dataGridViewStorages.Rows[row].Cells[1].Value);
            storage = Form1.db.TableStorages.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableStorages.Remove(storage);

            Form1.db.SaveChanges();
        }

        public void _Delete_Storage_From_DataGridView()
        {
            //видаляємо з датигрідвью поточний рядок
            number = this.dataGridViewStorages.CurrentRow.Index;
            this.dataGridViewStorages.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім... 
            if (this.dataGridViewStorages.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < this.dataGridViewStorages.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridViewStorages.Rows[i].Cells[1].Value) > number)
                        this.dataGridViewStorages.Rows[i].Cells[1].Value = Convert.ToInt32(this.dataGridViewStorages.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        public void _Delete_Storage_From_Repozitory()
        {
            Form1.tempRepozit.ListStorages.RemoveAt(number);
        }

        private void dataGridViewStorages_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewStorages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            formStorageChange = new FormStorageChang();
            formStorageChange.Show();
        }

       
    }
}
