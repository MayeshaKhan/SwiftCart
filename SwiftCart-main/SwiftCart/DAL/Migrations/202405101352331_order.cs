namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AddColumn("dbo.ProductOrders", "ProductOrder_Id", c => c.Int());
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductOrders", "Order_Id");
            CreateIndex("dbo.ProductOrders", "ProductOrder_Id");
            AddForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders", "Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders");
            DropIndex("dbo.ProductOrders", new[] { "ProductOrder_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int());
            DropColumn("dbo.ProductOrders", "ProductOrder_Id");
            CreateIndex("dbo.ProductOrders", "Order_Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
