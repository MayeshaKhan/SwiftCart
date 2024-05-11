namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            AddColumn("dbo.ProductOrders", "Order_Id1", c => c.Int());
            AddColumn("dbo.Orders", "ProductOrder_Id", c => c.Int());
            CreateIndex("dbo.ProductOrders", "Order_Id1");
            CreateIndex("dbo.Orders", "ProductOrder_Id");
            AddForeignKey("dbo.Orders", "ProductOrder_Id", "dbo.ProductOrders", "Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ProductOrder_Id", "dbo.ProductOrders");
            DropIndex("dbo.Orders", new[] { "ProductOrder_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id1" });
            DropColumn("dbo.Orders", "ProductOrder_Id");
            DropColumn("dbo.ProductOrders", "Order_Id1");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
