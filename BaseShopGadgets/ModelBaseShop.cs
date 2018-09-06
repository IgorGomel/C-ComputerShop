namespace BaseShopGadgets
{
    
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelBaseShop : DbContext
    {
        // Контекст настроен для использования строки подключения "ModelBaseShop" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "BaseShopGadgets.ModelBaseShop" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ModelBaseShop" 
        // в файле конфигурации приложения.
        public ModelBaseShop()
            : base("name=ModelBaseShop")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Storage> TableStorages { get; set; }
        public virtual DbSet<Provider> TableProviders { get; set; }
        public virtual DbSet<Device> TableDevices { get; set; }
        public virtual DbSet<Category> TableCategoryes { get; set; }
        public virtual DbSet<Discount> TableDiscounts { get; set; }
        public virtual DbSet<VipClient> TableVipClients { get; set; }
        public virtual DbSet<Assortment> TableAssornment { get; set; }
        public virtual DbSet<DeliveryesArchiv> TableDeliveryesArchiv { get; set; }
        public virtual DbSet<SalesArchiv> TableySalesArchiv { get; set; }

        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}