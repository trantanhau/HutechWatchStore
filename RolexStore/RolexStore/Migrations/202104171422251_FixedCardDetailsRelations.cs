namespace RolexStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCardDetailsRelations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CartDetail");
            AddPrimaryKey("dbo.CartDetail", new[] { "CartID", "ProductID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CartDetail");
            AddPrimaryKey("dbo.CartDetail", "CartID");
        }
    }
}
