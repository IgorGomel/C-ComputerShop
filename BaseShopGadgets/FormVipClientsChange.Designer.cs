namespace BaseShopGadgets
{
    partial class FormVipClientsChange
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
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBoxNameCh = new System.Windows.Forms.TextBox();
            this.textBoxLastNameCh = new System.Windows.Forms.TextBox();
            this.textBoxPassportCh = new System.Windows.Forms.TextBox();
            this.comboBoxDiscountCh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modelBaseShopDataSet1 = new BaseShopGadgets.ModelBaseShopDataSet1();
            this.discountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discountsTableAdapter = new BaseShopGadgets.ModelBaseShopDataSet1TableAdapters.DiscountsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(89, 167);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "Змінити";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(172, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBoxNameCh
            // 
            this.textBoxNameCh.Location = new System.Drawing.Point(89, 12);
            this.textBoxNameCh.Name = "textBoxNameCh";
            this.textBoxNameCh.Size = new System.Drawing.Size(158, 20);
            this.textBoxNameCh.TabIndex = 2;
            // 
            // textBoxLastNameCh
            // 
            this.textBoxLastNameCh.Location = new System.Drawing.Point(89, 47);
            this.textBoxLastNameCh.Name = "textBoxLastNameCh";
            this.textBoxLastNameCh.Size = new System.Drawing.Size(158, 20);
            this.textBoxLastNameCh.TabIndex = 3;
            // 
            // textBoxPassportCh
            // 
            this.textBoxPassportCh.Location = new System.Drawing.Point(89, 91);
            this.textBoxPassportCh.Name = "textBoxPassportCh";
            this.textBoxPassportCh.Size = new System.Drawing.Size(158, 20);
            this.textBoxPassportCh.TabIndex = 4;
            // 
            // comboBoxDiscountCh
            // 
            this.comboBoxDiscountCh.DataSource = this.discountsBindingSource;
            this.comboBoxDiscountCh.DisplayMember = "Name";
            this.comboBoxDiscountCh.FormattingEnabled = true;
            this.comboBoxDiscountCh.Location = new System.Drawing.Point(89, 131);
            this.comboBoxDiscountCh.Name = "comboBoxDiscountCh";
            this.comboBoxDiscountCh.Size = new System.Drawing.Size(158, 21);
            this.comboBoxDiscountCh.TabIndex = 5;
            this.comboBoxDiscountCh.ValueMember = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ім\'я";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Прізвище";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Паспорт";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Тип знижки";
            // 
            // modelBaseShopDataSet1
            // 
            this.modelBaseShopDataSet1.DataSetName = "ModelBaseShopDataSet1";
            this.modelBaseShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // discountsBindingSource
            // 
            this.discountsBindingSource.DataMember = "Discounts";
            this.discountsBindingSource.DataSource = this.modelBaseShopDataSet1;
            // 
            // discountsTableAdapter
            // 
            this.discountsTableAdapter.ClearBeforeFill = true;
            // 
            // FormVipClientsChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 195);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDiscountCh);
            this.Controls.Add(this.textBoxPassportCh);
            this.Controls.Add(this.textBoxLastNameCh);
            this.Controls.Add(this.textBoxNameCh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChange);
            this.Name = "FormVipClientsChange";
            this.Text = "Змінити дані Vip-клієнта";
            this.Load += new System.EventHandler(this.FormVipClientsChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelBaseShopDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBoxNameCh;
        private System.Windows.Forms.TextBox textBoxLastNameCh;
        private System.Windows.Forms.TextBox textBoxPassportCh;
        private System.Windows.Forms.ComboBox comboBoxDiscountCh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ModelBaseShopDataSet1 modelBaseShopDataSet1;
        private System.Windows.Forms.BindingSource discountsBindingSource;
        private ModelBaseShopDataSet1TableAdapters.DiscountsTableAdapter discountsTableAdapter;
    }
}