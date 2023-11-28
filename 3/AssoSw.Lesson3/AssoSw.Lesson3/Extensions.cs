namespace AssoSw.Lesson3.Class
{
    public static class Extensions
    {
        public static bool IsCheap(this Product product)
        {
            return product.Price < 100;
        }

        public static string GetFullName(this Customer customer)
        {
            return $"{customer.FirstName} {customer.LastName}";
        }

        /// <summary>
        /// Verifica se la string contiene un numero double
        /// </summary>
        /// <param name="str">stringa da verificare</param>
        /// <returns>true se la stringa rappresenta un double</returns>
        public static bool IsNumeric(this string str)
        {
            return double.TryParse(str, out _);
        }
    }
}
