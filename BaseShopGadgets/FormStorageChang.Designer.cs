namespace BaseShopGadgets
{
    partial class FormStorageChang
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
            this.btnChangeStorage = new System.Windows.Forms.Button();
            this.btnCloseStorage = new System.Windows.Forms.Button();
            this.textBoxNameCh = new System.Windows.Forms.TextBox();
            this.textBoxAddressCh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangeStorage
            // 
            this.btnChangeStorage.Location = new System.Drawing.Point(75, 73);
            this.btnChangeStorage.Name = "btnChangeStorage";
            this.btnChangeStorage.Size = new System.Drawing.Size(75, 23);
            this.btnChangeStorage.TabIndex = 0;
            this.btnChangeStorage.Text = "Змінити";
            this.btnChangeStorage.UseVisualStyleBackColor = true;
            this.btnChangeStorage.Click += new System.EventHandler(this.btnChangeStorage_Click);
            // 
            // btnCloseStorage
            // 
            this.btnCloseStorage.Location = new System.Drawing.Point(178, 73);
            this.btnCloseStorage.Name = "btnCloseStorage";
            this.btnCloseStorage.Size = new System.Drawing.Size(75, 23);
            this.btnCloseStorage.TabIndex = 1;
            this.btnCloseStorage.Text = "Закрити";
            this.btnCloseStorage.UseVisualStyleBackColor = true;
            this.btnCloseStorage.Click += new System.EventHandler(this.btnCloseStorage_Click);
            // 
            // textBoxNameCh
            // 
            this.textBoxNameCh.Location = new System.Drawing.Point(75, 12);
            this.textBoxNameCh.Name = "textBoxNameCh";
            this.textBoxNameCh.Size = new System.Drawing.Size(178, 20);
            this.textBoxNameCh.TabIndex = 2;
            // 
            // textBoxAddressCh
            // 
            this.textBoxAddressCh.Location = new System.Drawing.Point(75, 47);
            this.textBoxAddressCh.Name = "textBoxAddressCh";
            this.textBoxAddressCh.Size = new System.Drawing.Size(178, 20);
            this.textBoxAddressCh.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Назва";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Адреса";
            // 
            // FormStorageChang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 104);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddressCh);
            this.Controls.Add(this.textBoxNameCh);
            this.Controls.Add(this.btnCloseStorage);
            this.Controls.Add(this.btnChangeStorage);
            this.Name = "FormStorageChang";
            this.Text = "Зміна параметрів складу";
            this.Load += new System.EventHandler(this.FormStorageChang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeStorage;
        private System.Windows.Forms.Button btnCloseStorage;
        public System.Windows.Forms.TextBox textBoxNameCh;
        public System.Windows.Forms.TextBox textBoxAddressCh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}