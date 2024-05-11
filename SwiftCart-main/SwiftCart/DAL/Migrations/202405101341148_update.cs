namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int());
            CreateIndex("dbo.ProductOrders", "Order_Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            AlterColumn("dbo.ProductOrders", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductOrders", "Order_Id");
            AddForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
