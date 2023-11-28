namespace AssoSw.Lesson3.Inheritance
{
    public sealed class Customer : Person
    {
        public Customer(int code)
            : base(code) { }

        public string FiscalCode { get; set; }

        public string VatCode { get; set; }

        public Currency Currency { get; set; }

        public new void Greetings() => Console.WriteLine("Hello, i'm a Customer!");
    }

    public enum Currency
    {
        USD,
        EUR,
        GBP
    }
}
