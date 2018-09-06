namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryesArchivs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdCategory = c.Int(nullable: false),
                        IdProvider = c.Int(nullable: false),
                        IdStorage = c.Int(nullable: false),
                        Describe = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesArchivs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdCategory = c.Int(nullable: false),
                        IdProvider = c.Int(nullable: false),
                        IdStorage = c.Int(nullable: false),
                        Describe = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesArchivs");
            DropTable("dbo.Categories");
            DropTable("dbo.DeliveryesArchivs");
        }
    }
}
