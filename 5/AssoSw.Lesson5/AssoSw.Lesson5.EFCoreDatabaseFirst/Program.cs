using AssoSw.Lesson5.EFCoreDatabaseFirst.Data;
using AssoSw.Lesson5.EFCoreDatabaseFirst.Models.Generated;
using Microsoft.EntityFrameworkCore;

namespace AssoSw.Lesson5.EFCoreDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InsertCustomers();
            LazyLoadingCustomer();
            EagerLoadingCustomer();
            ExplicitLoadingCustomer();
            DeleteCustomers();
        }

        private static void InsertCustomers()
        {
            using (BookContext context = new BookContext())
            {
                Customer customer1 = new Customer()
                {
                    BusinessName = "Mario Rossi",
                    VatCode = "123456789000",
                    Address = "Passaggio Duomo, 2, 20123 Milano MI",
                    Telephone = "0022445566",
                    Email = "m.rossi@email.com"
                };

                Order order = new Order()
                {
                    IdCustomerNavigation = customer1,
                    OrderPlaced = DateTime.Today
                };

                context.Customers.Add(customer1);
                context.Orders.Add(order);

                context.SaveChanges();
            }
        }

        private static void LazyLoadingCustomer()
        {
            using (BookContext context = new BookContext())
            {
                var order = context.Orders.First();
                Console.WriteLine($"LETTURA CLIENTE CON LAZY LOADING: {order.IdCustomerNavigation.BusinessName}");
            }
        }

        private static void EagerLoadingCustomer()
        {
            using (BookContext context = new BookContext())
            {
                var order = context.Orders.Include(o => o.IdCustomerNavigation).First();
                Console.WriteLine($"LETTURA CLIENTE CON EAGER LOADING: {order.IdCustomerNavigation.BusinessName}");
            }
        }

        private static void ExplicitLoadingCustomer()
        {
            using (BookContext context = new BookContext())
            {
                var order = context.Orders.First();
                var entry = context.Entry(order); // Ottiene l'oggetto entry associato all'Ordine
                entry.Reference(b => b.IdCustomerNavigation).Load(); // Quì viene caricato il Customer associato all'Ordine
                Console.WriteLine($"LETTURA CLIENTE CON EXPLICIT LOADING: {order.IdCustomerNavigation.BusinessName}");
            }
        }

        private static void DeleteCustomers()
        {
            using (BookContext context = new BookContext())
            {
                var orders = context.Orders;
                foreach (var order in orders)
                {
                    context.Orders.Remove(order);
                }
                context.SaveChanges();

                var customers = context.Customers;
                foreach (Customer customer in customers)
                {
                    context.Customers.Remove(customer);
                }

                context.SaveChanges();
            }
        }
    }
}