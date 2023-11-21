namespace AssoSw.Lession2.FlowControls
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** Costrutti di selezione *****/
            // if-then-else
            bool isOnline = true;
            int numberIf = 5;
            if (isOnline && numberIf > 5)
            {
                Console.WriteLine("La condizione è verificata!");
            }
            else if (isOnline && numberIf <= 5)
            {
                Console.WriteLine("La condizione è ANCORA verificata!");
                if (numberIf % 2 == 0)
                {
                    Console.WriteLine($"Il numero {numberIf} è PARI!");
                }
                else
                {
                    Console.WriteLine($"Il numero {numberIf} è DISPARI!");
                }
            }
            else
            {
                Console.WriteLine("La condizione NON è verificata!");
            }

            // switch-case
            // Pattern Const
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            switch (dayOfWeek) // Può essere un sbyte, byte, ushort, int, uint, long, ulong, bool, char, string, enum, nullable
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("Il giorno della settimana è LAVORATIVO!");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Il giorno della settimana è FESTIVO!");
                    break;
                default:
                    Console.WriteLine($"E' stato specificato un giorno della settimana {dayOfWeek} che NON CONOSCO!!!");
                    break;
            }

            // Pattern Type
            object myObject = "prova";
            switch (myObject)
            {
                case int[] arr:
                    Console.WriteLine($"E' un array di {arr.Length} elementi");
                    break;
                case int i:
                    Console.WriteLine("E' un numero");
                    break;
                case string s:
                    Console.WriteLine($"E' una stringa lunga {s.Length} caratteri");
                    break;
                case null:
                    Console.WriteLine("E' un oggetto nullo");
                    break;
                default:
                    Console.WriteLine($"{myObject} è di un altro tipo che non rientra nelle casistiche");
                    break;
            }

            // Pattern Logico
            char myChar = 'a';
            switch (myChar)
            {
                case 'a' or 'e' or 'i' or 'o' or 'u':
                    Console.WriteLine($"Il carattere {myChar} è una vocale");
                    break;
                default:
                    Console.WriteLine($"Il carattere {myChar} è una consonante");
                    break;
            }

            // Pattern Ricorsivo
            Person myPerson = new Person()
            {
                BirthDate = new DateTime(1988, 3, 20),
                FullName = "Rossi Marco",
                Father = new Person()
                {
                    FullName = "Luca Verdi",
                    BirthDate = new DateTime(1972, 4, 20)
                }
            };

            switch (myPerson)
            {
                case Person
                {
                    Mother: null,
                    Father.BirthDate.Year: < 1971
                }:
                    Console.WriteLine("La persona ha un padre nato prima del 1971");
                    break;
                case Person person when person.FullName.Contains("Rossi"):
                    Console.WriteLine("La persona ha come cognome Rossi");
                    break;
                default:
                    break;
            }

            /*
             * L'espressione switch (a partire da C# 8). Sfrutta le caratteristiche dell'omonima funzione, 
             * in un contesto in cui serve un'espressione, e con una sintassi più concisa
             */
            string language = "ita";
            var greetings = language switch
            {
                "eng" => "Hello",
                "spa" => "Hola",
                "ita" => "Ciao",
                _ => throw new NotImplementedException()
            };

            Console.WriteLine($"Risultato espressione switch: {greetings}");

            /***** Istruzioni di iterazione *****/
            // While
            int index = 0;

            while (index < 10)
            {
                Console.WriteLine("While: i = {0}", index);
                index++;
            }

            Console.WriteLine("Fine while");

            index = 0;
            while (true)
            {
                Console.WriteLine("i = {0}", index);
                if (++index == 10)
                    break;
            }

            while (index < 10)
            {
                if (index % 2 == 0)
                {
                    index++;
                    continue;
                }
                Console.WriteLine("i = {0}", index);
            }

            // Do-while
            char whileChar;
            do
            {
                Console.WriteLine("Premi 'q' per uscire");
                whileChar = Console.ReadKey().KeyChar;
            }
            while (whileChar != 'q');
            Console.WriteLine("Fine do-while");

            // For
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                int arrayValue = i * 10;
                array[i] = arrayValue;
                Console.WriteLine($"For - Valore {i}-esimo nell'array: {arrayValue}");
            }

            int[,] matrix = new int[10, 10];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = row * column;
                    Console.Write("{0,5}", matrix[row, column]);
                }
                Console.WriteLine();
            }

            // Foreach
            string word = "aeio";
            foreach (var character in word)
            {
                if (Char.Equals(character, 'a'))
                    continue;
                    
                Console.WriteLine(character);
            }
        }

        public class Person
        {
            public string FullName { get; set; }

            public DateTime BirthDate { get; set; }

            public Person Father { get; set; }

            public Person Mother { get; set; }
        }
    }
}