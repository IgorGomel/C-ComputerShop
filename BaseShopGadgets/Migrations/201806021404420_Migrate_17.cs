namespace BaseShopGadgets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoryes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Devices", "IdCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "IdDeviceType");
            DropTable("dbo.DeviceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Devices", "IdDeviceType", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "IdCategory");
            DropTable("dbo.Categoryes");
        }
    }
}
