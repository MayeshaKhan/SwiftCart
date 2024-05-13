namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchProductData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Total_price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Total_price", c => c.String(nullable: false));
        }
    }
}
