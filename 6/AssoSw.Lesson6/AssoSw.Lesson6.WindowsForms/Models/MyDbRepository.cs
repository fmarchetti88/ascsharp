namespace AssoSw.Lesson6.WindowsForms.Models
{
    internal static class MyDbRepository
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Name = "Mario",
                Surname = "Rossi",
                Address = "Via degli abeti, 61 - Pesaro",
                Email = "rossi@email.com",
                Telephone = "11224485",
                BirthDate = new DateTime(1990, 4, 10)
            },
            new Customer()
            {
                Name = "Patrizia",
                Surname = "Verdi",
                Address = "Via degli abeti, 61 - Pesaro",
                Email = "verdi@email.com",
                Telephone = "11224485",
                BirthDate = new DateTime(1980, 11, 25)
            }
        };

        public static List<Customer> GetCustomers()
        {
            return _customers;
        }

        public static void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}
