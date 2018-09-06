namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_19 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assortments", "IdProvider");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assortments", "IdProvider", c => c.Int(nullable: false));
        }
    }
}
