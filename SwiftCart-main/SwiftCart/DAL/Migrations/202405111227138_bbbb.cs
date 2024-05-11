namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbbb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id1" });
            AddColumn("dbo.Orders", "Order_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Order_Id");
            AddForeignKey("dbo.Orders", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.ProductOrders", "Order_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOrders", "Order_Id1", c => c.Int());
            DropForeignKey("dbo.Orders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "Order_Id" });
            DropColumn("dbo.Orders", "Order_Id");
            CreateIndex("dbo.ProductOrders", "Order_Id1");
            AddForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders", "Id");
        }
    }
}
