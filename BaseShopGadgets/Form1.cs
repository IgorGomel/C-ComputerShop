using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace BaseShopGadgets
{
    public partial class Form1 : Form
    {
        IQueryable<Assortment> assortIQuer;
        IQueryable<Device> deviceIQuer;
        IQueryable<Storage> storageIQuer;
        IQueryable<Category> categoryIQuer;
        Device device;
        Storage storage;
        Category category;

        public static FormDiscounts formDiscounts;
        public static FormProviders formProviders;
        public static FormStorages formStorages;
        public static FormGoods formGoods;
        public static FormVipClients formVipClients;
        public static FormDelivery formDelivery;
        public static FormSale formSale;

        public static TempRepozit<Device, Category, Provider, Storage,VipClient, Discount, Assortment, DeliveryesArchiv, SalesArchiv> tempRepozit = 
            new TempRepozit <Device, Category, Provider, Storage, VipClient, Discount, Assortment, DeliveryesArchiv, SalesArchiv>();

        public static ModelBaseShop db;

        BusinessLogicDelivery businessLogicDelivery = new BusinessLogicDelivery();
        
        public Form1()
        {
            InitializeComponent();
            db = new ModelBaseShop();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Storages". При необходимости она может быть перемещена или удалена.
            this.storagesTableAdapter.Fill(this.modelBaseShopDataSet1.Storages);
            comboBoxSearchByStorage.Text = " ";
            comboBoxSearchByCategory.Text = " ";

            assortIQuer = db.TableAssornment;
            deviceIQuer = db.TableDevices;
            storageIQuer = db.TableStorages;
            categoryIQuer = db.TableCategoryes;

            foreach (Assortment assort in assortIQuer)
            {
                var dev = deviceIQuer.Where(d => d.Id == assort.IdDevice).ToList();
                device = dev.Single();
                var stor = storageIQuer.Where(d => d.Id == assort.IdStorage).ToList();
                storage = stor.Single();
                var categ = categoryIQuer.Where(d => d.Id == device.IdCategory).ToList();
                category = categ.Single();


                MainDataGridView.Rows.Add(assort.Id, device.Name, category.Name, storage.Name, assort.Describe, assort.Amount, assort.Price);
            }

            foreach (Assortment assort in assortIQuer)
            {
                //var dev = deviceIQuer.Where(d => d.Id == assort.IdDevice).ToList();
                //device = dev.Single();
                //var stor = storageIQuer.Where(d => d.Id == assort.IdStorage).ToList();
                //storage = stor.Single();
                //var categ = categoryIQuer.Where(d => d.Id == device.IdCategory).ToList();
                //category = categ.Single();

                Form1.tempRepozit.ListAssortment.Add(new Assortment()
                {
                    Id = assort.Id,
                    IdStorage = assort.IdStorage,
                    Describe = assort.Describe,
                    Amount = assort.Amount,
                    Price = assort.Price, 
                    IdDevice = assort.IdDevice
                });
            }
        }

        //виклик форми "Товари"
        public void BtnGoods_Click(object sender, EventArgs e)
        {
            formGoods = new FormGoods();
            formGoods.ShowDialog();
        }

        private void toolStripMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BtnNewDelivery_Click(object sender, EventArgs e)
        {
            formDelivery = new FormDelivery();
            formDelivery.Show();
            //FormDelivery.timer = new Timer(5);
        }

        private void BtnStorages_Click(object sender, EventArgs e)
        {
            formStorages = new FormStorages();
            formStorages.ShowDialog();
        }

        private void BtnProviders_Click(object sender, EventArgs e)
        {
            formProviders = new FormProviders();
            formProviders.ShowDialog();
        }

        private void BtnVipClients_Click(object sender, EventArgs e)
        {
            formVipClients = new FormVipClients();
            formVipClients.ShowDialog();
        }

        private void BtnDiscounts_Click(object sender, EventArgs e)
        {
            formDiscounts = new FormDiscounts();
            formDiscounts.ShowDialog();
        }

        private void BtnNewSale_Click(object sender, EventArgs e)
        {
            formSale = new FormSale();
            formSale.Show();
        }

        private void textBoxSearchGoods_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MainDataGridView.RowCount; i++)
                MainDataGridView.Rows[i].Visible = true;

            if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text == " ")
            {
                for (int i = 0; i < MainDataGridView.RowCount; i++)
                {
                    if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == false)
                        MainDataGridView.Rows[i].Visible = false;
                }
            }

            else
            {
                if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text == " ")
                {
                    for (int i = 0; i < MainDataGridView.RowCount; i++)
                    {
                        if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                            MainDataGridView.Rows[i].Visible = true;
                        else
                            MainDataGridView.Rows[i].Visible = false;
                    }
                }
                else
                {
                    if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text != " ")
                    {
                        for (int i = 0; i < MainDataGridView.RowCount; i++)
                        {
                            if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true)
                                MainDataGridView.Rows[i].Visible = true;
                            else
                                MainDataGridView.Rows[i].Visible = false;
                        }
                    }
                    else
                    {
                        if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text != " ")
                        {
                            for (int i = 0; i < MainDataGridView.RowCount; i++)
                            {
                                if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                                    MainDataGridView.Rows[i].Visible = true;
                                else
                                    MainDataGridView.Rows[i].Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnDisplayBase_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < MainDataGridView.RowCount - 1; i++)
            //    MainDataGridView.Rows[i].Visible = true;
        }

        private void comboBoxSearchByStorage_TextChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < MainDataGridView.RowCount; i++)
                MainDataGridView.Rows[i].Visible = true;

            if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text == " ")
            {
                for (int i = 0; i < MainDataGridView.RowCount; i++)
                {
                    if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == false)
                        MainDataGridView.Rows[i].Visible = false;
                }
            }

            else
            {
                if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text == " ")
                {
                    for (int i = 0; i < MainDataGridView.RowCount; i++)
                    {
                        if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                            MainDataGridView.Rows[i].Visible = true;
                        else
                            MainDataGridView.Rows[i].Visible = false;
                    }
                }
                else
                {
                    if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text != " ")
                    {
                        for (int i = 0; i < MainDataGridView.RowCount; i++)
                        {
                            if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true)
                                MainDataGridView.Rows[i].Visible = true;
                            else
                                MainDataGridView.Rows[i].Visible = false;
                        }
                    }
                    else
                    {
                        if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text != " ")
                        {
                            for (int i = 0; i < MainDataGridView.RowCount; i++)
                            {
                                if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                                    MainDataGridView.Rows[i].Visible = true;
                                else
                                    MainDataGridView.Rows[i].Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void comboBoxSearchByCategory_TextChanged(object sender, EventArgs e)
        {
            
            for (int i = 0; i < MainDataGridView.RowCount; i++)
                MainDataGridView.Rows[i].Visible = true;

            if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text == " ")
            {
                for (int i = 0; i < MainDataGridView.RowCount; i++)
                {
                    if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == false)
                        MainDataGridView.Rows[i].Visible = false;
                }
            }

            else
            {
                if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text == " ")
                {
                    for (int i = 0; i < MainDataGridView.RowCount; i++)
                    {
                        if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                            MainDataGridView.Rows[i].Visible = true;
                        else
                            MainDataGridView.Rows[i].Visible = false;
                    }
                }
                else
                {
                    if (comboBoxSearchByStorage.Text == " " & comboBoxSearchByCategory.Text != " ")
                    {
                        for (int i = 0; i < MainDataGridView.RowCount; i++)
                        {
                            if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true)
                                MainDataGridView.Rows[i].Visible = true;
                            else
                                MainDataGridView.Rows[i].Visible = false;
                        }
                    }
                    else
                    {
                        if (comboBoxSearchByStorage.Text != " " & comboBoxSearchByCategory.Text != " ")
                        {
                            for (int i = 0; i < MainDataGridView.RowCount; i++)
                            {
                                if (Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[1].Value.ToString(), textBoxSearchGoods.Text.ToString(), StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[2].Value.ToString(), comboBoxSearchByCategory.Text, StringComparison.OrdinalIgnoreCase) == true & Expansion.ContainsWithoutRegister(MainDataGridView.Rows[i].Cells[3].Value.ToString(), comboBoxSearchByStorage.Text, StringComparison.OrdinalIgnoreCase) == true)
                                    MainDataGridView.Rows[i].Visible = true;
                                else
                                    MainDataGridView.Rows[i].Visible = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
