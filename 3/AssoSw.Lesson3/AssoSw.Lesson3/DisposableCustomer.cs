namespace AssoSw.Lesson3.Class
{
    public class DisposableCustomer : IDisposable
    {
        public DisposableCustomer(string firstName, string lastName)
        {
            Console.WriteLine("Costruttore chiamato!");
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void PrintData() => Console.WriteLine($"{FirstName} {LastName}");

        // Implementazione di IDisposable
        public void Dispose()
        {
            // Codice per rilasciare le risorse gestite
            Console.WriteLine("Distruttore chiamato!");
        }
    }

}
