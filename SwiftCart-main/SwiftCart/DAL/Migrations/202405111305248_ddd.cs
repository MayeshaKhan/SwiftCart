namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "Order_Id" });
            AddColumn("dbo.ProductOrders", "Order_Id1", c => c.Int());
            CreateIndex("dbo.ProductOrders", "Order_Id1");
            AddForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders", "Id");
            DropColumn("dbo.Orders", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Order_Id", c => c.Int());
            DropForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id1" });
            DropColumn("dbo.ProductOrders", "Order_Id1");
            CreateIndex("dbo.Orders", "Order_Id");
            AddForeignKey("dbo.Orders", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
