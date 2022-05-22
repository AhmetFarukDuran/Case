namespace ShopsRUsCase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAdi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        PersonelID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PersonelID = c.Int(),
                        OrdersDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Personel",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        Name = c.String(),
                        IsStoreStaff = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        StockAmount = c.Int(nullable: false),
                        IsShoppingCentre = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Personels");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
