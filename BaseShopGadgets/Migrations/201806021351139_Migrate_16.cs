namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assortments", "IdDevice", c => c.Int(nullable: false));
            AddColumn("dbo.DeliveryesArchivs", "IdDevice", c => c.Int(nullable: false));
            AddColumn("dbo.Devices", "IdDeviceType", c => c.Int(nullable: false));
            AddColumn("dbo.SalesArchivs", "IdDevice", c => c.Int(nullable: false));
            DropColumn("dbo.Assortments", "Name");
            DropColumn("dbo.Assortments", "IdCategory");
            DropColumn("dbo.DeliveryesArchivs", "Name");
            DropColumn("dbo.DeliveryesArchivs", "IdCategory");
            DropColumn("dbo.Devices", "IdCategory");
            DropColumn("dbo.SalesArchivs", "Name");
            DropColumn("dbo.SalesArchivs", "IdCategory");
            DropColumn("dbo.SalesArchivs", "IdProvider");
            //DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SalesArchivs", "IdProvider", c => c.Int(nullable: false));
            AddColumn("dbo.SalesArchivs", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.SalesArchivs", "Name", c => c.String());
            AddColumn("dbo.Devices", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.DeliveryesArchivs", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.DeliveryesArchivs", "Name", c => c.String());
            AddColumn("dbo.Assortments", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Assortments", "Name", c => c.String());
            DropColumn("dbo.SalesArchivs", "IdDevice");
            DropColumn("dbo.Devices", "IdDeviceType");
            DropColumn("dbo.DeliveryesArchivs", "IdDevice");
            DropColumn("dbo.Assortments", "IdDevice");
            DropTable("dbo.DeviceTypes");
        }
    }
}
