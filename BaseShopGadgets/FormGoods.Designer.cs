namespace BaseShopGadgets
{
    partial class FormGoods
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGoods));
            this.toolStripGoods = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnChange = new System.Windows.Forms.ToolStripButton();
            this.BtnCategoryes = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Describe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripGoods
            // 
            this.toolStripGoods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDelete,
            this.BtnChange,
            this.BtnCategoryes});
            this.toolStripGoods.Location = new System.Drawing.Point(0, 0);
            this.toolStripGoods.Name = "toolStripGoods";
            this.toolStripGoods.Size = new System.Drawing.Size(742, 25);
            this.toolStripGoods.TabIndex = 0;
            this.toolStripGoods.Text = "toolStrip1";
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
            // BtnCategoryes
            // 
            this.BtnCategoryes.Image = ((System.Drawing.Image)(resources.GetObject("BtnCategoryes.Image")));
            this.BtnCategoryes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCategoryes.Name = "BtnCategoryes";
            this.BtnCategoryes.Size = new System.Drawing.Size(119, 22);
            this.BtnCategoryes.Text = "Категорії товарів";
            this.BtnCategoryes.Click += new System.EventHandler(this.BtnCategoryes_Click);
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.Id,
            this.NameOfDevice,
            this.Category,
            this.Describe,
            this.Price});
            this.dataGridViewGoods.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.Size = new System.Drawing.Size(730, 332);
            this.dataGridViewGoods.TabIndex = 1;
            this.dataGridViewGoods.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGoods_RowEnter);
            // 
            // N
            // 
            this.N.HeaderText = "N";
            this.N.Name = "N";
            this.N.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 30;
            // 
            // NameOfDevice
            // 
            this.NameOfDevice.HeaderText = "Назва товару";
            this.NameOfDevice.Name = "NameOfDevice";
            this.NameOfDevice.Width = 200;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категорія";
            this.Category.Name = "Category";
            // 
            // Describe
            // 
            this.Describe.HeaderText = "Опис";
            this.Describe.Name = "Describe";
            this.Describe.Width = 300;
            // 
            // Price
            // 
            this.Price.HeaderText = "Ціна";
            this.Price.Name = "Price";
            this.Price.Width = 55;
            // 
            // FormGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 363);
            this.Controls.Add(this.dataGridViewGoods);
            this.Controls.Add(this.toolStripGoods);
            this.Name = "FormGoods";
            this.Text = "Товари";
            this.Load += new System.EventHandler(this.FormGoods_Load);
            this.toolStripGoods.ResumeLayout(false);
            this.toolStripGoods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripGoods;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripButton BtnChange;
        public  System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.ToolStripButton BtnCategoryes;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Describe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}