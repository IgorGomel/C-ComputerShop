namespace BaseShopGadgets
{
    partial class FormDelivery
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.devicesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet = new BaseShopGadgets.ModelBaseShopDataSet();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.storagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.devicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.providersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.devicesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSetTableAdapters.DevicesTableAdapter();
            this.storagesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSetTableAdapters.StoragesTableAdapter();
            this.providersTableAdapter = new BaseShopGadgets.ModelBaseShopDataSetTableAdapters.ProvidersTableAdapter();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet1 = new BaseShopGadgets.ModelBaseShopDataSet1();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGoods = new System.Windows.Forms.TextBox();
            this.devicesBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.devicesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.devicesTableAdapter1 = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.DevicesTableAdapter();
            this.categoriesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGrViewDeliveryArchiv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Providerr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storagge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Describe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrViewDeliveryArchiv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва товару";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Склад";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Постачальник";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Кількість";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ціна(1шт)";
            // 
            // devicesBindingSource1
            // 
            this.devicesBindingSource1.DataMember = "Devices";
            this.devicesBindingSource1.DataSource = this.modelBaseShopDataSet;
            // 
            // modelBaseShopDataSet
            // 
            this.modelBaseShopDataSet.DataSetName = "ModelBaseShopDataSet";
            this.modelBaseShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.DataSource = this.storagesBindingSource;
            this.comboBoxStorage.DisplayMember = "Name";
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(109, 79);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(149, 21);
            this.comboBoxStorage.TabIndex = 6;
            this.comboBoxStorage.ValueMember = "Id";
            this.comboBoxStorage.SelectedIndexChanged += new System.EventHandler(this.comboBoxStorage_SelectedIndexChanged);
            // 
            // storagesBindingSource
            // 
            this.storagesBindingSource.DataMember = "Storages";
            this.storagesBindingSource.DataSource = this.modelBaseShopDataSet;
            // 
            // devicesBindingSource
            // 
            this.devicesBindingSource.DataMember = "Devices";
            this.devicesBindingSource.DataSource = this.modelBaseShopDataSet;
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.DataSource = this.providersBindingSource;
            this.comboBoxProvider.DisplayMember = "Name";
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Location = new System.Drawing.Point(109, 106);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(149, 21);
            this.comboBoxProvider.TabIndex = 7;
            this.comboBoxProvider.ValueMember = "Id";
            this.comboBoxProvider.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvider_SelectedIndexChanged);
            // 
            // providersBindingSource
            // 
            this.providersBindingSource.DataMember = "Providers";
            this.providersBindingSource.DataSource = this.modelBaseShopDataSet;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(183, 220);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // devicesTableAdapter
            // 
            this.devicesTableAdapter.ClearBeforeFill = true;
            // 
            // storagesTableAdapter
            // 
            this.storagesTableAdapter.ClearBeforeFill = true;
            // 
            // providersTableAdapter
            // 
            this.providersTableAdapter.ClearBeforeFill = true;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(183, 133);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownAmount.TabIndex = 12;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Location = new System.Drawing.Point(183, 159);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownPrice.TabIndex = 13;
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(103, 185);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(155, 20);
            this.dateTimePickerDelivery.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Дата";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DataSource = this.categoriesBindingSource1;
            this.comboBoxCategory.DisplayMember = "Name";
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(110, 21);
            this.comboBoxCategory.MaxDropDownItems = 100;
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(148, 21);
            this.comboBoxCategory.TabIndex = 17;
            this.comboBoxCategory.ValueMember = "Name";
            // 
            // categoriesBindingSource1
            // 
            this.categoriesBindingSource1.DataMember = "Categories";
            this.categoriesBindingSource1.DataSource = this.modelBaseShopDataSet1;
            // 
            // modelBaseShopDataSet1
            // 
            this.modelBaseShopDataSet1.DataSetName = "ModelBaseShopDataSet1";
            this.modelBaseShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.modelBaseShopDataSet1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Категорія товару";
            // 
            // textBoxGoods
            // 
            this.textBoxGoods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxGoods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGoods.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.devicesBindingSource3, "Name", true));
            this.textBoxGoods.Location = new System.Drawing.Point(110, 48);
            this.textBoxGoods.Name = "textBoxGoods";
            this.textBoxGoods.Size = new System.Drawing.Size(149, 20);
            this.textBoxGoods.TabIndex = 20;
            this.textBoxGoods.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // devicesBindingSource3
            // 
            this.devicesBindingSource3.DataMember = "Devices";
            this.devicesBindingSource3.DataSource = this.modelBaseShopDataSet1;
            // 
            // devicesBindingSource2
            // 
            this.devicesBindingSource2.DataMember = "Devices";
            this.devicesBindingSource2.DataSource = this.modelBaseShopDataSet1;
            // 
            // devicesTableAdapter1
            // 
            this.devicesTableAdapter1.ClearBeforeFill = true;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChange);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(16, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 85);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Редагування постачань";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(139, 19);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Змінити";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(28, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGrViewDeliveryArchiv);
            this.groupBox1.Location = new System.Drawing.Point(264, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 369);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список постачань";
            // 
            // dataGrViewDeliveryArchiv
            // 
            this.dataGrViewDeliveryArchiv.AllowUserToAddRows = false;
            this.dataGrViewDeliveryArchiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrViewDeliveryArchiv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.NameOfDevice,
            this.Providerr,
            this.Storagge,
            this.Describe,
            this.Amount,
            this.Price,
            this.Date,
            this.Category});
            this.dataGrViewDeliveryArchiv.Location = new System.Drawing.Point(6, 19);
            this.dataGrViewDeliveryArchiv.Name = "dataGrViewDeliveryArchiv";
            this.dataGrViewDeliveryArchiv.Size = new System.Drawing.Size(643, 344);
            this.dataGrViewDeliveryArchiv.TabIndex = 23;
            this.dataGrViewDeliveryArchiv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrViewDeliveryArchiv_RowEnter);
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
            // NameOfDevice
            // 
            this.NameOfDevice.HeaderText = "Назва товару";
            this.NameOfDevice.Name = "NameOfDevice";
            // 
            // Providerr
            // 
            this.Providerr.HeaderText = "Постачальник";
            this.Providerr.Name = "Providerr";
            // 
            // Storagge
            // 
            this.Storagge.HeaderText = "Склад";
            this.Storagge.Name = "Storagge";
            this.Storagge.Width = 60;
            // 
            // Describe
            // 
            this.Describe.HeaderText = "Опис";
            this.Describe.Name = "Describe";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Кількість";
            this.Amount.Name = "Amount";
            this.Amount.Width = 30;
            // 
            // Price
            // 
            this.Price.HeaderText = "Ціна";
            this.Price.Name = "Price";
            this.Price.Width = 30;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.Width = 150;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категорія";
            this.Category.Name = "Category";
            this.Category.Visible = false;
            // 
            // FormDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxGoods);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerDelivery);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.devicesBindingSource2, "Name", true));
            this.Name = "FormDelivery";
            this.Text = "Нове постачання";
            this.Load += new System.EventHandler(this.FormDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBindingSource2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrViewDeliveryArchiv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private ModelBaseShopDataSet modelBaseShopDataSet;
        private System.Windows.Forms.BindingSource devicesBindingSource;
        private ModelBaseShopDataSetTableAdapters.DevicesTableAdapter devicesTableAdapter;
        private System.Windows.Forms.BindingSource devicesBindingSource1;
        private System.Windows.Forms.BindingSource storagesBindingSource;
        private ModelBaseShopDataSetTableAdapters.StoragesTableAdapter storagesTableAdapter;
        private System.Windows.Forms.BindingSource providersBindingSource;
        private ModelBaseShopDataSetTableAdapters.ProvidersTableAdapter providersTableAdapter;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBoxGoods;
        private ModelBaseShopDataSet1 modelBaseShopDataSet1;
        private System.Windows.Forms.BindingSource devicesBindingSource2;
        private ModelBaseShopDataSet1TableAdapters.DevicesTableAdapter devicesTableAdapter1;
        private System.Windows.Forms.BindingSource devicesBindingSource3;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
       // private System.Windows.Forms.DataGridViewTextBoxColumn Id;
       // private System.Windows.Forms.DataGridViewTextBoxColumn N;
       // private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dataGrViewDeliveryArchiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Providerr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storagge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Describe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.BindingSource categoriesBindingSource1;
    }
}