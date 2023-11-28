namespace AssoSw.Lesson3.Class
{
    public partial class Customer
    {
        partial void PartialConstructor()
        {
            _telephoneNumbers = new List<TelephoneNumber>();
        }

        private List<TelephoneNumber> _telephoneNumbers;

        public TelephoneNumber this[int index]
        {
            get
            {
                return _telephoneNumbers[index];
            }
        }

        public void AddTelephoneNumber(TelephoneNumber telephoneNumber)
        {
            _telephoneNumbers.Add(telephoneNumber);
        }

        // Da C# 6, Lambda Expression
        public double TotalSpent => Products.Sum(x => x.Price);
    }
}
