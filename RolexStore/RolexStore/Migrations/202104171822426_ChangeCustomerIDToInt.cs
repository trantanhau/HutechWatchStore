namespace RolexStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerIDToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartDetail", "CartID", "dbo.Cart");
            DropForeignKey("dbo.Cart", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Cart", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Cart");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Cart", "CartID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cart", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "CustomerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cart", "CartID");
            AddPrimaryKey("dbo.Customer", "CustomerID");
            CreateIndex("dbo.Cart", "CustomerID");
            AddForeignKey("dbo.CartDetail", "CartID", "dbo.Cart", "CartID");
            AddForeignKey("dbo.Cart", "CustomerID", "dbo.Customer", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.CartDetail", "CartID", "dbo.Cart");
            DropIndex("dbo.Cart", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Customer");
            DropPrimaryKey("dbo.Cart");
            AlterColumn("dbo.Customer", "CustomerID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Cart", "CustomerID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Cart", "CartID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customer", "CustomerID");
            AddPrimaryKey("dbo.Cart", "CartID");
            CreateIndex("dbo.Cart", "CustomerID");
            AddForeignKey("dbo.Cart", "CustomerID", "dbo.Customer", "CustomerID");
            AddForeignKey("dbo.CartDetail", "CartID", "dbo.Cart", "CartID");
        }
    }
}
