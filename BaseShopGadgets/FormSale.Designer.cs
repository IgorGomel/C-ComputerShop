namespace BaseShopGadgets
{
    partial class FormSale
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
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet1 = new BaseShopGadgets.ModelBaseShopDataSet1();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.storagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet = new BaseShopGadgets.ModelBaseShopDataSet();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerSale = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxGoods = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.modelBaseShopDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter();
            this.storagesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSetTableAdapters.StoragesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DataSource = this.categoriesBindingSource;
            this.comboBoxCategory.DisplayMember = "Name";
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(58, 12);
            this.comboBoxCategory.MaxDropDownItems = 100;
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(146, 21);
            this.comboBoxCategory.TabIndex = 0;
            this.comboBoxCategory.ValueMember = "Name";
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            this.comboBoxCategory.SelectedValueChanged += new System.EventHandler(this.comboBoxCategory_SelectedValueChanged);
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.modelBaseShopDataSet1BindingSource;
            // 
            // modelBaseShopDataSet1BindingSource
            // 
            this.modelBaseShopDataSet1BindingSource.DataSource = this.modelBaseShopDataSet1;
            this.modelBaseShopDataSet1BindingSource.Position = 0;
            // 
            // modelBaseShopDataSet1
            // 
            this.modelBaseShopDataSet1.DataSetName = "ModelBaseShopDataSet1";
            this.modelBaseShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.DataSource = this.storagesBindingSource;
            this.comboBoxStorage.DisplayMember = "Name";
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(57, 65);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(147, 21);
            this.comboBoxStorage.TabIndex = 1;
            this.comboBoxStorage.ValueMember = "Id";
            // 
            // storagesBindingSource
            // 
            this.storagesBindingSource.DataMember = "Storages";
            this.storagesBindingSource.DataSource = this.modelBaseShopDataSetBindingSource1;
            // 
            // modelBaseShopDataSetBindingSource1
            // 
            this.modelBaseShopDataSetBindingSource1.DataSource = this.modelBaseShopDataSet;
            this.modelBaseShopDataSetBindingSource1.Position = 0;
            // 
            // modelBaseShopDataSet
            // 
            this.modelBaseShopDataSet.DataSetName = "ModelBaseShopDataSet";
            this.modelBaseShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(159, 102);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownAmount.TabIndex = 2;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Location = new System.Drawing.Point(159, 128);
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownPrice.TabIndex = 3;
            // 
            // dateTimePickerSale
            // 
            this.dateTimePickerSale.Location = new System.Drawing.Point(58, 163);
            this.dateTimePickerSale.Name = "dateTimePickerSale";
            this.dateTimePickerSale.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerSale.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Категорія";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Склад";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Кількість";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ціна";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата";
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(7, 198);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(109, 23);
            this.btnSale.TabIndex = 10;
            this.btnSale.Text = "Здійснити продаж";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(128, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSales);
            this.groupBox1.Location = new System.Drawing.Point(209, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 365);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список продаж";
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.NameOfDevice,
            this.NameOfStorage,
            this.Descript,
            this.Amount,
            this.Price,
            this.Date,
            this.Category});
            this.dataGridViewSales.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.Size = new System.Drawing.Size(623, 335);
            this.dataGridViewSales.TabIndex = 0;
            this.dataGridViewSales.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSales_RowEnter);
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
            // NameOfStorage
            // 
            this.NameOfStorage.HeaderText = "Склад";
            this.NameOfStorage.Name = "NameOfStorage";
            // 
            // Descript
            // 
            this.Descript.HeaderText = "Опис";
            this.Descript.Name = "Descript";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Кількість";
            this.Amount.Name = "Amount";
            this.Amount.Width = 60;
            // 
            // Price
            // 
            this.Price.HeaderText = "Ціна";
            this.Price.Name = "Price";
            this.Price.Width = 60;
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
            // textBoxGoods
            // 
            this.textBoxGoods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxGoods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGoods.Location = new System.Drawing.Point(58, 39);
            this.textBoxGoods.Name = "textBoxGoods";
            this.textBoxGoods.Size = new System.Drawing.Size(146, 20);
            this.textBoxGoods.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Товар";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChange);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(7, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Редагування продажів";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(103, 30);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Змінити";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // modelBaseShopDataSetBindingSource
            // 
            this.modelBaseShopDataSetBindingSource.DataSource = this.modelBaseShopDataSet;
            this.modelBaseShopDataSetBindingSource.Position = 0;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // storagesTableAdapter
            // 
            this.storagesTableAdapter.ClearBeforeFill = true;
            // 
            // FormSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 379);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxGoods);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerSale);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.comboBoxCategory);
            this.Name = "FormSale";
            this.Text = "Новий продаж";
            this.Load += new System.EventHandler(this.FormSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.TextBox textBoxGoods;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descript;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.BindingSource modelBaseShopDataSet1BindingSource;
        private ModelBaseShopDataSet1 modelBaseShopDataSet1;
        private ModelBaseShopDataSet modelBaseShopDataSet;
        private System.Windows.Forms.BindingSource modelBaseShopDataSetBindingSource;
        private System.Windows.Forms.BindingSource modelBaseShopDataSetBindingSource1;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private System.Windows.Forms.BindingSource storagesBindingSource;
        private ModelBaseShopDataSetTableAdapters.StoragesTableAdapter storagesTableAdapter;
    }
}