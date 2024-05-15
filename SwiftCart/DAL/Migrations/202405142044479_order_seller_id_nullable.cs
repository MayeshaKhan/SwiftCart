namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_seller_id_nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Seller_id", "dbo.Sellers");
            DropIndex("dbo.Orders", new[] { "Seller_id" });
            AlterColumn("dbo.Orders", "Seller_id", c => c.Int());
            CreateIndex("dbo.Orders", "Seller_id");
            AddForeignKey("dbo.Orders", "Seller_id", "dbo.Sellers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Seller_id", "dbo.Sellers");
            DropIndex("dbo.Orders", new[] { "Seller_id" });
            AlterColumn("dbo.Orders", "Seller_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Seller_id");
            AddForeignKey("dbo.Orders", "Seller_id", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
