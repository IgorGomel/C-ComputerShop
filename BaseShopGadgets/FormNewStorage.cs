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
    public partial class FormNewStorage : Form
    {
        IQueryable<Storage> storageIQuer;
        int Max;

        BusinessLogicStorage businessLogicStorage = new BusinessLogicStorage();

        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxAddress;
        private Button btnAdd;
        private Button btnClose;
        private Label label1;

        public FormNewStorage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва склада";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адреса місцезнаходження";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(125, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(212, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(125, 58);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(212, 20);
            this.textBoxAddress.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(170, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(262, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormNewStorage
            // 
            this.ClientSize = new System.Drawing.Size(349, 143);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNewStorage";
            this.Text = "Додати новий склад";
            this.Load += new System.EventHandler(this.FormNewStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.businessLogicStorage.AddStorage();

            this.textBoxName.Clear();
            this.textBoxAddress.Clear();
        }

        public void _Add_Storage_To_Base()
        {
            storageIQuer = Form1.db.TableStorages;
            bool hasElements = storageIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Storages");

            Form1.db.TableStorages.Add(new Storage()
            {
                Name = textBoxName.Text,
                Address = textBoxAddress.Text
            }
                    );
            Form1.db.SaveChanges();
        }

        public void _Add_Storage_To_DataGridView()
        {
            //IQueryable<Storage> storageIQuer = Form1.db.TableStorages;
            Max = storageIQuer.Max(d => d.Id);

            Form1.formStorages.dataGridViewStorages.Rows.Add(Max, Form1.formStorages.dataGridViewStorages.Rows.Count+1, textBoxName.Text, textBoxAddress.Text);
        }

        public void _Add_Storage_To_Repozitory()
        {
            Form1.tempRepozit.ListStorages.Add(new Storage()
            {
                Id = Max, 
                Name = textBoxName.Text,
                Address = textBoxAddress.Text
            });
        }

        private void FormNewStorage_Load(object sender, EventArgs e)
        {
            this.businessLogicStorage.AddStorageToBase += _Add_Storage_To_Base;
            this.businessLogicStorage.AddStorageToDataGridView += _Add_Storage_To_DataGridView;
            this.businessLogicStorage.AddStorageToRepozitory += _Add_Storage_To_Repozitory;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
