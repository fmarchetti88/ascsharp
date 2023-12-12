namespace AssoSw.Lesson5.AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@$"Digitare:
> 1 - Primo programma di esempio con pattern Async/Await
> 2 - Esempio di lettura file in Async
> 3 - Esempio di chiamate HTTP parallele in Async
Premere un qualsiasi altro pulsante per uscire");

            string? key = Console.ReadLine();
            if (Int32.TryParse(key, out int intKey))
            {
                switch (intKey)
                {
                    case 1:
                        OneProgram();
                        break;
                    case 2:
                        TwoProgram();
                        break;
                    case 3:
                        ThreeProgram();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Digita un carattere per uscire...");
            Console.ReadLine();
        }

        private static async void OneProgram()
        {
            Console.WriteLine("Before invocation of Async Method");
            await AsyncMethod();
            Console.WriteLine("After invocation of Async Method");
        }

        private static async Task AsyncMethod()
        {
            Console.WriteLine("Before invocation of await");
            await Task.Run(() =>
            {
                Console.WriteLine("Start task...");
                Thread.Sleep(3000);
                Console.WriteLine("...end task!");
            });
            Console.WriteLine("After invocation of await");
        }

        /*
         * In questo esempio andremo a leggere tutti i caratteri da un file di testo di grandi dimensioni 
         * in modo asincrono e verrà stampato in output la lunghezza totale di tutti i caratteri.
         */
        private async static void TwoProgram()
        {
            string filePath = @"C:\temp\sampleAsyncFile.txt";
            Console.WriteLine("Before work...");
            int length = await ReadFileAsync(filePath);
            Console.WriteLine($"After work - Total length: {length}");
        }

        static async Task<int> ReadFileAsync(string filePath)
        {
            Console.WriteLine("File reading is starting...");
            using (StreamReader reader = new StreamReader(filePath))
            {
                /*
                 * Legge tutti i caratteri dalla posizione corrente alla fine del flusso 
                 * in modo asincrono e li restituisce come un'unica stringa.
                 */
                string reededString = await reader.ReadToEndAsync();
                Console.WriteLine("...file reading is completed!");
                return reededString.Length;
            }
        }

        private static async void ThreeProgram()
        {
            Task<string> firstTask = HttpRequestAsync("https://reqres.in/api/users?delay=7");
            Task<string> secondTask = HttpRequestAsync("https://reqres.in/api/users?delay=10");
            Task<string> thirdTask = HttpRequestAsync("https://reqres.in/api/users?delay=5");
            // Await the completion of all tasks using Task.WhenAll
            string[] results = await Task.WhenAll(firstTask, secondTask, thirdTask);
            Console.WriteLine($"Results of all execution: {String.Join('-', results)}");
        }

        static async Task<string> HttpRequestAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine($"Calling {url}");
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await client.SendAsync(request);
                string statusCode = response.StatusCode.ToString();
                Console.WriteLine($"End of call {url} - Response: {statusCode}");
                return statusCode;
            }
        }
    }
}