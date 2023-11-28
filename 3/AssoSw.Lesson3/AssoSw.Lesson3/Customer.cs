namespace AssoSw.Lesson3.Class
{
    public partial class Customer
    {
        private readonly DateTime _creationDate;

        public static int Counter = 0;

        // Constructor
        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Products = new List<Product>();
            _creationDate = DateTime.Now;
            PartialConstructor();
        }

        public Customer(string firstName, string lastName)
            : this(firstName, lastName, "default@email.com")
        { }

        partial void PartialConstructor();

        // Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate { get => _creationDate; }

        /*
         * Le property di una classe permettono di implementare il meccanismo di incapsulamento, controllando 
         * le modalità di accesso ai campi privati (nell'esempio non posso assegnare null alla lista)
         */
        public List<Product> Products { get; private set; }

        // Methods
        public string GetDisplayText()
        {
            return $"Name: {FirstName} {LastName}\nEmail: {Email}\nCreated: {CreationDate}";
        }

        public string GetPurchasedProducts()
        {
            return @$"Purchased products: 
{String.Join('\n', Products.Select(x => x.Description))}";
        }
    }
}
