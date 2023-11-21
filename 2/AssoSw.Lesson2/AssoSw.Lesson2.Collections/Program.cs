using System.Collections;

namespace AssoSw.Lesson2.Collections
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** ArrayList *****/
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Questa è una stringa");
            arrayList.Add(DateTime.Today);

            foreach (var element in arrayList)
            {
                Console.WriteLine($"Elemento all'interno dell'arrayList: {element}");
            }

            // arrayList.Sort();)

            /***** List *****/
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            Console.WriteLine("***** Lista iniziale *****");
            foreach (string city in cities)
            {
                Console.WriteLine($" {city}");
            }
            Console.WriteLine($"The first city is {cities[0]}.");
            Console.WriteLine($"The last city is {cities[cities.Count - 1]}.");
            cities.Insert(0, "Sydney");
            Console.WriteLine("***** Dopo aver inserito Sydney all'indice 0 *****");
            foreach (string city in cities)
            {
                Console.WriteLine($" {city}");
            }
            cities.RemoveAt(1);
            cities.Remove("Milan");
            Console.WriteLine("***** Dopo aver rimosso due città *****");
            foreach (string city in cities)
            {
                Console.WriteLine($" {city}");
            }

            /***** HashTable *****/
            Hashtable hashTable = new Hashtable()
            {
                { "lombardia", "milano" },
                { "marche", "ancona"},
                { "lazio", "roma" },
            };

            // Aggiunta di elementi
            hashTable.Add("umbria", "perugia");
            hashTable.Add("today", DateTime.Today);
            // hashTable.Add("marche", "ancona"); // Errore!
            hashTable.Remove("lombardia"); // Rimuove un elemento
            foreach (DictionaryEntry pair in hashTable)
            {
                Console.WriteLine("HashTable - Chiave: " + pair.Key + ", Valore: " + pair.Value);
            }
            hashTable.Clear(); // Rimuove tutti gli elementi

            /***** Dictionary *****/
            Dictionary<int, string> dictionaryValues = new Dictionary<int, string>();
            dictionaryValues.Add(1, "Valore AAAA");
            dictionaryValues[2] = "Valore BBBB";
            dictionaryValues[1] = "Valore A";
            dictionaryValues.Add(4, "Valore DDDD");
            dictionaryValues.Add(3, "Valore CCCC");

            if (dictionaryValues.TryGetValue(2, out string val))
            {
                Console.WriteLine("Dictionarty TryGetValue - {0}: {1}", 2, val);
            }

            if (dictionaryValues.ContainsKey(1))
            {
                Console.WriteLine("Dictionary ContainsKey - {0}: {1}", 1, dictionaryValues[1]);
            }

            foreach (KeyValuePair<int, string> pair in dictionaryValues)
            {
                Console.WriteLine("Coppia - {0} : {1}", pair.Key, pair.Value);
            }

            /***** Stack *****/
            Console.WriteLine("***** Stack *****");
            var myStack = new Stack<string>();
            myStack.Push("Marco");
            myStack.Push("Roberto");
            myStack.Push("Daniela");
            Console.WriteLine($"Stack {myStack.Pop()}");
            Console.WriteLine($"Stack {myStack.Pop()}");
            Console.WriteLine($"Stack {myStack.Peek()}");
            Console.WriteLine($"Lunghezza dello Stack dopo l'operazione di Peek(): {myStack.Count}");

            /***** Queue *****/
            Console.WriteLine("***** Queue *****");
            var myQueue = new Queue();
            myQueue.Enqueue("Marco");
            myQueue.Enqueue("Roberto");
            myQueue.Enqueue("Daniela");
            Console.WriteLine($"Queue {myQueue.Dequeue()}");
            Console.WriteLine($"Queue {myQueue.Dequeue()}");
            Console.WriteLine($"Queue {myQueue.Peek()}");
            Console.WriteLine($"Lunghezza della Queue dopo l'operazione di Peek(): {myStack.Count}");
        }
    }
}