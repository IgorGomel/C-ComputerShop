﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseShopGadgets
{
    public partial class FormSale : Form
    {
        static Timer timer;
        TimeSpan timeSpanTemp;

        TimeSpan timeActivityOfRow = new TimeSpan(36, 0, 0);
        DateTime dateTimeOfSale;
        DateTime currentDateTime;
        Decimal oldAmount;
        Decimal newAmount;
        int oldRowId;
        int newRowId;
        int row;
        int number;
        int Max;
        bool flag;
        bool availabilaty; //мітка наявності товару на складі
        IQueryable<Provider> providerIQuer;
        IQueryable<SalesArchiv> saleArchIQuer;
        IQueryable<Storage> storageIQuer;
        IQueryable<Storage> oldStorageIQuer;
        IQueryable<Assortment> assortIQuer;
        IQueryable<Device> deviceIQuer;
        IQueryable<Category> categoryIQuer;
        IQueryable<Discount> discountIQuer;
        IQueryable<Device> oldDeviceIQuer;
        Discount discount;
        SalesArchiv salesArchiv;
        Assortment assortment;
        Assortment oldAssortment;
        Assortment newAssortment;
        Category category;
        Provider provider;
        Storage storage;
        Storage oldStorage;
        Device device;
        Device oldDevice;
        //string description;

        public BusinessLogicSale busnLogicSale = new BusinessLogicSale();

        IQueryable<Device> devIQuerForTextBox = Form1.db.TableDevices;
        public AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        public AutoCompleteStringCollection sourseForBaseRepoz = new AutoCompleteStringCollection();

        public FormSale()
        {
            InitializeComponent();

            foreach (Device deviceTemp in devIQuerForTextBox)
                source.Add(deviceTemp.Name);
            textBoxGoods.AutoCompleteCustomSource = source;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            busnLogicSale.AddSaleToBaseAssortment += _Add_Sale_To_BaseAssortment;
            busnLogicSale.AddSaleToBaseSalesArchiv += _Add_Sale_To_BaseSalesArchiv;
            busnLogicSale.AddSaleToDataGridViewArchiv += _Add_Sale_To_DataGridViewArchiv;
            busnLogicSale.AddSaleToDataGridViewMain += _Add_Sale_To_DataGridViewMain;
            busnLogicSale.AddSaleToRepozitoryAssortment += _Add_Sale_To_RepozitoryAssortment;


            busnLogicSale.AddSale();

            busnLogicSale.AddSaleToBaseAssortment -= _Add_Sale_To_BaseAssortment;
            busnLogicSale.AddSaleToBaseSalesArchiv -= _Add_Sale_To_BaseSalesArchiv;
            busnLogicSale.AddSaleToDataGridViewArchiv -= _Add_Sale_To_DataGridViewArchiv;
            busnLogicSale.AddSaleToDataGridViewMain -= _Add_Sale_To_DataGridViewMain;
            busnLogicSale.AddSaleToRepozitoryAssortment -= _Add_Sale_To_RepozitoryAssortment;

        }

        private void _Add_Sale_To_BaseSalesArchiv()
        {
            if (availabilaty == true)//якщо є товар на складі - виконуємо дії
                                     //якщо нема - виводимо повідомлення
            {
                saleArchIQuer = Form1.db.TableySalesArchiv;
                
                bool hasElements = saleArchIQuer.Any();
                if (hasElements == false)
                    Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.SalesArchivs");


                if (checkBoxDiscountOffOn.Checked == false)
                {                    
                    Form1.db.TableySalesArchiv.Add(new SalesArchiv()
                    {

                        IdDevice = device.Id,
                        IdStorage = storage.Id,
                        Describe = device.Descript,  
                        Amount = (int)numericUpDownAmount.Value,
                        Price = (int)numericUpDownPrice.Value,
                        Date = Convert.ToDateTime(dateTimePickerSale.Text) + DateTime.Now.TimeOfDay
                    }
                       );
                    Form1.db.SaveChanges();
                }
                else
                {
                    discountIQuer = Form1.db.TableDiscounts;
                    var tempDiscount = discountIQuer.Where(d => string.Equals(d.Name, comboBoxDiscount.Text));
                    discount = tempDiscount.Single();

                    Form1.db.TableySalesArchiv.Add(new SalesArchiv()
                    {

                        IdDevice = device.Id,
                        IdStorage = storage.Id,
                        Describe = device.Descript,
                        Amount = (int)numericUpDownAmount.Value,
                        Price = (int)numericUpDownPrice.Value - ((int)numericUpDownPrice.Value/100*discount.Percent),
                        Date = Convert.ToDateTime(dateTimePickerSale.Text) + DateTime.Now.TimeOfDay
                    }
                       );
                    Form1.db.SaveChanges();
                }
            }
            else
                MessageBox.Show("Такої продукції на складі нема!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void _Add_Sale_To_BaseAssortment()
        {
            availabilaty = false;
            assortIQuer = Form1.db.TableAssornment;
            deviceIQuer = Form1.db.TableDevices;
            storageIQuer = Form1.db.TableStorages;
            categoryIQuer = Form1.db.TableCategoryes;

            //відбираємо склад для добавлення в таблицю Assortment. Вибірку робимо з таблиці Storages...
            //...Id елемента comboBoxStorage повинен відповідати Id поля таблиці storages
            var stor = storageIQuer.Where(d => string.Equals(d.Name, comboBoxStorage.Text)).ToList();
            storage = stor.Single();

            var categ = categoryIQuer.Where(d => string.Equals(d.Name, comboBoxCategory.Text)).ToList();
            category = categ.Single();

            //відбираємо девайс для добавлення в таблицю Assortment. Вибірку робимо з таблиці Devices...
            //...текст елемента textBoxGoods повинен бути ідентичний полю Name шуканого елемента таблицы Devices
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text) & d.IdCategory == category.Id).ToList();
            device = dev.Single();

            //проходимось по таблиці асортименту
            foreach (Assortment assort in assortIQuer)
            {
                // якщо Id девайса зпівпадає з Id вибраного девайса  і якщо Id склада зпівпадає з Id вибраного склада 
                if (assort.IdDevice == device.Id & assort.IdStorage == storage.Id)
                {
                    //...тоді просто віднімаємо кількість збутих девайсів
                    assort.Amount = assort.Amount - (int)numericUpDownAmount.Value;
                    availabilaty = true;
                    break;
                }
            }

            Form1.db.SaveChanges();
        }

        private void _Add_Sale_To_DataGridViewMain()
        {
            if (availabilaty == true)//якщо є товар на складі - воконуємо дії
                                     //якщо нема - нічого не робимо
            {
                for (int i = 0; i < Program.ff.MainDataGridView.RowCount; i++)
                {
                    if (String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[1].Value, textBoxGoods.Text) & String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[3].Value, comboBoxStorage.Text))
                        Program.ff.MainDataGridView.Rows[i].Cells[5].Value = Convert.ToInt32(Program.ff.MainDataGridView.Rows[i].Cells[5].Value) - Convert.ToInt32(numericUpDownAmount.Value);
                }
            }
        }

        private void _Add_Sale_To_DataGridViewArchiv()
        {
            if (availabilaty == true)//якщо є товар на складі - воконуємо дії
                                     //якщо нема - нічого не робимо
            {
                Max = saleArchIQuer.Max(d => d.Id);

                if(checkBoxDiscountOffOn.Checked==true)
                   dataGridViewSales.Rows.Add(Max, dataGridViewSales.RowCount + 1, textBoxGoods.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, numericUpDownPrice.Value - (numericUpDownPrice.Value/100*discount.Percent), Convert.ToDateTime(dateTimePickerSale.Text) + DateTime.Now.TimeOfDay, comboBoxCategory.Text);
                else
                    dataGridViewSales.Rows.Add(Max, dataGridViewSales.RowCount + 1, textBoxGoods.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, numericUpDownPrice.Value, Convert.ToDateTime(dateTimePickerSale.Text) + DateTime.Now.TimeOfDay, comboBoxCategory.Text);
            }
        }

        private void _Add_Sale_To_RepozitoryAssortment()
        {
            if (availabilaty == true)//якщо є товар на складі - воконуємо дії
                                     //якщо нема - нічого не робимо
            {
                foreach (Assortment assort in Form1.tempRepozit.ListAssortment)
                {
                    if (assort.IdDevice == device.Id & assort.IdStorage == storage.Id)
                    {
                        assort.Amount = assort.Amount - (int)numericUpDownAmount.Value;
                        break;
                    }
                }
            }
        }

        private void comboBoxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //categoryIQuer = Form1.db.TableCategoryes;
            //var tempCateg = categoryIQuer.Where(d => string.Equals(d.Name, comboBoxCategory.Text));
            //category = tempCateg.Single();

            //foreach (Device deviceTemp in devIQuerForTextBox)
            //{
            //    if (deviceTemp.IdCategory == category.Id)
            //        sourseForBaseRepoz.Add(deviceTemp.Name);
            //}

            //textBoxGoods.AutoCompleteCustomSource = sourseForBaseRepoz;
        }



        private void changeComboBoxValue(Object sender, EventArgs e)
        {
            textBoxGoods.Clear();
            textBoxGoods.AutoCompleteCustomSource.Clear();
            categoryIQuer = Form1.db.TableCategoryes;

            foreach (Device deviceTemp in devIQuerForTextBox)
            {
                var tempCateg = categoryIQuer.Where(d => string.Equals(d.Name, comboBoxCategory.Text));
                category = tempCateg.Single();

                if (deviceTemp.IdCategory == category.Id)
                    sourseForBaseRepoz.Add(deviceTemp.Name);
            }

            textBoxGoods.AutoCompleteCustomSource = sourseForBaseRepoz;
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Discounts". При необходимости она может быть перемещена или удалена.
            this.discountsTableAdapter.Fill(this.modelBaseShopDataSet1.Discounts);
            //this.comboBoxCategory.SelectedValueChanged += changeComboBoxValue;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Storages". При необходимости она может быть перемещена или удалена.
            this.storagesTableAdapter.Fill(this.modelBaseShopDataSet.Storages);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);

            //comboBoxCategory.SelectedValue = null;
            this.comboBoxCategory.SelectedValueChanged += changeComboBoxValue;

            saleArchIQuer = Form1.db.TableySalesArchiv;
            deviceIQuer = Form1.db.TableDevices;
            storageIQuer = Form1.db.TableStorages;
            categoryIQuer = Form1.db.TableCategoryes;

            foreach (SalesArchiv sale in saleArchIQuer)
            {
                var dev = deviceIQuer.Where(d => d.Id == sale.IdDevice).ToList();
                device = dev.Single();
                var stor = storageIQuer.Where(d => d.Id == sale.IdStorage).ToList();
                storage = stor.Single();
                var categ = categoryIQuer.Where(d => d.Id == device.IdCategory).ToList();
                category = categ.Single();

                dataGridViewSales.Rows.Add(sale.Id, dataGridViewSales.RowCount+1, device.Name, storage.Name, device.Descript, sale.Amount, sale.Price, sale.Date, category.Name);
            }

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += _DataGridArchiv_Process;
            timer.Start();

            comboBoxDiscount.Enabled = false;
        }

        private void _DataGridArchiv_Process(Object sender, EventArgs e)
        {
            if (dataGridViewSales.Rows.Count > 0)
            {
                currentDateTime = DateTime.Now;
                for (int i = 0; i < dataGridViewSales.RowCount; i++)
                {
                    dateTimeOfSale = DateTime.Parse(dataGridViewSales.Rows[i].Cells[7].Value.ToString());
                    timeSpanTemp = currentDateTime.Subtract(dateTimeOfSale);
                    
                    if (timeSpanTemp > timeActivityOfRow)
                        dataGridViewSales.Rows[i].ReadOnly = true;
                }
            }

        }



        private void btnChange_Click(object sender, EventArgs e)
        {
            busnLogicSale.ChangeSaleInBaseAssortment += _Change_Sale_In_BaseAssortment;
            busnLogicSale.ChangeSaleInBaseSalesArchiv += _Change_Sale_In_BaseSalesArchiv;
            busnLogicSale.ChangeSaleInDataGridViewArchiv += _Change_Sale_In_DataGridViewArchiv;
            busnLogicSale.ChangeSaleInDataGridViewMain += _Change_Sale_In_DataGridViewMain;
            busnLogicSale.ChangeSaleInRepozitoryAssortment += _Change_Sale_In_RepozitoryAssortment;

            busnLogicSale.ChangeSale();

            busnLogicSale.ChangeSaleInBaseAssortment -= _Change_Sale_In_BaseAssortment;
            busnLogicSale.ChangeSaleInBaseSalesArchiv -= _Change_Sale_In_BaseSalesArchiv;
            busnLogicSale.ChangeSaleInDataGridViewArchiv -= _Change_Sale_In_DataGridViewArchiv;
            busnLogicSale.ChangeSaleInDataGridViewMain -= _Change_Sale_In_DataGridViewMain;
            busnLogicSale.ChangeSaleInRepozitoryAssortment -= _Change_Sale_In_RepozitoryAssortment;

        }



        private void _Change_Sale_In_BaseAssortment()
        {
            flag = true;
            newAmount = numericUpDownAmount.Value;

            categoryIQuer = Form1.db.TableCategoryes;
            var categ = categoryIQuer.Where(d => String.Equals(d.Name, comboBoxCategory.Text)).ToList();
            category = categ.Single();
            //відбираємо новий девайс
            deviceIQuer = Form1.db.TableDevices;
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text) & d.IdCategory == category.Id).ToList();
            device = dev.Single();

            //відбираємо новий склад
            storageIQuer = Form1.db.TableStorages;
            var stor = storageIQuer.Where(d => String.Equals(d.Name, comboBoxStorage.Text)).ToList();
            storage = stor.Single();

            //якщо відбулась зміна девайса 
            if (oldDevice.Id != device.Id)
            {
                //якщо склади не змінювалися
                if (oldStorage.Id == storage.Id)
                {
                    //відбираємо рядки, в яких проведемо зміни
                    //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == oldDevice.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount + oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно зменшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                    else
                    {
                        flag = false;
                        newAssortment = oldAssortment;
                        newAssortment.IdDevice = device.Id;
                        newAssortment.Describe = device.Descript;
                        newAssortment.Price = device.Price;
                        //newAssortment.IdStorage = storage.Id;
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                }
                //якщо склади змінювалися
                else
                {
                    //відбираємо рядки, в яких проведемо зміни
                    //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == oldDevice.Id & o.IdStorage == oldStorage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount + oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно зменшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                    else
                    {
                        flag = false;
                        newAssortment = oldAssortment;
                        newAssortment.IdDevice = device.Id;
                        newAssortment.Describe = device.Descript;
                        newAssortment.Price = device.Price;
                        newAssortment.IdStorage = storage.Id;
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                }
            }
            //якщо не відбулась зміна девайса
            else
            {
                //якщо склади не змінювалися
                if (oldStorage.Id == storage.Id)
                {
                    //один склад - один рядок, два склади - два рядки
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + oldAmount - newAmount);
                    newRowId = newAssortment.Id;

                    //Form1.db.SaveChanges();
                }
                //якщо склади змінювалися
                else
                {
                    //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == oldStorage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount + oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно зменшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                    else
                    {
                        flag = false;
                        newAssortment = oldAssortment;
                        //newAssortment.IdDevice = device.Id;
                        //newAssortment.Describe = device.Descript;
                        //newAssortment.Price = device.Price;
                        newAssortment.IdStorage = storage.Id;
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - newAmount);
                        newRowId = newAssortment.Id;
                    }
                }
            }
            Form1.db.SaveChanges();
        }

        private void _Change_Sale_In_BaseSalesArchiv()
        {
            
            
            //в змінну number помістимо Id запису
            number = Convert.ToInt32(dataGridViewSales.CurrentRow.Cells[0].Value);

            salesArchiv = Form1.db.TableySalesArchiv.Where(o => o.Id == number).FirstOrDefault();
            salesArchiv.IdDevice = device.Id;
            salesArchiv.IdStorage = storage.Id;
            salesArchiv.Describe = device.Descript;
            salesArchiv.Amount = Convert.ToInt32(numericUpDownAmount.Value);
            if (checkBoxDiscountOffOn.Checked == false)
                salesArchiv.Price = device.Price;
            else
            {
                discountIQuer = Form1.db.TableDiscounts;
                var tempDiscount = discountIQuer.Where(d => string.Equals(d.Name, comboBoxDiscount.Text));
                discount = tempDiscount.Single();

                salesArchiv.Price = device.Price - (device.Price/100*discount.Percent);
            }
            salesArchiv.Date = dateTimePickerSale.Value;

            Form1.db.SaveChanges();
        }

        private void _Change_Sale_In_RepozitoryAssortment()
        {
            //якщо девайс змінювався
            if (oldDevice.Id != device.Id)
            {
                //якщо склад не змінювався
                if (oldStorage.Id == storage.Id)
                {
                    var temp1 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == oldRowId).ToList();
                    Assortment tempAssort1 = temp1.Single();
                    int indexElOldRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort1);

                    var temp2 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == newRowId).ToList();
                    Assortment tempAssort2 = temp2.Single();
                    int indexElNewRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort2);

                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Price = device.Price;
                    }
                }
                //якщо склад змінювався
                else
                {
                    var temp1 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == oldRowId).ToList();
                    Assortment tempAssort1 = temp1.Single();
                    int indexElOldRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort1);

                    var temp2 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == newRowId).ToList();
                    Assortment tempAssort2 = temp2.Single();
                    int indexElNewRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort2);

                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:

                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Price = device.Price;
                    }
                }
            }
            //якщо девайс не змінювався
            else
            {
                //якщо склад не змінювався
                if (oldStorage.Id == storage.Id)
                {
                    var temp2 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == newRowId).ToList();
                    Assortment tempAssort2 = temp2.Single();
                    int indexElNewRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort2);

                    //один склад - один рядок, два склади - два рядки
                    Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                }
                //якщо склад змінювався
                else
                {
                    var temp1 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == oldRowId).ToList();
                    Assortment tempAssort1 = temp1.Single();
                    int indexElOldRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort1);

                    var temp2 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == newRowId).ToList();
                    Assortment tempAssort2 = temp2.Single();
                    int indexElNewRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort2);

                    if (flag == true)
                    {
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                    }
                }
            }
        }

        private void _Change_Sale_In_DataGridViewArchiv()
        {
            dataGridViewSales[2, row].Value = textBoxGoods.Text;
            dataGridViewSales[3, row].Value = comboBoxStorage.Text;
            dataGridViewSales[4, row].Value = device.Descript;
            dataGridViewSales[5, row].Value = numericUpDownAmount.Value;
            if(checkBoxDiscountOffOn.Checked==false)
                dataGridViewSales[6, row].Value = device.Price;
            else
                dataGridViewSales[6, row].Value = device.Price - (device.Price/100*discount.Percent);
            dataGridViewSales[7, row].Value = dateTimePickerSale.Value;
            dataGridViewSales[8, row].Value = comboBoxCategory.Text;
        }

        private void _Change_Sale_In_DataGridViewMain()
        {
            //якщо девайс змінювався
            if (oldDevice.Id != device.Id)
            {
                //якщо склад не змінювався
                if (oldStorage.Id == storage.Id)
                {
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) - newAmount;
                    }
                    else
                    {
                        Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        //Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount - newAmount;
                        Program.ff.MainDataGridView[6, newRowId - 1].Value = device.Price;
                    }
                }
                //якщо склад  змінювався
                else
                {
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) - newAmount;
                    }
                    else
                    {
                        Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount - newAmount;
                        Program.ff.MainDataGridView[6, newRowId - 1].Value = device.Price;
                    }
                }
            }
            //якщо девайс не змінювався
            else
            {
                //якщо склад не змінювався
                if (oldStorage.Id == storage.Id)
                {
                    //один склад - один рядок, два склади - два рядки
                    Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) + oldAmount - newAmount;
                }
                //якщо склад змінювався
                else
                {
                    if (flag == true)
                    {
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) - newAmount;
                    }
                    else
                    {
                        //Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        //Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        //Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) + oldAmount - newAmount;
                        //Program.ff.MainDataGridView[6, newRowId - 1].Value = device.Price;
                    }
                }
            }
        }

        private void dataGridViewSales_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;

            comboBoxCategory.Text = dataGridViewSales[8, row].Value.ToString();
            textBoxGoods.Text = dataGridViewSales[2, row].Value.ToString();
            comboBoxStorage.Text = dataGridViewSales[3, row].Value.ToString();
            numericUpDownAmount.Value = Convert.ToDecimal(dataGridViewSales[5, row].Value.ToString());
            numericUpDownPrice.Value = Convert.ToDecimal(dataGridViewSales[6,row].Value.ToString());
            dateTimePickerSale.Value = Convert.ToDateTime(dataGridViewSales[7, row].Value.ToString());

            //робимо вибірку девайса, але того який був відразу ж після його вибору в DataGridView...
            //...і зберігаємо його в змінній oldDevice
            oldDeviceIQuer = Form1.db.TableDevices;
            var dev = oldDeviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text)).ToList();
            oldDevice = dev.Single();

            //робимо вибірку склада, але того який був відразу ж після його вибору в DataGridView...
            //...і зберігаємо його в змінній oldStorage
            oldStorageIQuer = Form1.db.TableStorages;
            var stor = oldStorageIQuer.Where(d => String.Equals(d.Name, comboBoxStorage.Text)).ToList();
            oldStorage = stor.Single();

            //зберігаємо в зміну кількість девайсів, яка була відразу ж після вибору в DataGridView...
            oldAmount = numericUpDownAmount.Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            busnLogicSale.DeleteSaleFromBaseSalesArchiv += _Delete_Sale_From_BaseSalesArchiv;
            busnLogicSale.DeleteSaleFromBaseSalesAssortment += _Delete_Sale_From_BaseSalesAssortment;
            busnLogicSale.DeleteSaleFromDataGridViewArchiv += _Delete_Sale_From_DataGridViewArchiv;
            busnLogicSale.DeleteSaleFromDataGridViewMain += _Delete_Sale_From_DataGridViewMain;
            busnLogicSale.DeleteSaleFromRepozitoryAssortment += _Delete_Sale_From_RepozitoryAssortment;


            busnLogicSale.DeleteSale();

            busnLogicSale.DeleteSaleFromBaseSalesArchiv -= _Delete_Sale_From_BaseSalesArchiv;
            busnLogicSale.DeleteSaleFromBaseSalesAssortment -= _Delete_Sale_From_BaseSalesAssortment;
            busnLogicSale.DeleteSaleFromDataGridViewArchiv -= _Delete_Sale_From_DataGridViewArchiv;
            busnLogicSale.DeleteSaleFromDataGridViewMain -= _Delete_Sale_From_DataGridViewMain;
            busnLogicSale.DeleteSaleFromRepozitoryAssortment -= _Delete_Sale_From_RepozitoryAssortment;

        }

        private void _Delete_Sale_From_BaseSalesAssortment()
        {
            categoryIQuer = Form1.db.TableCategoryes;
            var categ = categoryIQuer.Where(d => String.Equals(d.Name, comboBoxCategory.Text)).ToList();
            category = categ.Single();

            //відбираємо девайс
            deviceIQuer = Form1.db.TableDevices;
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text) & d.IdCategory == category.Id).ToList();
            device = dev.Single();

            ////відбираємо  склад
            storageIQuer = Form1.db.TableStorages;
            var stor = storageIQuer.Where(d => String.Equals(d.Name, comboBoxStorage.Text)).ToList();
            storage = stor.Single();

            //відбираємо рядок, в якому проведемо зміни
            assortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
            assortment.Amount = assortment.Amount + Convert.ToInt32(oldAmount);
            //oldAmount - зміна, в яку записано значення кількості девайсів відразу ж після вибору рядка в DataGridView
            Form1.db.SaveChanges();
        }

        private void _Delete_Sale_From_BaseSalesArchiv()
        {
            ////в змінну number помістимо Id запису
            number = Convert.ToInt32(dataGridViewSales.CurrentRow.Cells[0].Value);
            salesArchiv = Form1.db.TableySalesArchiv.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableySalesArchiv.Remove(salesArchiv);
            Form1.db.SaveChanges();
        }

        private void _Delete_Sale_From_RepozitoryAssortment()
        {
            for (int i = 0; i < Form1.tempRepozit.ListAssortment.Count; i++)
            {
                if (Form1.tempRepozit.ListAssortment[i].IdDevice == device.Id & Form1.tempRepozit.ListAssortment[i].IdStorage == storage.Id)
                {
                    Form1.tempRepozit.ListAssortment[i].Amount = Form1.tempRepozit.ListAssortment[i].Amount + Convert.ToInt32(oldAmount);
                    break;
                }
            }
        }

        private void _Delete_Sale_From_DataGridViewArchiv()
        {
            number = dataGridViewSales.CurrentRow.Index;
            dataGridViewSales.Rows.RemoveAt(number);

            //якщо наш рядок(number) не являється останнім... 
            if (dataGridViewSales.Rows.Count != number)
            {
                for (int i = 0; i < dataGridViewSales.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridViewSales.Rows[i].Cells[1].Value) > number)
                        dataGridViewSales.Rows[i].Cells[1].Value = Convert.ToInt32(dataGridViewSales.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        private void _Delete_Sale_From_DataGridViewMain()
        {
            for (int i = 0; i < Program.ff.MainDataGridView.Rows.Count; i++)
            {
                if (String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[1].Value, device.Name) & String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[3].Value, storage.Name))
                {
                    Program.ff.MainDataGridView.Rows[i].Cells[5].Value = Convert.ToInt32(Program.ff.MainDataGridView.Rows[i].Cells[5].Value) + Convert.ToInt32(oldAmount);
                    break;
                }
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //categoryIQuer = Form1.db.TableCategoryes;
            //var tempCateg = categoryIQuer.Where(d => string.Equals(d.Name, comboBoxCategory.Text));
            //category = tempCateg.Single();

            //foreach (Device deviceTemp in devIQuerForTextBox)
            //{
            //    if (deviceTemp.IdCategory == category.Id)
            //        sourseForBaseRepoz.Add(deviceTemp.Name);
            //}

            //textBoxGoods.AutoCompleteCustomSource = sourseForBaseRepoz;
        }

        private void checkBoxDiscountOffOn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDiscountOffOn.Checked == true)
                comboBoxDiscount.Enabled = true;
            else
                comboBoxDiscount.Enabled = false;
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
