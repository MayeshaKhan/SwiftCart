namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.SwiftCartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.SwiftCartContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*for (int i = 1; i <= 5; i++)
            {

                context.Categories.AddOrUpdate(new EF.Models.Category
                {
                    Id = i,
                    Name = "category-" + i
                });
            }
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                context.Products.AddOrUpdate(new EF.Models.Product
                {
                    Id = i,
                    Name = "Product" + i,
                    Price = random.Next(1, 15) * 100,

                    Category_Id = random.Next(1, 6),
                   
                });

            }*/
           /* Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {

                context.BranchProducts.AddOrUpdate(new EF.Models.BranchProduct
                {
                    Id = i,
                    Quantity = random.Next(10, 600),
                    Branch_Id = random.Next(1, 5),
                    Product_Id = random.Next(1, 11)

                });
            }*/
            

            /*context.Admins.AddOrUpdate(new EF.Models.Admin
            {
                Id = 1,
                Name = "Rahad",
                Username = "admin",
                Password = "123"

            });

            context.Sellers.AddOrUpdate(new EF.Models.Seller
            {
                Id = 1,
                Name = "Mayesha",
                Username = "seller",
                Password = "123"

            });
            context.Customers.AddOrUpdate(new EF.Models.Customer
            {
                Id = 1,
                Name = "Zahid",
                Username = "customer",
                Password = "123"

            });

            context.Orders.AddOrUpdate(new EF.Models.Order
            {
                Id = 1,
                Status = "Placed",
                Total_price = 1100,
                Order_datetime = DateTime.Now,
                Customer_Id = 1,
                Seller_id = 1,
                Branch_id = 1
            });


            context.ProductOrders.AddOrUpdate(new EF.Models.ProductOrder
            {
                Id = 1,
                Price = 1100,
                Quantity = 1,
                Product_Id = 4 ,
                Order_Id = 1


            });*/
        }


	            


    }
}
