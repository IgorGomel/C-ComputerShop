namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assortments", "Name", c => c.String());
            AddColumn("dbo.Assortments", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Devices", "IdCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Assortments", "IdDevice");
            DropColumn("dbo.Devices", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Category", c => c.String());
            AddColumn("dbo.Assortments", "IdDevice", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "IdCategory");
            DropColumn("dbo.Assortments", "IdCategory");
            DropColumn("dbo.Assortments", "Name");
        }
    }
}
