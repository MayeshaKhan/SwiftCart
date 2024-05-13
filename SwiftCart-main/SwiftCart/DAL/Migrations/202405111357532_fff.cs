namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductOrder_Id", "dbo.ProductOrders");
            DropForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id1" });
            DropIndex("dbo.Orders", new[] { "ProductOrder_Id" });
            DropColumn("dbo.ProductOrders", "Order_Id");
            RenameColumn(table: "dbo.ProductOrders", name: "Order_Id1", newName: "Order_Id");
            AddColumn("dbo.ProductOrders", "ProductOrder_Id", c => c.Int());
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductOrders", "Order_Id");
            CreateIndex("dbo.ProductOrders", "ProductOrder_Id");
            AddForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders", "Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "ProductOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductOrder_Id", c => c.Int());
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "ProductOrder_Id", "dbo.ProductOrders");
            DropIndex("dbo.ProductOrders", new[] { "ProductOrder_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int());
            DropColumn("dbo.ProductOrders", "ProductOrder_Id");
            RenameColumn(table: "dbo.ProductOrders", name: "Order_Id", newName: "Order_Id1");
            AddColumn("dbo.ProductOrders", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProductOrder_Id");
            CreateIndex("dbo.ProductOrders", "Order_Id1");
            CreateIndex("dbo.ProductOrders", "Order_Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id1", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "ProductOrder_Id", "dbo.ProductOrders", "Id");
        }
    }
}
