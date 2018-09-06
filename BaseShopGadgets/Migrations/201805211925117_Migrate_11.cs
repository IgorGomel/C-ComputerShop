namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_11 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Assortments");
            DropPrimaryKey("dbo.DeliveryesArchivs");
            DropPrimaryKey("dbo.Devices");
            DropPrimaryKey("dbo.Discounts");
            DropPrimaryKey("dbo.Providers");
            DropPrimaryKey("dbo.Storages");
            DropPrimaryKey("dbo.VipClients");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.SalesArchivs");
            AlterColumn("dbo.Assortments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DeliveryesArchivs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Devices", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Discounts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Providers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Storages", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.VipClients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SalesArchivs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Assortments", "Id");
            AddPrimaryKey("dbo.DeliveryesArchivs", "Id");
            AddPrimaryKey("dbo.Devices", "Id");
            AddPrimaryKey("dbo.Discounts", "Id");
            AddPrimaryKey("dbo.Providers", "Id");
            AddPrimaryKey("dbo.Storages", "Id");
            AddPrimaryKey("dbo.VipClients", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.SalesArchivs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SalesArchivs");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.VipClients");
            DropPrimaryKey("dbo.Storages");
            DropPrimaryKey("dbo.Providers");
            DropPrimaryKey("dbo.Discounts");
            DropPrimaryKey("dbo.Devices");
            DropPrimaryKey("dbo.DeliveryesArchivs");
            DropPrimaryKey("dbo.Assortments");
            AlterColumn("dbo.SalesArchivs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.VipClients", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Storages", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Providers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Discounts", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DeliveryesArchivs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Assortments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SalesArchivs", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.VipClients", "Id");
            AddPrimaryKey("dbo.Storages", "Id");
            AddPrimaryKey("dbo.Providers", "Id");
            AddPrimaryKey("dbo.Discounts", "Id");
            AddPrimaryKey("dbo.Devices", "Id");
            AddPrimaryKey("dbo.DeliveryesArchivs", "Id");
            AddPrimaryKey("dbo.Assortments", "Id");
        }
    }
}
