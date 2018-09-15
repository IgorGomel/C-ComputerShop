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
using System.Data.Common;
//using System.Timers;

namespace BaseShopGadgets
{
    public partial class FormDelivery : Form
    {
        static Timer timer;
        TimeSpan timeSpanTemp;

        TimeSpan timeActivityOfRow = new TimeSpan(36, 0 , 0);
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
        IQueryable<Category> categoryIQuer;
        IQueryable<Provider> providerIQuer;
        IQueryable<DeliveryesArchiv> delivArchIQuer; 
        IQueryable<Storage> storageIQuer;
        IQueryable<Storage> oldStorageIQuer;
        IQueryable<Assortment> assortIQuer;
        IQueryable<Device> deviceIQuer;
        IQueryable<Device> oldDeviceIQuer;
        DeliveryesArchiv deliveryesArchiv;
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

        public BusinessLogicDelivery busnLogicDelivery = new BusinessLogicDelivery();

        IQueryable<Device> devIQuerForTextBox = Form1.db.TableDevices;
        public AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        public AutoCompleteStringCollection sourseForBaseRepoz = new AutoCompleteStringCollection();       

        public FormDelivery()
        {
            InitializeComponent();
            foreach (Device deviceTemp in devIQuerForTextBox)
                source.Add(deviceTemp.Name);
            textBoxGoods.AutoCompleteCustomSource = source;
        }

        private void FormDelivery_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Devices". При необходимости она может быть перемещена или удалена.
            //this.devicesTableAdapter1.Fill(this.modelBaseShopDataSet1.Devices);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Providers". При необходимости она может быть перемещена или удалена.
            this.providersTableAdapter.Fill(this.modelBaseShopDataSet.Providers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Storages". При необходимости она может быть перемещена или удалена.
            this.storagesTableAdapter.Fill(this.modelBaseShopDataSet.Storages);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Devices". При необходимости она может быть перемещена или удалена.
            //this.devicesTableAdapter.Fill(this.modelBaseShopDataSet.Devices);

            this.comboBoxCategory.SelectedValueChanged += changeComboBoxValue;

            delivArchIQuer = Form1.db.TableDeliveryesArchiv;
            deviceIQuer = Form1.db.TableDevices;
            providerIQuer = Form1.db.TableProviders;
            storageIQuer = Form1.db.TableStorages;
            categoryIQuer = Form1.db.TableCategoryes;

            foreach (DeliveryesArchiv delivery in delivArchIQuer)
            {
                var dev = deviceIQuer.Where(d => d.Id == delivery.IdDevice).ToList();
                device = dev.Single();
                var stor = storageIQuer.Where(d => d.Id == delivery.IdStorage).ToList();
                storage = stor.Single();
                var prov = providerIQuer.Where(d => d.Id == delivery.IdProvider).ToList();
                provider = prov.Single();
                var categ = categoryIQuer.Where(d => d.Id == device.IdCategory).ToList();
                category = categ.Single();

                dataGrViewDeliveryArchiv.Rows.Add(delivery.Id, dataGrViewDeliveryArchiv.RowCount + 1, device.Name, provider.Name, storage.Name, delivery.Describe, delivery.Amount, delivery.Price, delivery.Date, category.Name);
            }

            //// TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            //this.categoriesTableAdapter.Fill(this.modelBaseShopDataSet1.Categories);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet1.Devices". При необходимости она может быть перемещена или удалена.
            ////this.devicesTableAdapter1.Fill(this.modelBaseShopDataSet1.Devices);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Providers". При необходимости она может быть перемещена или удалена.
            //this.providersTableAdapter.Fill(this.modelBaseShopDataSet.Providers);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Storages". При необходимости она может быть перемещена или удалена.
            //this.storagesTableAdapter.Fill(this.modelBaseShopDataSet.Storages);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "modelBaseShopDataSet.Devices". При необходимости она может быть перемещена или удалена.
            ////this.devicesTableAdapter.Fill(this.modelBaseShopDataSet.Devices);

            //textBoxGoods.Text = " ";

            //comboBoxCategory.SelectedValue = null;
            //this.comboBoxCategory.SelectedValueChanged += changeComboBoxValue;

            timer = new Timer();
            timer.Interval = 5000;//3600000;
            timer.Tick += _DataGridArchiv_Process;
            timer.Start();
        }

        //private void _Load_Form_Delivery()
        //{
        //    delivArchIQuer = Form1.db.TableDeliveryesArchiv;
        //    deviceIQuer = Form1.db.TableDevices;
        //    providerIQuer = Form1.db.TableProviders;
        //    storageIQuer = Form1.db.TableStorages;
        //    categoryIQuer = Form1.db.TableCategoryes;

        //    foreach (DeliveryesArchiv delivery in delivArchIQuer)
        //    {
        //        var dev = deviceIQuer.Where(d => d.Id == delivery.IdDevice).ToList();
        //        device = dev.Single();
        //        var stor = storageIQuer.Where(d => d.Id == delivery.IdStorage).ToList();
        //        storage = stor.Single();
        //        var prov = providerIQuer.Where(d => d.Id == delivery.IdProvider).ToList();
        //        provider = prov.Single();
        //        var categ = categoryIQuer.Where(d => d.Id == device.IdCategory).ToList();
        //        category = categ.Single();

        //        dataGrViewDeliveryArchiv.Rows.Add(delivery.Id, dataGrViewDeliveryArchiv.RowCount + 1, device.Name, provider.Name, storage.Name, delivery.Describe, delivery.Amount, delivery.Price, delivery.Date, category.Name);
        //    }
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.busnLogicDelivery.AddDeliveryToBaseAssortment += _Add_Delivery_To_Base_Assortment;
            this.busnLogicDelivery.AddDeliveryToDataGridViewMain += _Add_Delivery_To_DataGridView_Main;
            this.busnLogicDelivery.AddDeliveryToRepozitoryAssortment += _Add_Delivery_To_Repository_Assortment;
            this.busnLogicDelivery.AddDeliveryToBaseDeliveryesArchiv += _Add_Delivery_To_Base_DeliveryesArchiv;
            this.busnLogicDelivery.AddDeliveryToDataGridViewArchiv += _Add_Delivery_To_DataGridView_Archiv;

            this.busnLogicDelivery.AddDelivery();

            this.busnLogicDelivery.AddDeliveryToBaseAssortment -= _Add_Delivery_To_Base_Assortment;
            this.busnLogicDelivery.AddDeliveryToDataGridViewMain -= _Add_Delivery_To_DataGridView_Main;
            this.busnLogicDelivery.AddDeliveryToRepozitoryAssortment -= _Add_Delivery_To_Repository_Assortment;
            this.busnLogicDelivery.AddDeliveryToBaseDeliveryesArchiv -= _Add_Delivery_To_Base_DeliveryesArchiv;
            this.busnLogicDelivery.AddDeliveryToDataGridViewArchiv -= _Add_Delivery_To_DataGridView_Archiv;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void _Add_Delivery_To_Base_Assortment()
        {
           
            flag = true;
            categoryIQuer = Form1.db.TableCategoryes;
            storageIQuer = Form1.db.TableStorages;
            assortIQuer = Form1.db.TableAssornment;
            deviceIQuer = Form1.db.TableDevices;

            bool hasElements = assortIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Assortments");


            //відбираємо склад для добавлення в таблицю Assortment. Вибірку робимо з таблиці Storages...
            //...Id елемента comboBoxStorage повинен відповідати Id поля таблиці storages
            var stor = storageIQuer.Where(d => string.Equals(d.Name, comboBoxStorage.Text)).ToList();
            storage = stor.Single();


            var categ = categoryIQuer.Where(d => String.Equals(d.Name, comboBoxCategory.Text)).ToList();
            category = categ.Single();


            //відбираємо девайс для добавлення в таблицю Assortment. Вибірку робимо з таблиці Devices...
            //...текст елемента textBoxGoods повинен бути ідентичний полю Name шуканого елемента таблицы Devices
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text) & d.IdCategory == category.Id).ToList();
            device = dev.Single();

            

            //var devForPrice = deviceIQuer.Where(d => d.Id == comboBoxGoods.SelectedIndex + 1).ToList();
            //Device deviceForPrice = devForPrice.Single();

            //проходимось по таблиці асортименту
            foreach (Assortment assort in assortIQuer)
            {
// якщо Id девайса зпівпадає з Id вибраного девайса  і якщо Id скзала зпівпадає з Id вибраного склада 
                if (assort.IdDevice == device.Id & assort.IdStorage == storage.Id)
                {
                    //тоді ставимо наш прапорець у положення false...
                    flag = false;
                    //...і просто акумулюємо кількість новоприбулих девайсів, не створюючи нового рядка
                    assort.Amount = assort.Amount + (int)numericUpDownAmount.Value;
                    break;
                }
            }

            //Якщо після проходження таблиці наш прапорець залишився в положенні true 
            //...тоді добавляємо новий запис в таблицю асортименту
            if (flag == true)
            {
                Form1.db.TableAssornment.Add(new Assortment()
                {
                    IdDevice = device.Id,//textBoxGoods.AutoCompleteCustomSource.IndexOf(textBoxGoods.SelectedText),
                    //IdStorage = comboBoxStorage.SelectedIndex + 1,
                    IdStorage = storage.Id,
                    Describe = device.Descript,  //Convert.ToString(description),
                    Amount = (int)numericUpDownAmount.Value,
                    Price = device.Price
                }
                );
                
            }
            Form1.db.SaveChanges();
        }

        private void _Add_Delivery_To_Repository_Assortment()
        {
            //IEnumerable<Device> deviceIEnum = Form1.db.TableDevices;
            //var dev = deviceIEnum.Where(d => d.Id == (int)comboBoxGoods.SelectedValue).ToList();
            //Device device = dev.Single();
            //string description = device.Descript;

            flag = true;
            storageIQuer = Form1.db.TableStorages;
            //assortIQuer = Form1.db.TableAssornment;
            deviceIQuer = Form1.db.TableDevices;

            var stor = storageIQuer.Where(d => string.Equals(d.Name, comboBoxStorage.Text)).ToList();
            storage = stor.Single();

            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text)).ToList();
            device = dev.Single();

            //змінюємо вже знайдений запис в таблиці асортименту
            foreach (Assortment assort in Form1.tempRepozit.ListAssortment)
            {
                if (assort.IdDevice == device.Id & assort.IdStorage == storage.Id)
                {
                    flag = false;
                    assort.Amount = assort.Amount + (int)numericUpDownAmount.Value;
                    break;
                }
            }

            if (flag == true)
            {
                Max = assortIQuer.Max(d => d.Id);

                Form1.tempRepozit.ListAssortment.Add(new Assortment()
                {
                    Id = Max,
                    IdDevice = device.Id,
                    IdStorage = storage.Id,
                    Describe = device.Descript,
                    Amount = (int)numericUpDownAmount.Value,
                    Price = device.Price
                }
                  );
            }
        }

        private void _Add_Delivery_To_DataGridView_Main()
        {
            Max = assortIQuer.Max(d => d.Id);
            //if (Program.ff.MainDataGridView.Rows[0].Cells[1].ToString() == String.Empty)
            if (Program.ff.MainDataGridView.Rows.Count == 0 )
            {
                Program.ff.MainDataGridView.Rows.Add(Max, textBoxGoods.Text, comboBoxCategory.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, device.Price);
                return;
            }

            flag = true;
            for (int i = 0; i < Program.ff.MainDataGridView.Rows.Count; i++)
            {
                if (string.Equals(textBoxGoods.Text, Program.ff.MainDataGridView.Rows[i].Cells[1].Value.ToString()) & string.Equals(comboBoxStorage.Text, Program.ff.MainDataGridView.Rows[i].Cells[3].Value.ToString()))
                {
                    Program.ff.MainDataGridView.Rows[i].Cells[5].Value = Int32.Parse(Program.ff.MainDataGridView.Rows[i].Cells[5].Value.ToString()) + Int32.Parse(numericUpDownAmount.Value.ToString());
                    flag = false;
                    break;
                }
            }

            if (flag == true)
                 Program.ff.MainDataGridView.Rows.Add(Max, textBoxGoods.Text, comboBoxCategory.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, device.Price);
        }

        private void _Add_Delivery_To_Base_DeliveryesArchiv()
        {
            providerIQuer = Form1.db.TableProviders;
            delivArchIQuer = Form1.db.TableDeliveryesArchiv; 

            bool hasElements = delivArchIQuer.Any();
            if (hasElements == false)
                Form1.db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.DeliveryesArchivs");

            //відбираємо постачальника для добавлення в таблицю DeliveryesArchiv. Вибірку робимо з таблиці Providers...
            //...Id елемента comboBoxProvider повинен відповідати Id поля таблиці Providers
            var prov = providerIQuer.Where(d => string.Equals(d.Name, comboBoxProvider.Text)).ToList();
            provider = prov.Single();


            Form1.db.TableDeliveryesArchiv.Add(new DeliveryesArchiv()
            {
                IdProvider = provider.Id,
                IdDevice = device.Id,
                IdStorage = storage.Id,
                Describe = device.Descript,  //Convert.ToString(description),
                Amount = (int)numericUpDownAmount.Value,
                Price = (int)numericUpDownPrice.Value,
                Date = dateTimePickerDelivery.Value
            }
               );
            Form1.db.SaveChanges();

        }

        private void _Add_Delivery_To_DataGridView_Archiv()
        {
            Max = delivArchIQuer.Max(d => d.Id);
            this.dataGrViewDeliveryArchiv.Rows.Add(Max, this.dataGrViewDeliveryArchiv.Rows.Count+1, textBoxGoods.Text, comboBoxProvider.Text, comboBoxStorage.Text, device.Descript, numericUpDownAmount.Value, numericUpDownPrice.Value, dateTimePickerDelivery.Value, comboBoxCategory.Text);
        }


        //private void comboBoxGoods_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //tempComboGoods = (int)comboBoxGoods.SelectedValue;
        //}

        private void comboBoxStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tempComboStorage = (int)comboBoxStorage.SelectedValue;
        }

        private void comboBoxProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tempCompoProvider = (int)comboBoxProvider.SelectedValue;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        //подія зміни вмісту текстбокса назв девайсів при зміні значення комбобокс категорій девайсів 
        private void comboBoxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //source.Clear();

            //foreach (Device deviceTemp in devIQuerForTextBox)
            //{
            //    if(deviceTemp.IdCategory == comboBoxCategory.SelectedIndex+1)
            //       sourseForBaseRepoz.Add(deviceTemp.Name);
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



        //функція обробки датигрідвью на перевірку "застарілості" рядків
        private void _DataGridArchiv_Process(Object sender, EventArgs e)
        {
            if (dataGrViewDeliveryArchiv.Rows.Count > 0)
            {
                currentDateTime = DateTime.Now;
                for (int i = 0; i < dataGrViewDeliveryArchiv.RowCount; i++)
                {
                    dateTimeOfDelivery = DateTime.Parse(dataGrViewDeliveryArchiv.Rows[i].Cells[8].Value.ToString());
                    timeSpanTemp = currentDateTime.Subtract(dateTimeOfDelivery);
                    if (timeSpanTemp > timeActivityOfRow & dataGrViewDeliveryArchiv.Rows[i].ReadOnly == false)
                        dataGrViewDeliveryArchiv.Rows[i].ReadOnly = true;
                }
            }

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.busnLogicDelivery.ChangeDeliveryInBaseDeliveryesArchiv += _Change_Delivery_In_Base_DeliveryesArchiv;
            this.busnLogicDelivery.ChangeDeliveryInBaseAssortment += _Change_Delivery_In_Base_Assortment;
            this.busnLogicDelivery.ChangeDeliveryInDataGridViewArchiv += _Change_Delivery_In_DataGridViev_Archiv;
            this.busnLogicDelivery.ChangeDeliveryInDataGridViewMain += _Change_Delivery_In_DataGridView_Main;
            this.busnLogicDelivery.ChangeDeliveryInRepozitoryAssortment += _Change_Delivery_In_Repozitory_Assortment;


            this.busnLogicDelivery.ChangeDelivery();

            this.busnLogicDelivery.ChangeDeliveryInBaseDeliveryesArchiv -= _Change_Delivery_In_Base_DeliveryesArchiv;
            this.busnLogicDelivery.ChangeDeliveryInBaseAssortment -= _Change_Delivery_In_Base_Assortment;
            this.busnLogicDelivery.ChangeDeliveryInDataGridViewArchiv -= _Change_Delivery_In_DataGridViev_Archiv;
            this.busnLogicDelivery.ChangeDeliveryInDataGridViewMain -= _Change_Delivery_In_DataGridView_Main;
            this.busnLogicDelivery.ChangeDeliveryInRepozitoryAssortment -= _Change_Delivery_In_Repozitory_Assortment;
        }

        private void _Change_Delivery_In_Base_DeliveryesArchiv()
        {
            deviceIQuer = Form1.db.TableDevices;
            categoryIQuer = Form1.db.TableCategoryes;

            var categ = categoryIQuer.Where(d => String.Equals(d.Name, comboBoxCategory.Text)).ToList();
            category = categ.Single();
            //відбираємо новий девайс
            var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text) & d.Id == category.Id).ToList();
            device = dev.Single();

            //в змінну number помістимо Id запису
          
                number = Convert.ToInt32(dataGrViewDeliveryArchiv.CurrentRow.Cells[0].Value);
                deliveryesArchiv = Form1.db.TableDeliveryesArchiv.Where(o => o.Id == number).FirstOrDefault();
                deliveryesArchiv.IdDevice = device.Id;
                deliveryesArchiv.IdProvider = comboBoxProvider.SelectedIndex + 1;
                deliveryesArchiv.IdStorage = comboBoxStorage.SelectedIndex + 1;
                deliveryesArchiv.Describe = device.Descript;
                deliveryesArchiv.Amount = Convert.ToInt32(numericUpDownAmount.Value);
                deliveryesArchiv.Price = Convert.ToInt32(numericUpDownPrice.Value);
                deliveryesArchiv.Date = dateTimePickerDelivery.Value;

                Form1.db.SaveChanges();
        }

        public void _Change_Delivery_In_Base_Assortment()
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
                    //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == oldDevice.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount - oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно збільшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
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
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
                        newRowId = newAssortment.Id;
                    }
                    //Form1.db.SaveChanges();
                }
                //якщо склади змінювалися
                else
                {
                    //відбираємо рядки, в яких проведемо зміни
                    //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == oldDevice.Id & o.IdStorage == oldStorage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount - oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно збільшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
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
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
                        newRowId = newAssortment.Id;
                    }
                    //Form1.db.SaveChanges();
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
                    newAssortment.Amount = Convert.ToInt32(newAssortment.Amount - oldAmount + newAmount);
                    newRowId = newAssortment.Id;

                    //Form1.db.SaveChanges();
                }
                //якщо склади змінювалися
                else
                {
                    //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                    oldAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == oldStorage.Id).FirstOrDefault();
                    oldAssortment.Amount = Convert.ToInt32(oldAssortment.Amount - oldAmount);
                    oldRowId = oldAssortment.Id;
                    //потім рядок, в якому кількість девайсів потрібно збільшити:
                    newAssortment = Form1.db.TableAssornment.Where(o => o.IdDevice == device.Id & o.IdStorage == storage.Id).FirstOrDefault();
                    if (newAssortment != null)
                    {
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
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
                        newAssortment.Amount = Convert.ToInt32(newAssortment.Amount + newAmount);
                        newRowId = newAssortment.Id;
                    }

                    //Form1.db.SaveChanges();
                }
            }

            Form1.db.SaveChanges();
        }

        public void _Change_Delivery_In_DataGridViev_Archiv()
        {
            //вибираємо з таблиці вказаний нами девайс, щоб пізніше отримати його опис Descript
            //deviceIQuer = Form1.db.TableDevices;
            //var dev = deviceIQuer.Where(d => String.Equals(d.Name, textBoxGoods.Text)).ToList();
            //device = dev.Single();


            dataGrViewDeliveryArchiv[2, row].Value = textBoxGoods.Text;
            dataGrViewDeliveryArchiv[3, row].Value = comboBoxProvider.Text;
            dataGrViewDeliveryArchiv[4, row].Value = comboBoxStorage.Text;
            dataGrViewDeliveryArchiv[5, row].Value = device.Descript;
            dataGrViewDeliveryArchiv[6, row].Value = numericUpDownAmount.Value;
            dataGrViewDeliveryArchiv[7, row].Value = numericUpDownPrice.Value;
            dataGrViewDeliveryArchiv[8, row].Value = dateTimePickerDelivery.Value;
            dataGrViewDeliveryArchiv[9, row].Value = comboBoxCategory.Text;
        }

        public void _Change_Delivery_In_DataGridView_Main()
        {
            //в DataGridView нумерація рядків починається з нуля, в таблиці - з одиниці
 
            //якщо девайс змінювався
            if (oldDevice.Id != device.Id)
            {
                //якщо склад не змінювався
                if (oldStorage.Id == storage.Id)
                {
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) + newAmount;
                    }
                    else
                    {
                        Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        //Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount + newAmount;
                        Program.ff.MainDataGridView[6, newRowId - 1].Value = device.Price;
                    }
                }
                //якщо склад  змінювався
                else
                {
                    if (flag == true)
                    {
                        //відбираємо рядки, в яких проведемо зміни
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) + newAmount;
                    }
                    else
                    {
                        Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount + newAmount;
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
                    Program.ff.MainDataGridView[5, newRowId-1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId-1].Value) - oldAmount + newAmount;
                }
                //якщо склад змінювався
                else
                {
                    if (flag == true)
                    {
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                        Program.ff.MainDataGridView[5, oldRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount;
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, newRowId - 1].Value) + newAmount;
                    }
                    else
                    {
                        //Program.ff.MainDataGridView[1, newRowId - 1].Value = textBoxGoods.Text;
                        //Program.ff.MainDataGridView[2, newRowId - 1].Value = comboBoxCategory.Text;
                        Program.ff.MainDataGridView[3, newRowId - 1].Value = comboBoxStorage.Text;
                        //Program.ff.MainDataGridView[4, newRowId - 1].Value = device.Descript;
                        Program.ff.MainDataGridView[5, newRowId - 1].Value = Convert.ToDecimal(Program.ff.MainDataGridView[5, oldRowId - 1].Value) - oldAmount + newAmount;
                        //Program.ff.MainDataGridView[6, newRowId - 1].Value = device.Price;
                    }
                }
            }
        }

        public void _Change_Delivery_In_Repozitory_Assortment()
        {
            //var temp1 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == oldRowId).ToList();
            //Assortment tempAssort1 = temp1.Single();
            //int indexElOldRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort1);

            //var temp2 = Form1.tempRepozit.ListAssortment.Where(d => d.Id == newRowId).ToList();
            //Assortment tempAssort2 = temp2.Single();
            //int indexElNewRow = Form1.tempRepozit.ListAssortment.IndexOf(tempAssort2);


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
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount - Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(newAmount);

                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(oldAmount) + Convert.ToInt32(newAmount);
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
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:

                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount - Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdDevice = device.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Describe = device.Descript;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[oldRowId - 1].Amount - Convert.ToInt32(oldAmount) + Convert.ToInt32(newAmount);
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
                    Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(oldAmount) + Convert.ToInt32(newAmount);
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
                        //спочатку рядок, в якому кількість девайсів потрібно зменшити:
                        Form1.tempRepozit.ListAssortment[indexElOldRow].Amount = Form1.tempRepozit.ListAssortment[indexElOldRow].Amount - Convert.ToInt32(oldAmount);
                        //потім рядок, в якому кількість девайсів потрібно збільшити:
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount + Convert.ToInt32(newAmount);
                    }
                    else
                    {
                        Form1.tempRepozit.ListAssortment[indexElNewRow].IdStorage = storage.Id;
                        Form1.tempRepozit.ListAssortment[indexElNewRow].Amount = Form1.tempRepozit.ListAssortment[indexElNewRow].Amount - Convert.ToInt32(oldAmount) + Convert.ToInt32(newAmount);
                    }
                }

            }

        }

            private void dataGrViewDeliveryArchiv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGrViewDeliveryArchiv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            row = e.RowIndex;

            comboBoxCategory.Text = this.dataGrViewDeliveryArchiv[9, row].Value.ToString();
            textBoxGoods.Text = this.dataGrViewDeliveryArchiv[2, row].Value.ToString();
            comboBoxProvider.Text = this.dataGrViewDeliveryArchiv[3, row].Value.ToString();
            comboBoxStorage.Text = this.dataGrViewDeliveryArchiv[4, row].Value.ToString();
            numericUpDownAmount.Value = Convert.ToDecimal(this.dataGrViewDeliveryArchiv[6, row].Value.ToString());
            numericUpDownPrice.Value = Convert.ToDecimal(this.dataGrViewDeliveryArchiv[7, row].Value.ToString());
            dateTimePickerDelivery.Value = Convert.ToDateTime(this.dataGrViewDeliveryArchiv[8, row].Value.ToString());

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
            this.busnLogicDelivery.DeleteDeliveryFromBaseDeliveryesArchiv += _Delete_Delivery_From_BaseDeliveryesArchiv;
            this.busnLogicDelivery.DeleteDeliveryFromBaseAssortment += _Delete_Delivery_From_BaseAssortment;
            this.busnLogicDelivery.DeleteDeliveryFromRepozitoryAssortment += _Delete_Delivery_From_RepozitoryAssortment;
            this.busnLogicDelivery.DeleteDeliveryFromDataGridViewArchiv += _Delete_Delivery_From_DataGridViewArchiv;
            this.busnLogicDelivery.DeleteDeliveryFromDataGridViewMain += _Delete_Delivery_From_DataGridViewMain;


            this.busnLogicDelivery.DeleteDelivery();

            this.busnLogicDelivery.DeleteDeliveryFromBaseDeliveryesArchiv -= _Delete_Delivery_From_BaseDeliveryesArchiv;
            this.busnLogicDelivery.DeleteDeliveryFromBaseAssortment -= _Delete_Delivery_From_BaseAssortment;
            this.busnLogicDelivery.DeleteDeliveryFromRepozitoryAssortment -= _Delete_Delivery_From_RepozitoryAssortment;
            this.busnLogicDelivery.DeleteDeliveryFromDataGridViewArchiv -= _Delete_Delivery_From_DataGridViewArchiv;
            this.busnLogicDelivery.DeleteDeliveryFromDataGridViewMain -= _Delete_Delivery_From_DataGridViewMain;
        }

        private void _Delete_Delivery_From_BaseDeliveryesArchiv()
        {
            ////в змінну number помістимо Id запису
            number = Convert.ToInt32(dataGrViewDeliveryArchiv.Rows[row].Cells[0].Value);
            deliveryesArchiv = Form1.db.TableDeliveryesArchiv.Where(o => o.Id == number).FirstOrDefault();
            Form1.db.TableDeliveryesArchiv.Remove(deliveryesArchiv);
            Form1.db.SaveChanges();
        }

        private void _Delete_Delivery_From_BaseAssortment()
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
            assortment.Amount = assortment.Amount - Convert.ToInt32(oldAmount);
            //oldAmount - зміна, в яку записано значення кількості девайсів відразу ж після вибору рядка в DataGridView
            Form1.db.SaveChanges();
        }

        private void _Delete_Delivery_From_RepozitoryAssortment()
        {
            for (int i = 0; i < Form1.tempRepozit.ListAssortment.Count; i++)
            {
                if (Form1.tempRepozit.ListAssortment[i].IdDevice == device.Id & Form1.tempRepozit.ListAssortment[i].IdStorage == storage.Id)
                {
                    Form1.tempRepozit.ListAssortment[i].Amount = Form1.tempRepozit.ListAssortment[i].Amount - Convert.ToInt32(oldAmount);
                    break;
                }
            }
        }

        private void _Delete_Delivery_From_DataGridViewArchiv()
        {
            //number = dataGrViewDeliveryArchiv.CurrentRow.Index;
            dataGrViewDeliveryArchiv.Rows.RemoveAt(row);

            // якщо dataGrViewDeliveryArchiv.Rows.Count == number  -  тоді вибраний рядок був останнім
            //якщо наш рядок(number) не був останнім... 
            if (dataGrViewDeliveryArchiv.Rows.Count != row)
            {
                for (int i = 0; i < dataGrViewDeliveryArchiv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGrViewDeliveryArchiv.Rows[i].Cells[1].Value) > row)
                        dataGrViewDeliveryArchiv.Rows[i].Cells[1].Value = Convert.ToInt32(dataGrViewDeliveryArchiv.Rows[i].Cells[1].Value) - 1;
                }
            }
        }

        private void _Delete_Delivery_From_DataGridViewMain()
        {
            for (int i = 0; i < Program.ff.MainDataGridView.Rows.Count; i++)
            {
                if (String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[1].Value, device.Name) & String.Equals(Program.ff.MainDataGridView.Rows[i].Cells[3].Value, storage.Name))
                {
                    Program.ff.MainDataGridView.Rows[i].Cells[5].Value = Convert.ToInt32(Program.ff.MainDataGridView.Rows[i].Cells[5].Value) - Convert.ToInt32(oldAmount);
                    break;
                }
            }
        }

    }
}
