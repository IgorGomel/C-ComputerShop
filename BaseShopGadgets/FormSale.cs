using System;
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
        DateTime dateTimeOfDelivery;
        DateTime currentDateTime;
        Decimal oldAmount;
        Decimal newAmount;
        int oldRowId;
        int newRowId;
        int row;
        int number;
        int Max;
        bool flag;
        IQueryable<Provider> providerIQuer;
        IQueryable<SalesArchiv> saleArchIQuer;
        IQueryable<Storage> storageIQuer;
        IQueryable<Storage> oldStorageIQuer;
        IQueryable<Assortment> assortIQuer;
        IQueryable<Device> deviceIQuer;
        IQueryable<Category> categoryIQuer;
        IQueryable<Device> oldDeviceIQuer;
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
            busnLogicSale.AddSale();
        }

        private void _Add_Sale_To_BaseSalesArchiv()
        {
            saleArchIQuer = Form1.db.TableySalesArchiv;
            deviceIQuer = Form1.db.TableDevices;
            storageIQuer = Form1.db.TableStorages;
            

            bool hasElements = saleArchIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.SalesArchivs");

            //відбираємо склад для добавлення в таблицю Assortment. Вибірку робимо з таблиці Storages...
            //...Id елемента comboBoxStorage повинен відповідати Id поля таблиці storages
            var stor = storageIQuer.Where(d => string.Equals(d.Id, comboBoxStorage.Text)).ToList();
            storage = stor.Single();


            //відбираємо девайс для добавлення в таблицю Assortment. Вибірку робимо з таблиці Devices...
            //...текст елемента textBoxGoods повинен бути ідентичний полю Name шуканого елемента таблицы Devices
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text)).ToList();
            device = dev.Single();

            Form1.db.TableySalesArchiv.Add(new SalesArchiv()
            {
                
                IdDevice = device.Id,
                IdStorage = storage.Id,
                Describe = device.Descript,  //Convert.ToString(description),
                Amount = (int)numericUpDownAmount.Value,
                Price = (int)numericUpDownPrice.Value,
                Date = dateTimePickerSale.Value
            }
               );
            Form1.db.SaveChanges();
        }

        private void _Add_Sale_To_BaseAssortment()
        {
            assortIQuer = Form1.db.TableAssornment;

            //проходимось по таблиці асортименту
            foreach (Assortment assort in assortIQuer)
            {
                // якщо Id девайса зпівпадає з Id вибраного девайса  і якщо Id склада зпівпадає з Id вибраного склада 
                if (assort.IdDevice == device.Id & assort.IdStorage == storage.Id)
                {
                    //...тоді просто віднімаємо кількість збутих девайсів
                    assort.Amount = assort.Amount - (int)numericUpDownAmount.Value;
                    break;
                }
            }

            Form1.db.SaveChanges();
        }

        private void _Add_Sale_To_DataGridViewMain()
        {
            for (int i = 0; i < dataGridViewSales.RowCount; i++)
            {
                if(String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[1].Value, textBoxGoods.Text) & String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[3].Value, comboBoxStorage.Text))
                    Program.ff.MainDataGridView.Rows[i].Cells[5].Value = Convert.ToInt32(Program.ff.MainDataGridView.Rows[i].Cells[5].Value) - Convert.ToInt32(numericUpDownAmount.Value);
            }
        }

        private void _Add_Sale_To_DataGridViewArchiv()
        {
            Max = saleArchIQuer.Max(d => d.Id);
            dataGridViewSales.Rows.Add(Max,dataGridViewSales.RowCount+1, textBoxGoods.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, numericUpDownPrice.Value, dateTimePickerSale.Value, comboBoxCategory.Text);
        }

        private void _Add_Sale_To_RepozitoryAssortment()
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

        private void comboBoxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void changeComboBoxValue(Object sender, EventArgs e)
        {
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Storages". При необходимости она может быть перемещена или удалена.
            this.storagesTableAdapter.Fill(this.modelBaseShopDataSet.Storages);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            comboBoxCategory.SelectedValue = null;
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

                dataGridViewSales.Rows.Add(sale.Id, dataGridViewSales.RowCount, device.Name, storage.Name, device.Descript, sale.Amount, sale.Price, sale.Date, category.Name);
            }

            busnLogicSale.AddSaleToBaseAssortment += _Add_Sale_To_BaseAssortment;
            busnLogicSale.AddSaleToBaseSalesArchiv += _Add_Sale_To_BaseSalesArchiv;
            busnLogicSale.AddSaleToDataGridViewArchiv += _Add_Sale_To_DataGridViewArchiv;
            busnLogicSale.AddSaleToDataGridViewMain += _Add_Sale_To_DataGridViewMain;
            busnLogicSale.AddSaleToRepozitoryAssortment += _Add_Sale_To_RepozitoryAssortment;

            busnLogicSale.ChangeSaleInBaseAssortment += _Change_Sale_In_BaseAssortment;
            busnLogicSale.ChangeSaleInBaseSalesArchiv += _Change_Sale_In_BaseSalesArchiv;
            busnLogicSale.ChangeSaleInDataGridViewArchiv += _Change_Sale_In_DataGridViewArchiv;
            busnLogicSale.ChangeSaleInDataGridViewMain += _Change_Sale_In_DataGridViewMain;
            busnLogicSale.ChangeSaleInRepozitoryAssortment += _Change_Sale_In_RepozitoryAssortment;

            busnLogicSale.DeleteSaleFromBaseSalesArchiv += _Delete_Sale_From_BaseSalesArchiv;
            busnLogicSale.DeleteSaleFromBaseSalesAssortment += _Delete_Sale_From_BaseSalesAssortment;
            busnLogicSale.DeleteSaleFromDataGridViewArchiv += _Delete_Sale_From_DataGridViewArchiv;
            busnLogicSale.DeleteSaleFromDataGridViewMain += _Delete_Sale_From_DataGridViewMain;
            busnLogicSale.DeleteSaleFromRepozitoryAssortment += _Delete_Sale_From_RepozitoryAssortment;


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            busnLogicSale.ChangeSale();
        }

        

        private void _Change_Sale_In_BaseAssortment()
        {
            flag = true;
            newAmount = numericUpDownAmount.Value;

            //відбираємо новий девайс
            deviceIQuer = Form1.db.TableDevices;
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, dataGridViewSales.CurrentRow.Cells[2].Value)).ToList();
            device = dev.Single();

            //відбираємо новий склад
            storageIQuer = Form1.db.TableStorages;
            var stor = storageIQuer.Where(d => String.Equals(d.Name, dataGridViewSales.CurrentRow.Cells[3].Value)).ToList();
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
            //storageIQuer = Form1.db.TableStorages;
            //var tempStore = storageIQuer.Where(d => string.Equals(d.Id, comboBoxStorage.Text));
            //storage = tempStore.Single();

            //в змінну number помістимо Id запису
            number = Convert.ToInt32(dataGridViewSales.CurrentRow.Cells[0].Value);

            salesArchiv = Form1.db.TableySalesArchiv.Where(o => o.Id == number).FirstOrDefault();
            salesArchiv.IdDevice = device.Id;
            salesArchiv.IdStorage = storage.Id;
            salesArchiv.Describe = device.Descript;
            salesArchiv.Amount = Convert.ToInt32(numericUpDownAmount.Value);
            salesArchiv.Price = Convert.ToInt32(numericUpDownPrice.Value);
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
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[newRowId - 1].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[newRowId - 1].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Price = device.Price;
                    }
                }
                //якщо склад змінювався
                else
                {
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:

                        Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[newRowId - 1].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[newRowId - 1].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Price = device.Price;
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
                    Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[newRowId - 1].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
                }
                //якщо склад змінювався
                else
                {
                    if (flag == true)
                    {
                        //спочатку рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount + Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[newRowId - 1].Amount - Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[newRowId - 1].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[newRowId - 1].Amount = Form1.tempRepozit.ListAssortment[newRowId - 1].Amount + Convert.ToInt32(oldAmount) - Convert.ToInt32(newAmount);
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
            dataGridViewSales[6, row].Value = numericUpDownPrice.Value;
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
            busnLogicSale.DeleteSale();
        }

        private void _Delete_Sale_From_BaseSalesAssortment()
        {
            //відбираємо девайс
            deviceIQuer = Form1.db.TableDevices;
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, dataGridViewSales.CurrentRow.Cells[2].Value)).ToList();
            device = dev.Single();

            ////відбираємо  склад
            storageIQuer = Form1.db.TableStorages;
            var stor = storageIQuer.Where(d => String.Equals(d.Name, dataGridViewSales.CurrentRow.Cells[4].Value)).ToList();
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
            //number = dataGridViewSales.CurrentRow.Index;
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

        }
    }
}
