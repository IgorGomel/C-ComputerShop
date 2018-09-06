namespace BaseShopGadgets
{
    partial class FormGoodsChange
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
            this.textBoxNameCh = new System.Windows.Forms.TextBox();
            this.comboBoxCategoryCh = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelBaseShopDataSet1 = new BaseShopGadgets.ModelBaseShopDataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPriceCh = new System.Windows.Forms.TextBox();
            this.textBoxDescriptCh = new System.Windows.Forms.TextBox();
            this.btnChangeGoods = new System.Windows.Forms.Button();
            this.btnCloseCh = new System.Windows.Forms.Button();
            this.categoriesTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNameCh
            // 
            this.textBoxNameCh.Location = new System.Drawing.Point(97, 12);
            this.textBoxNameCh.Name = "textBoxNameCh";
            this.textBoxNameCh.Size = new System.Drawing.Size(175, 20);
            this.textBoxNameCh.TabIndex = 0;
            // 
            // comboBoxCategoryCh
            // 
            this.comboBoxCategoryCh.DataSource = this.categoriesBindingSource;
            this.comboBoxCategoryCh.DisplayMember = "Name";
            this.comboBoxCategoryCh.FormattingEnabled = true;
            this.comboBoxCategoryCh.Location = new System.Drawing.Point(97, 45);
            this.comboBoxCategoryCh.Name = "comboBoxCategoryCh";
            this.comboBoxCategoryCh.Size = new System.Drawing.Size(175, 21);
            this.comboBoxCategoryCh.TabIndex = 1;
            this.comboBoxCategoryCh.ValueMember = "Name";
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.modelBaseShopDataSet1;
            // 
            // modelBaseShopDataSet1
            // 
            this.modelBaseShopDataSet1.DataSetName = "ModelBaseShopDataSet1";
            this.modelBaseShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Назва";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Категорія";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ціна";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Опис";
            // 
            // textBoxPriceCh
            // 
            this.textBoxPriceCh.Location = new System.Drawing.Point(202, 84);
            this.textBoxPriceCh.Name = "textBoxPriceCh";
            this.textBoxPriceCh.Size = new System.Drawing.Size(70, 20);
            this.textBoxPriceCh.TabIndex = 6;
            // 
            // textBoxDescriptCh
            // 
            this.textBoxDescriptCh.Location = new System.Drawing.Point(97, 117);
            this.textBoxDescriptCh.Multiline = true;
            this.textBoxDescriptCh.Name = "textBoxDescriptCh";
            this.textBoxDescriptCh.Size = new System.Drawing.Size(175, 139);
            this.textBoxDescriptCh.TabIndex = 7;
            // 
            // btnChangeGoods
            // 
            this.btnChangeGoods.Location = new System.Drawing.Point(97, 274);
            this.btnChangeGoods.Name = "btnChangeGoods";
            this.btnChangeGoods.Size = new System.Drawing.Size(75, 23);
            this.btnChangeGoods.TabIndex = 8;
            this.btnChangeGoods.Text = "Змінити";
            this.btnChangeGoods.UseVisualStyleBackColor = true;
            this.btnChangeGoods.Click += new System.EventHandler(this.btnChangeGoods_Click);
            // 
            // btnCloseCh
            // 
            this.btnCloseCh.Location = new System.Drawing.Point(197, 274);
            this.btnCloseCh.Name = "btnCloseCh";
            this.btnCloseCh.Size = new System.Drawing.Size(75, 23);
            this.btnCloseCh.TabIndex = 9;
            this.btnCloseCh.Text = "Закрити";
            this.btnCloseCh.UseVisualStyleBackColor = true;
            this.btnCloseCh.Click += new System.EventHandler(this.btnCloseCh_Click);
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // FormGoodsChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 319);
            this.Controls.Add(this.btnCloseCh);
            this.Controls.Add(this.btnChangeGoods);
            this.Controls.Add(this.textBoxDescriptCh);
            this.Controls.Add(this.textBoxPriceCh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCategoryCh);
            this.Controls.Add(this.textBoxNameCh);
            this.Name = "FormGoodsChange";
            this.Text = "Змінити";
            this.Load += new System.EventHandler(this.FormGoodsChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxNameCh;
        public System.Windows.Forms.ComboBox comboBoxCategoryCh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxPriceCh;
        public System.Windows.Forms.TextBox textBoxDescriptCh;
        private System.Windows.Forms.Button btnChangeGoods;
        private System.Windows.Forms.Button btnCloseCh;
        private ModelBaseShopDataSet1 modelBaseShopDataSet1;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private ModelBaseShopDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
    }
}