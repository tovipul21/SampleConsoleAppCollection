using ConnectToEFCore.Data;
using ConnectToEFCore.Models;
using System;
using System.Linq;

namespace ConnectToEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 - Add Products to the DB
            Console.WriteLine("Start adding data to DB");
            //AddProduct();
            Console.WriteLine("Data successfully added to DB");

            // 2 - Retrieve Products from the DB
            RetrieveProducts();
        }

        private static void RetrieveProducts()
        {
            var context = new ContosoPetsContext();
            
            var products = context.Products
                .Where(product => product.Price > 5.50M)
                .OrderBy(product => product.Name);

            foreach (var item in products)
                Console.WriteLine(item.Name + "; " + item.Price);
        }

        private static void AddProduct()
        {
            ContosoPetsContext context = new ContosoPetsContext();

            context.Products.AddRange
            (
               new Product { Name = "Squeaky Dog Bone", Price = 2.3M },
                new Product { Name = "Wilson Tennis Ball 3 Pack", Price = 3.99M },
                new Product { Name = "Prince Tennis Ball 3 Pack", Price = 2.99M }
            );

            context.SaveChanges();
        }
    }
}
