namespace AssoSw.Lesson2
{
    internal class Customer
    {
        public Customer()
            : this(18) { }

        public Customer(short age)
        {
            this.Age = age;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public short Age { get; set; }

        public DateTime? ValidityDate { get; set; }

        public Color BackgroundColor { get; set; }

        public bool IsActive()
        {
            return !ValidityDate.HasValue || ValidityDate.Value > DateTime.Now;
        }

        internal string GetBusinessName()
        {
            return GetBusinessName(false);
        }

        // Overload di metodo
        internal string GetBusinessName(bool withAddress)
        {
            string businessName = $"{Name} {Surname}";
            if (!withAddress)
                return businessName;

            return $"{businessName} {Address}";
        }
    }

    public enum Color
    {
        Red,
        Green,
        White,
        Black,
        Blue
    };
}
