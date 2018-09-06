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
    public partial class FormDiscounts : Form
    {
        IQueryable<Discount> discountIQuer;
        Discount discount;
        int number;
        int row;

        
        int Max;
        BusinessLogicDiscount busnLogicDiscount = new BusinessLogicDiscount();
        //Form1 myForm4 = new Form1();

        private ToolStripButton BtnAdd;
        private ToolStripButton BtnDelete;
        private ToolStripButton BtnChange;
        private DataGridView dataGridViewDiscounts;
        private TextBox textBoxName;
        private TextBox textBoxPercent;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Percent;
        private ToolStrip toolStripDiscounts;

        public FormDiscounts()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiscounts));
            this.toolStripDiscounts = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnChange = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewDiscounts = new System.Windows.Forms.DataGridView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDiscounts
            // 
            this.toolStripDiscounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDelete,
            this.BtnChange});
            this.toolStripDiscounts.Location = new System.Drawing.Point(0, 0);
            this.toolStripDiscounts.Name = "toolStripDiscounts";
            this.toolStripDiscounts.Size = new System.Drawing.Size(460, 25);
            this.toolStripDiscounts.TabIndex = 0;
            this.toolStripDiscounts.Text = "toolStrip1";
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
            // dataGridViewDiscounts
            // 
            this.dataGridViewDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.Name,
            this.Percent});
            this.dataGridViewDiscounts.Location = new System.Drawing.Point(219, 28);
            this.dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            this.dataGridViewDiscounts.Size = new System.Drawing.Size(238, 123);
            this.dataGridViewDiscounts.TabIndex = 1;
            this.dataGridViewDiscounts.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiscounts_RowEnter);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(113, 47);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(161, 80);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(52, 20);
            this.textBoxPercent.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Назва знижки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Відсоток знижки";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.Name.HeaderText = "Назва знижки";
            this.Name.Name = "Name";
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Відсоток знижки";
            this.Percent.Name = "Percent";
            this.Percent.Width = 60;
            // 
            // FormDiscounts
            // 
            this.ClientSize = new System.Drawing.Size(460, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPercent);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dataGridViewDiscounts);
            this.Controls.Add(this.toolStripDiscounts);
            //this.Name = "FormDiscounts";
            this.Text = "Знижки";
            this.Load += new System.EventHandler(this.FormDiscounts_Load);
            this.toolStripDiscounts.ResumeLayout(false);
            this.toolStripDiscounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.busnLogicDiscount.AddDiscount(); 
        }

        public void _Add_Discount_To_Base()
        {
            discountIQuer = Form1.db.TableDiscounts;
            bool hasElements = discountIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Discounts");

            Form1.db.TableDiscounts.Add(new Discount()
            {
                Name = textBoxName.Text,
                Percent = Int32.Parse(textBoxPercent.Text)
            }
                );
            Form1.db.SaveChanges();
        }

        public void _Add_Discount_To_Repository()
        {
            Form1.tempRepozit.ListDiscounts.Add(new Discount()
            {
                Id = Max,
                Name = textBoxName.Text,
                Percent = Int32.Parse(textBoxPercent.Text)
            }
                );
        }

        public void _Add_Discount_To_DataGridView()
        {
            Max = discountIQuer.Max(d => d.Id);

            this.dataGridViewDiscounts.Rows.Add(Max, this.dataGridViewDiscounts.Rows.Count, textBoxName.Text, textBoxPercent.Text);
        }

        private void FormDiscounts_Load(object sender, EventArgs e)
        {
            discountIQuer = Form1.db.TableDiscounts;

            foreach (Discount disc in discountIQuer)
                dataGridViewDiscounts.Rows.Add(disc.Id, dataGridViewDiscounts.RowCount, disc.Name, disc.Percent);


            this.busnLogicDiscount.AddDiscountToBase += _Add_Discount_To_Base;
            this.busnLogicDiscount.AddDiscountToRepozitory += _Add_Discount_To_Repository;
            this.busnLogicDiscount.AddDiscountToDataGridView += _Add_Discount_To_DataGridView;

            this.busnLogicDiscount.DeleteDiscountFromBase += _Delete_Discount_From_Base;
            this.busnLogicDiscount.DeleteDiscountFromDataGridView += _Delete_Discount_From_DataGridView;
            this.busnLogicDiscount.DeleteDiscountFromRepozitory += _Delete_Discount_From_Repozitory;

            this.busnLogicDiscount.ChangeDiscountInBase += _Change_Discount_In_Base;
            this.busnLogicDiscount.ChangeDiscountInDataGridView += _Change_Discount_In_DataGridView;
            this.busnLogicDiscount.ChangeDiscountInRepozitory += _Change_Discount_In_Repozitory;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.busnLogicDiscount.DeleteDiscount();
        }

        public void _Delete_Discount_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(this.dataGridViewDiscounts.Rows[row].Cells[1].Value);
            discount = Form1.db.TableDiscounts.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableDiscounts.Remove(discount);
            Form1.db.SaveChanges();
        }

        public void _Delete_Discount_From_DataGridView()
        {
            //видаляємо з датигрідвью поточний рядок
            number = this.dataGridViewDiscounts.CurrentRow.Index;
            this.dataGridViewDiscounts.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім... 
            if (this.dataGridViewDiscounts.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < this.dataGridViewDiscounts.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridViewDiscounts.Rows[i].Cells[1].Value) > number)
                        this.dataGridViewDiscounts.Rows[i].Cells[1].Value = Convert.ToInt32(this.dataGridViewDiscounts.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        public void _Delete_Discount_From_Repozitory()
        {
            Form1.tempRepozit.ListDiscounts.RemoveAt(number - 1);
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            this.busnLogicDiscount.ChangeDiscount();
        }

        public void _Change_Discount_In_Base()
        {
            number = Convert.ToInt32(this.dataGridViewDiscounts.CurrentRow.Cells[0].Value);
            discount = Form1.db.TableDiscounts.Where(o => o.Id == number).FirstOrDefault();
            discount.Name = this.textBoxName.Text;
            discount.Percent = Convert.ToInt32(this.textBoxPercent.Text);

            Form1.db.SaveChanges();
        }

        public void _Change_Discount_In_DataGridView()
        {
            this.dataGridViewDiscounts.CurrentRow.Cells[2].Value = this.textBoxName.Text;
            this.dataGridViewDiscounts.CurrentRow.Cells[3].Value = this.textBoxPercent.Text;
        }

        public void _Change_Discount_In_Repozitory()
        {
            Form1.tempRepozit.ListDiscounts[Form1.formDiscounts.row].Name = this.textBoxName.Text;
            Form1.tempRepozit.ListDiscounts[Form1.formDiscounts.row].Percent = Convert.ToInt32(this.textBoxPercent.Text);
        }

        private void dataGridViewDiscounts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;

            this.textBoxName.Text = this.dataGridViewDiscounts.Rows[row].Cells[2].Value.ToString();
            this.textBoxPercent.Text = this.dataGridViewDiscounts.Rows[row].Cells[3].Value.ToString();
        }
    }
}
