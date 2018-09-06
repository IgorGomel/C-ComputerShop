namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_18 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categoryes", newName: "Categories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Categories", newName: "Categoryes");
        }
    }
}
