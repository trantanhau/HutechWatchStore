namespace RolexStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDetail",
                c => new
                    {
                        CartID = c.Int(nullable: false),
                        ProductID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Cart", t => t.CartID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.CartID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartID = c.Int(nullable: false),
                        CustomerID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CStateID = c.Int(nullable: false),
                        PaymentMethodID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.CartState", t => t.CStateID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodID)
                .Index(t => t.CustomerID)
                .Index(t => t.CStateID)
                .Index(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.CartState",
                c => new
                    {
                        CStateID = c.Int(nullable: false),
                        CStateDescription = c.String(),
                    })
                .PrimaryKey(t => t.CStateID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false),
                        PaymentMethodName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        ProductImg = c.String(nullable: false, maxLength: 50),
                        CollectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Collection", t => t.CollectionID)
                .ForeignKey("dbo.Size", t => t.SizeID)
                .ForeignKey("dbo.WatchType", t => t.TypeID)
                .Index(t => t.TypeID)
                .Index(t => t.SizeID)
                .Index(t => t.CollectionID);
            
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        CollectionID = c.Int(nullable: false),
                        CollectionName = c.String(nullable: false, maxLength: 69),
                    })
                .PrimaryKey(t => t.CollectionID);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        SizeID = c.Int(nullable: false),
                        SizeValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.WatchType",
                c => new
                    {
                        TypeID = c.Int(nullable: false),
                        TypeName = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "TypeID", "dbo.WatchType");
            DropForeignKey("dbo.Product", "SizeID", "dbo.Size");
            DropForeignKey("dbo.Product", "CollectionID", "dbo.Collection");
            DropForeignKey("dbo.CartDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Cart", "PaymentMethodID", "dbo.PaymentMethod");
            DropForeignKey("dbo.Cart", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Cart", "CStateID", "dbo.CartState");
            DropForeignKey("dbo.CartDetail", "CartID", "dbo.Cart");
            DropIndex("dbo.Product", new[] { "CollectionID" });
            DropIndex("dbo.Product", new[] { "SizeID" });
            DropIndex("dbo.Product", new[] { "TypeID" });
            DropIndex("dbo.Cart", new[] { "PaymentMethodID" });
            DropIndex("dbo.Cart", new[] { "CStateID" });
            DropIndex("dbo.Cart", new[] { "CustomerID" });
            DropIndex("dbo.CartDetail", new[] { "ProductID" });
            DropIndex("dbo.CartDetail", new[] { "CartID" });
            DropTable("dbo.WatchType");
            DropTable("dbo.Size");
            DropTable("dbo.Collection");
            DropTable("dbo.Product");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Customer");
            DropTable("dbo.CartState");
            DropTable("dbo.Cart");
            DropTable("dbo.CartDetail");
        }
    }
}
