namespace AssoSw.Lesson2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** Classi *****/
            // Istanziazione di una classe
            Customer myFirstClass = new Customer();
            // Customer mySecondClass = new Customer(25);
            // Assegnazione dei valori di una classe
            myFirstClass.Name = "Marco";
            myFirstClass.Surname = "Rossi";
            myFirstClass.Address = "via degli abeti, 66 - Pesaro";
            bool isActive = myFirstClass.IsActive();
            Console.WriteLine($"Validità del cliente {myFirstClass.GetBusinessName()}: {isActive}");

            /***** Struct *****/
            CustomerStruct myFirstStruct = new CustomerStruct();
            myFirstStruct.Name = "Matteo";
            myFirstStruct.Surname = "Verdi";
            Console.WriteLine($"La struct {typeof(CustomerStruct)} ha come valori {myFirstStruct.Name} e {myFirstStruct.Surname}");

            /***** Enum *****/
            GiornoDellaSettimana day1 = GiornoDellaSettimana.Lunedì;
            GiornoDellaSettimana day2 = (GiornoDellaSettimana)1;
            Console.WriteLine($"Giorni della settimana {day1} - {day2}");
            Options selectedOptions = Options.Option1 | Options.Option3; // 5 in termini numerici: 0001 | 0100 = 0101
            // Verifica presenza di un enumerato utilizzato l'operatore bitwise AND &
            if ((selectedOptions & Options.Option1) == Options.Option1)
            {
                Console.WriteLine("Option1 è abilitata.");
            }
            // Verifica presenza di un enumerato utilizzando il metodo HasFlag
            if (selectedOptions.HasFlag(Options.Option1))
            {
                Console.WriteLine("Di nuovo, l'Option1 è abilitata.");
            }

            /***** Anonymous *****/
            var myFirstAnonymousType = new
            {
                Code = "ART1",
                Description = "Articolo 1",
                IsAvailable = true,
                Price = 10.5M // Decimal
            };
            Console.WriteLine($"Valori del mio primo tipo anonimo: {myFirstAnonymousType.Code} - {myFirstAnonymousType.Description} - {myFirstAnonymousType.IsAvailable}");

            /***** Array *****/
            int[] myFirstArray = new int[5];
            myFirstArray[0] = 10;
            myFirstArray[1] = 6;
            myFirstArray[2] = 50;
            myFirstArray[3] = 25;
            myFirstArray[4] = 100;
            Console.WriteLine("Primo elemento dell'array: " + myFirstArray[0]);
            Console.WriteLine("Secondo elemento dell'array: " + myFirstArray[1]);
            int lastElement = myFirstArray[myFirstArray.Length - 1];
            int lastElementWithHat = myFirstArray[^1];
            Console.WriteLine("Ultimo elemento dell'array: " + lastElement);
            Console.WriteLine("Ultimo elemento dell'array con operatore index ^: " + lastElementWithHat);
            // Operatore di range
            int[] midInterval = myFirstArray[1..3]; // 6, 50
            int[] untilTo = myFirstArray[..2]; // 10, 6
            int[] fromTo = myFirstArray[3..]; // 25, 100
            int[] mySecondArray = myFirstArray;
            Console.WriteLine("Terzo elemento dell'array \"copiato\": " + mySecondArray[2]);
            // Array multidimensionali (matrice)
            int[,] matrix = new int[2, 3];
            int[,,] matrix3D = new int[3, 3, 3];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 10;
            matrix[1, 1] = 20;
            matrix[1, 2] = 30;
            Console.WriteLine("Valore in posizione [1 ,2] della matrice: " + matrix[1, 2]);
        }

        public enum GiornoDellaSettimana
        {
            Lunedì,
            Martedì,
            Mercoledì,
            Giovedì,
            Venerdì,
            Sabato,
            Domenica
        }

        [Flags]
        public enum Options
        {
            No = 0,         // 0000
            Option1 = 1,    // 0001
            Option2 = 2,    // 0010
            Option3 = 4,    // 0100
            Option4 = 8,    // 1000
            AllOptions = Option1 | Option2 | Option3 | Option4
        }
    }
}