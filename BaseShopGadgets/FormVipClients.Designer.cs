namespace BaseShopGadgets
{
    partial class FormVipClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVipClients));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnChange = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewVipClients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVipClients)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(450, 25);
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
            // dataGridViewVipClients
            // 
            this.dataGridViewVipClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVipClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.N,
            this.Name,
            this.LastName,
            this.Passport,
            this.Discont});
            this.dataGridViewVipClients.Location = new System.Drawing.Point(13, 29);
            this.dataGridViewVipClients.Name = "dataGridViewVipClients";
            this.dataGridViewVipClients.Size = new System.Drawing.Size(437, 232);
            this.dataGridViewVipClients.TabIndex = 1;
            this.dataGridViewVipClients.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVipClients_RowEnter);
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
            this.Name.HeaderText = "Ім\'я";
            this.Name.Name = "Name";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Прізвище";
            this.LastName.Name = "LastName";
            // 
            // Passport
            // 
            this.Passport.HeaderText = "Паспорт";
            this.Passport.Name = "Passport";
            // 
            // Discont
            // 
            this.Discont.HeaderText = "Знижка";
            this.Discont.Name = "Discont";
            this.Discont.Width = 60;
            // 
            // FormVipClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 262);
            this.Controls.Add(this.dataGridViewVipClients);
            this.Controls.Add(this.toolStrip1);
            //this.Name = "FormVipClients";
            this.Text = "VIP-клієнти";
            this.Load += new System.EventHandler(this.FormVipClients_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVipClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripButton BtnChange;
        public System.Windows.Forms.DataGridView dataGridViewVipClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discont;
    }
}