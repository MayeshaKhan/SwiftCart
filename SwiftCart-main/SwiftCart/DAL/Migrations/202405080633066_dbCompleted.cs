namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbCompleted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.BranchProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Branch_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        Total_price = c.String(nullable: false),
                        Order_datetime = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Seller_id = c.Int(nullable: false),
                        Branch_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.Seller_id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Seller_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Agents", "Username", c => c.String());
            AddColumn("dbo.Agents", "Password", c => c.String());
            AlterColumn("dbo.Branches", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Seller_id", "dbo.Sellers");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.BranchProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.BranchProducts", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Orders", new[] { "Seller_id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.BranchProducts", new[] { "Product_Id" });
            DropIndex("dbo.BranchProducts", new[] { "Branch_Id" });
            DropIndex("dbo.Products", new[] { "Branch_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AlterColumn("dbo.Branches", "Name", c => c.String());
            DropColumn("dbo.Agents", "Password");
            DropColumn("dbo.Agents", "Username");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Categories");
            DropTable("dbo.BranchProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Admins");
        }
    }
}
