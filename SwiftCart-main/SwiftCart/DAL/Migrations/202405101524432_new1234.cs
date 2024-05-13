namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1234 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "ProductOrder_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AlterColumn("dbo.ProductOrders", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductOrders", "Product_Id");
            CreateIndex("dbo.ProductOrders", "Order_Id");
            AddForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductOrders", "ProductOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOrders", "ProductOrder_Id", c => c.Int());
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int());
            AlterColumn("dbo.ProductOrders", "Product_Id", c => c.Int());
            CreateIndex("dbo.ProductOrders", "Order_Id");
            CreateIndex("dbo.ProductOrders", "Product_Id");
            CreateIndex("dbo.ProductOrders", "ProductOrder_Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders", "Id");
        }
    }
}
