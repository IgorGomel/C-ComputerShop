namespace BaseShopGadgets
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripMainForm = new System.Windows.Forms.ToolStrip();
            this.BtnNewDelivery = new System.Windows.Forms.ToolStripButton();
            this.BtnGoods = new System.Windows.Forms.ToolStripButton();
            this.BtnStorages = new System.Windows.Forms.ToolStripButton();
            this.BtnProviders = new System.Windows.Forms.ToolStripButton();
            this.BtnVipClients = new System.Windows.Forms.ToolStripButton();
            this.BtnDiscounts = new System.Windows.Forms.ToolStripButton();
            this.BtnNewSale = new System.Windows.Forms.ToolStripButton();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfGoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxSearchByStorage = new System.Windows.Forms.ComboBox();
            this.storagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet1 = new BaseShopGadgets.ModelBaseShopDataSet1();
            this.textBoxSearchGoods = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisplayBase = new System.Windows.Forms.Button();
            this.comboBoxSearchByCategory = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.storagesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.StoragesTableAdapter();
            this.categoriesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter();
            this.toolStripMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMainForm
            // 
            this.toolStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNewDelivery,
            this.BtnGoods,
            this.BtnStorages,
            this.BtnProviders,
            this.BtnVipClients,
            this.BtnDiscounts,
            this.BtnNewSale});
            this.toolStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainForm.Name = "toolStripMainForm";
            this.toolStripMainForm.Size = new System.Drawing.Size(790, 25);
            this.toolStripMainForm.TabIndex = 0;
            this.toolStripMainForm.Text = "toolStrip1";
            this.toolStripMainForm.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMainForm_ItemClicked);
            // 
            // BtnNewDelivery
            // 
            this.BtnNewDelivery.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewDelivery.Image")));
            this.BtnNewDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNewDelivery.Name = "BtnNewDelivery";
            this.BtnNewDelivery.Size = new System.Drawing.Size(107, 22);
            this.BtnNewDelivery.Text = "Нова поставка";
            this.BtnNewDelivery.Click += new System.EventHandler(this.BtnNewDelivery_Click);
            // 
            // BtnGoods
            // 
            this.BtnGoods.Image = ((System.Drawing.Image)(resources.GetObject("BtnGoods.Image")));
            this.BtnGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGoods.Name = "BtnGoods";
            this.BtnGoods.Size = new System.Drawing.Size(67, 22);
            this.BtnGoods.Text = "Товари";
            this.BtnGoods.Click += new System.EventHandler(this.BtnGoods_Click);
            // 
            // BtnStorages
            // 
            this.BtnStorages.Image = ((System.Drawing.Image)(resources.GetObject("BtnStorages.Image")));
            this.BtnStorages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStorages.Name = "BtnStorages";
            this.BtnStorages.Size = new System.Drawing.Size(67, 22);
            this.BtnStorages.Text = "Склади";
            this.BtnStorages.Click += new System.EventHandler(this.BtnStorages_Click);
            // 
            // BtnProviders
            // 
            this.BtnProviders.Image = ((System.Drawing.Image)(resources.GetObject("BtnProviders.Image")));
            this.BtnProviders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProviders.Name = "BtnProviders";
            this.BtnProviders.Size = new System.Drawing.Size(113, 22);
            this.BtnProviders.Text = "Постачальники";
            this.BtnProviders.Click += new System.EventHandler(this.BtnProviders_Click);
            // 
            // BtnVipClients
            // 
            this.BtnVipClients.Image = ((System.Drawing.Image)(resources.GetObject("BtnVipClients.Image")));
            this.BtnVipClients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnVipClients.Name = "BtnVipClients";
            this.BtnVipClients.Size = new System.Drawing.Size(90, 22);
            this.BtnVipClients.Text = "VIP-клієнти";
            this.BtnVipClients.Click += new System.EventHandler(this.BtnVipClients_Click);
            // 
            // BtnDiscounts
            // 
            this.BtnDiscounts.Image = ((System.Drawing.Image)(resources.GetObject("BtnDiscounts.Image")));
            this.BtnDiscounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDiscounts.Name = "BtnDiscounts";
            this.BtnDiscounts.Size = new System.Drawing.Size(70, 22);
            this.BtnDiscounts.Text = "Знижки";
            this.BtnDiscounts.Click += new System.EventHandler(this.BtnDiscounts_Click);
            // 
            // BtnNewSale
            // 
            this.BtnNewSale.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewSale.Image")));
            this.BtnNewSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNewSale.Name = "BtnNewSale";
            this.BtnNewSale.Size = new System.Drawing.Size(123, 22);
            this.BtnNewSale.Text = "Реалізація товару";
            this.BtnNewSale.Click += new System.EventHandler(this.BtnNewSale_Click);
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowUserToAddRows = false;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameOfGoods,
            this.Categor,
            this.Store,
            this.Descript,
            this.Amount,
            this.Price});
            this.MainDataGridView.Location = new System.Drawing.Point(12, 28);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.Size = new System.Drawing.Size(776, 317);
            this.MainDataGridView.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 30;
            // 
            // NameOfGoods
            // 
            this.NameOfGoods.HeaderText = "Назва товару";
            this.NameOfGoods.Name = "NameOfGoods";
            this.NameOfGoods.Width = 150;
            // 
            // Categor
            // 
            this.Categor.HeaderText = "Категорія";
            this.Categor.Name = "Categor";
            // 
            // Store
            // 
            this.Store.HeaderText = "Склад";
            this.Store.Name = "Store";
            // 
            // Descript
            // 
            this.Descript.HeaderText = "Опис";
            this.Descript.Name = "Descript";
            this.Descript.Width = 150;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Кількість";
            this.Amount.Name = "Amount";
            // 
            // Price
            // 
            this.Price.HeaderText = "Ціна";
            this.Price.Name = "Price";
            // 
            // comboBoxSearchByStorage
            // 
            this.comboBoxSearchByStorage.DataSource = this.storagesBindingSource;
            this.comboBoxSearchByStorage.DisplayMember = "Name";
            this.comboBoxSearchByStorage.FormattingEnabled = true;
            this.comboBoxSearchByStorage.Location = new System.Drawing.Point(131, 13);
            this.comboBoxSearchByStorage.Name = "comboBoxSearchByStorage";
            this.comboBoxSearchByStorage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearchByStorage.TabIndex = 2;
            this.comboBoxSearchByStorage.ValueMember = "Id";
            this.comboBoxSearchByStorage.TextChanged += new System.EventHandler(this.comboBoxSearchByStorage_TextChanged);
            // 
            // storagesBindingSource
            // 
            this.storagesBindingSource.DataMember = "Storages";
            this.storagesBindingSource.DataSource = this.modelBaseShopDataSet1;
            // 
            // modelBaseShopDataSet1
            // 
            this.modelBaseShopDataSet1.DataSetName = "ModelBaseShopDataSet1";
            this.modelBaseShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxSearchGoods
            // 
            this.textBoxSearchGoods.Location = new System.Drawing.Point(337, 357);
            this.textBoxSearchGoods.Name = "textBoxSearchGoods";
            this.textBoxSearchGoods.Size = new System.Drawing.Size(137, 20);
            this.textBoxSearchGoods.TabIndex = 3;
            this.textBoxSearchGoods.TextChanged += new System.EventHandler(this.textBoxSearchGoods_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пошук товару";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пошук по складах";
            // 
            // btnDisplayBase
            // 
            this.btnDisplayBase.Location = new System.Drawing.Point(525, 357);
            this.btnDisplayBase.Name = "btnDisplayBase";
            this.btnDisplayBase.Size = new System.Drawing.Size(109, 23);
            this.btnDisplayBase.TabIndex = 6;
            this.btnDisplayBase.Text = "Відобразити базу";
            this.btnDisplayBase.UseVisualStyleBackColor = true;
            this.btnDisplayBase.Click += new System.EventHandler(this.btnDisplayBase_Click);
            // 
            // comboBoxSearchByCategory
            // 
            this.comboBoxSearchByCategory.DataSource = this.categoriesBindingSource;
            this.comboBoxSearchByCategory.DisplayMember = "Name";
            this.comboBoxSearchByCategory.FormattingEnabled = true;
            this.comboBoxSearchByCategory.Location = new System.Drawing.Point(131, 40);
            this.comboBoxSearchByCategory.Name = "comboBoxSearchByCategory";
            this.comboBoxSearchByCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearchByCategory.TabIndex = 7;
            this.comboBoxSearchByCategory.ValueMember = "Id";
            this.comboBoxSearchByCategory.TextChanged += new System.EventHandler(this.comboBoxSearchByCategory_TextChanged);
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.modelBaseShopDataSet1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пошук по категоріях";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSearchByCategory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxSearchByStorage);
            this.groupBox1.Location = new System.Drawing.Point(480, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 67);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерії пошуку";
            // 
            // storagesTableAdapter
            // 
            this.storagesTableAdapter.ClearBeforeFill = true;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDisplayBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearchGoods);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.toolStripMainForm);
            this.Name = "Form1";
            this.Text = "Список товарів";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripMainForm.ResumeLayout(false);
            this.toolStripMainForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMainForm;
        private System.Windows.Forms.ToolStripButton BtnNewDelivery;
        public System.Windows.Forms.ToolStripButton BtnGoods;
        private System.Windows.Forms.ToolStripButton BtnStorages;
        private System.Windows.Forms.ToolStripButton BtnProviders;
        public  System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.ToolStripButton BtnVipClients;
        private System.Windows.Forms.ToolStripButton BtnDiscounts;
        private System.Windows.Forms.ComboBox comboBoxSearchByStorage;
        private System.Windows.Forms.TextBox textBoxSearchGoods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDisplayBase;
        private System.Windows.Forms.ComboBox comboBoxSearchByCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton BtnNewSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfGoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descript;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private ModelBaseShopDataSet1 modelBaseShopDataSet1;
        private System.Windows.Forms.BindingSource storagesBindingSource;
        private ModelBaseShopDataSet1TableAdapters.StoragesTableAdapter storagesTableAdapter;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
    }
}

