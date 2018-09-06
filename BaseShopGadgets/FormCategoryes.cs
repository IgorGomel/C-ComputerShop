using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace BaseShopGadgets
{
    public partial class FormCategoryes : Form
    {
        IQueryable<Category> categoryIQuer;
        int row;
        Category category;
        int number;
        BusinessLogicCategory busnLogicCategory = new BusinessLogicCategory();

        public FormCategoryes()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            this.busnLogicCategory.AddCategory();
        }

        public void _Add_Category_To_Base()
        {           
            IQueryable<Category> categorIQuer = Form1.db.TableCategoryes;
            bool hasElements = categorIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Categories");
      
            Form1.db.TableCategoryes.Add(new Category()
            {
                Name = textBoxCategory.Text            
            }
                );
            Form1.db.SaveChanges();
        }

        public void _Add_Category_To_DataGridView_FormGoods()
        {
            IQueryable<Category> categorIQuer = Form1.db.TableCategoryes;
            int Max = categorIQuer.Max(d => d.Id);

            FormGoods.newFormCategoryes.dataGridViewCategory.Rows.Add(Max, FormGoods.newFormCategoryes.dataGridViewCategory.Rows.Count, textBoxCategory.Text);
            FormGoods.newFormCategoryes.textBoxCategory.Clear();
        }

        public void _Add_Category_To_Repozitory()
        {
            IQueryable<Category> categorIQuer = Form1.db.TableCategoryes;
            int Max = categorIQuer.Max(d => d.Id);
           
            Form1.tempRepozit.ListCaregoryes.Add(new Category()
            {
                Id = Max,
                Name = textBoxCategory.Text
            });
        }

        private void FormCategoryes_Load(object sender, EventArgs e)
        {
            categoryIQuer = Form1.db.TableCategoryes;

            foreach (Category categ in categoryIQuer)
                dataGridViewCategory.Rows.Add(categ.Id, dataGridViewCategory.RowCount, categ.Name);

            foreach (Category categ in categoryIQuer)
            {
                Form1.tempRepozit.ListCaregoryes.Add(new Category()
                {
                    Id = categ.Id,
                    Name = categ.Name
                });
            }

            this.busnLogicCategory.AddCategoryToBase += _Add_Category_To_Base;
            this.busnLogicCategory.AddCategoryToDataGridView += _Add_Category_To_DataGridView_FormGoods;
            this.busnLogicCategory.AddCategoryToRepozitory += _Add_Category_To_Repozitory;

            this.busnLogicCategory.DeleteCategoryFromBase += _Delete_Category_From_Base;
            this.busnLogicCategory.DeleteCategoryFromDataGridView += _Delete_Category_From_DataGridView_FormGoods;
            this.busnLogicCategory.DeleteCategoryFromRepozitory += _Delete_Category_From_Repozitory;

            this.busnLogicCategory.ChangeCategoryInBase += _Change_Category_In_Base;
            this.busnLogicCategory.ChangeCategoryInDataGridView += _Change_Category_In_DataGridView_FormGoods;
            this.busnLogicCategory.ChangeCategoryInRepozitory += _Change_Category_In_Repozitory;

        }

        

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.busnLogicCategory.DeleteCategory();
        }

        public void _Delete_Category_From_Base()
        {
            //...а з бази видаляємо рядок, який відповідає поточному рядку датигрід, але з певним Id
            number = Convert.ToInt32(FormGoods.newFormCategoryes.dataGridViewCategory.Rows[row].Cells[0].Value);
            category = Form1.db.TableCategoryes.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableCategoryes.Remove(category);
            Form1.db.SaveChanges();
        }

        public void _Delete_Category_From_DataGridView_FormGoods()
        {
            //видаляємо з датигрідвью поточний рядок
            number = FormGoods.newFormCategoryes.dataGridViewCategory.CurrentRow.Index;
            FormGoods.newFormCategoryes.dataGridViewCategory.Rows.RemoveAt(number);
            //якщо наш рядок(number) не являється останнім... 
            if (FormGoods.newFormCategoryes.dataGridViewCategory.Rows.Count != number)
            {
                //...тоді проходимося по DataGridView і змінюємо порядкові номери рядків
                for (int i = 0; i < FormGoods.newFormCategoryes.dataGridViewCategory.Rows.Count; i++)
                {
                    if (Convert.ToInt32(FormGoods.newFormCategoryes.dataGridViewCategory.Rows[i].Cells[1].Value) > number)
                        FormGoods.newFormCategoryes.dataGridViewCategory.Rows[i].Cells[1].Value = Convert.ToInt32(FormGoods.newFormCategoryes.dataGridViewCategory.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        

        public void _Delete_Category_From_Repozitory()
        {
            Form1.tempRepozit.ListCaregoryes.RemoveAt(number);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.busnLogicCategory.ChangeCategory();
        }

        public void _Change_Category_In_DataGridView_FormGoods()
        {
            number = FormGoods.newFormCategoryes.dataGridViewCategory.CurrentRow.Index;
            FormGoods.newFormCategoryes.dataGridViewCategory[2, number].Value = textBoxCategory.Text;
        }

        public void _Change_Category_In_Base()
        {
            number = Convert.ToInt32(FormGoods.newFormCategoryes.dataGridViewCategory.Rows[row].Cells[0].Value);
            category = Form1.db.TableCategoryes.Where(o => o.Id == number).FirstOrDefault();
            category.Name = textBoxCategory.Text;
            
            Form1.db.SaveChanges();

        }

        public void _Change_Category_In_Repozitory()
        {
            Form1.tempRepozit.ListCaregoryes[row].Name = textBoxCategory.Text;
        }

        private void dataGridViewCategory_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            FormGoods.newFormCategoryes.dataGridViewCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;

            //if (row == 0)
            //    FormGoods.newFormCategoryes.textBoxCategory.Clear();
            //else
                FormGoods.newFormCategoryes.textBoxCategory.Text = FormGoods.newFormCategoryes.dataGridViewCategory.Rows[row].Cells[2].Value.ToString();
        }
    }
}
