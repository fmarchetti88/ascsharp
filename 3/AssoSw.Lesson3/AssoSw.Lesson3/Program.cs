namespace AssoSw.Lesson3.Class
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** Class *****/
            Customer customer = new Customer("John", "Doe", "johndoe@example.com");
            Console.WriteLine(customer.GetDisplayText());
            customer.Products.Add(new Product()
            {
                Code = 1,
                Description = "Smartphone",
                Price = 300
            });
            customer.Products.Add(new Product()
            {
                Code = 2,
                Description = "Smart TV",
                Price = 690
            });

            Console.WriteLine(customer.GetPurchasedProducts());

            // Indicizzatori: permettono di accedere agli oggetti come se fossero un array, cioè mediante un indice
            customer.AddTelephoneNumber(new TelephoneNumber() { Name = "Marco", Number = "0224866997" });
            Console.WriteLine($"Il numero di telefono di {customer[0].Name} è {customer[0].Number}");

            /***** Extension Method *****/
            string str1 = "ciao";
            string str2 = "120";

            Console.WriteLine($"La stringa {str1} è un numero? {str1.IsNumeric()}");
            Console.WriteLine($"La stringa {str2} è un numero? {str2.IsNumeric()}");
            Console.WriteLine($"Full name: {customer.GetFullName()}");

            /***** Class dispose *****/
            using (var myDisposableClass = new DisposableCustomer("Marco", "Rossi"))
            {
                myDisposableClass.PrintData();
            }

            /***** Static Member *****/
            Customer.Counter++;
            Console.WriteLine($"Valore della variabile statica {nameof(Customer.Counter)}: {Customer.Counter}");
        }
    }
}