namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_1_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assortments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDevice = c.Int(nullable: false),
                        IdProvider = c.Int(nullable: false),
                        IdStorage = c.Int(nullable: false),
                        Describe = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assortments");
        }
    }
}
