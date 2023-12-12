using AssoSw.Lesson5.EFCoreCodeFirst.Data;
using AssoSw.Lesson5.EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AssoSw.Lesson5.EFCoreCodeFirst
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AddProducts();
            ReadProduct();
            QueryProductsWithLinqMethodSyntax();
            QueryProductsWithLinqQuerySyntax();
            QueryProductsWithInterpolatedSQL();
            UpdateProducts();
            DeleteProducts();
        }

        private static void AddProducts()
        {
            using (BookContext context = new BookContext())
            {
                /*
                 * E' possibile invocare questo metodo (NON IN PRODUZIONE!) che permette la creazione del database qualora
                 * non esistesse. Ovviamente questa modalità è da applicare se non si utilizza la Migration (Update-Database)
                 */
                // bool dbCreateResult = context.Database.EnsureCreated();

                Product tolkienBook = new Product()
                {
                    Code = "BOOK1",
                    Description = "The Lord Of The Rings: Tolkien, J.R.R.",
                    Price = 10m,
                    QuantityWarehouse = 1000
                };
                context.Add(tolkienBook);

                Product harryPotterBook = new Product()
                {
                    Code = "BOOK2",
                    Description = "Harry Potter and the Philosopher's Stone: Rowling J.K.",
                    Price = 11.5m,
                    QuantityWarehouse = 100
                };
                context.Products.Add(harryPotterBook);

                context.SaveChanges();
            }
        }

        private static void ReadProduct()
        {
            using (BookContext context = new BookContext())
            {
                Product? product = context.Products.Find(1);
                if (product != null)
                {
                    Console.WriteLine("ReadProduct");
                    PrintProduct(product);
                }
            }
        }

        // Utilizzo di Fluent-API
        private static void QueryProductsWithLinqMethodSyntax()
        {
            using (BookContext context = new BookContext())
            {
                var products = context.Products
                                .Where(i => i.Price > 10m)
                                .OrderBy(i => i.Code);

                Console.WriteLine("QueryProductsWithLinqMethodSyntax");
                foreach (Product product in products)
                {
                    PrintProduct(product);
                }
            }
        }

        private static void QueryProductsWithLinqQuerySyntax()
        {
            using (BookContext context = new BookContext())
            {
                var products = from product in context.Products
                               where product.Price > 10m
                               orderby product.Code
                               select product;

                Console.WriteLine("QueryProductsWithLinqMethodSyntax");
                foreach (Product product in products)
                {
                    PrintProduct(product);
                }
            }
        }

        private static void QueryProductsWithInterpolatedSQL()
        {
            using (BookContext context = new BookContext())
            {
                var bookProduct = context.Products
                    .FromSqlInterpolated($"SELECT * FROM Products WHERE Code = 'BOOK1'")
                    .FirstOrDefault();

                // E' possibile anche eseguire query generiche invocando
                // context.Database.ExecuteSqlRaw("<Query>");
                // var customers = context.Database.SqlQuery<Customer>($"SELECT * FROM Customer");

                if (bookProduct != null)
                {
                    Console.WriteLine("Readed book with Interpolated Query");
                    PrintProduct(bookProduct);
                }
            }
        }

        private static void UpdateProducts()
        {
            using (BookContext context = new BookContext())
            {
                var products = context.Products
                                .Where(i => i.Price > 10m)
                                .OrderBy(i => i.Code)
                                .FirstOrDefault();

                if (products != null)
                {
                    products.Price = products.Price + 1m;
                }

                context.SaveChanges();
            }
        }

        private static void DeleteProducts()
        {
            using (BookContext context = new BookContext())
            {
                var products = context.Products.OrderBy(i => i.Code);

                foreach (Product product in products)
                {
                    context.Products.Remove(product);
                }

                context.SaveChanges();
            }
        }

        private static void PrintProduct(Product product)
        {
            Console.WriteLine($"Id:          {product.Id}");
            Console.WriteLine($"Code:        {product.Code}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price:       {product.Price}");
            Console.WriteLine($"-------------------------------");
        }
    }
}