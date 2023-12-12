namespace AssoSw.Lesson5.Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@$"Digitare:
> 1 - Avvio, attesa e completamento di Tasks
> 2 - Continuazione di Tasks
> 3 - Annullamento e Status di Tasks
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

            Console.WriteLine("Applicazione terminata...");
        }

        private static void OneProgram()
        {
            // Avvio di un Task con la StartNew
            Task task1 = Task.Factory.StartNew(() => Console.WriteLine("Hello from task 1"));

            // Avvio di un Task con Action
            Task task2 = Task.Run(() => Console.WriteLine("Hello from task 2"));
            Console.WriteLine($"Il task 2 è completato? {task2.IsCompleted}");
            task2.Wait();
            Console.WriteLine($"Il task 2 è completato? {task2.IsCompleted}");

            Task task3 = new Task(() => DoWork(1000));
            task3.Start();

            // Avvio e attesa di un Task
            Task longTask = Task.Run(() =>
            {
                Console.WriteLine("Start long task...");
                Thread.Sleep(3000);
                Console.WriteLine("End long task");
            });
            longTask.Wait(2000);
            Console.WriteLine("After wait long task...");

            // Avvio di una lista di Task e attesa
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 5; i++)
            {
                int number = i;
                tasks.Add(Task.Run(() =>
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            Console.WriteLine("{0} {1}", number, new string('.', j));
                            Thread.Sleep(500);
                        }
                    })
                );
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All tasks completed");
        }

        private static void DoWork(int time)
        {
            Console.WriteLine("Start work at {0}", DateTime.Now);
            Thread.Sleep(time);
            Console.WriteLine("End work at {0}", DateTime.Now);
        }

        private static void TwoProgram()
        {
            Task<string> downloadTask = Task<string>.Run(() =>
            {
                return DownloadHtml("https://www.microsoft.com");
            });

            Task<int> extractVocalTask = downloadTask.ContinueWith<int>(downloadTask =>
            {
                int count = 0;
                string vocals = "aeiou";
                string htmlPage = downloadTask.Result;
                foreach (char character in htmlPage)
                {
                    if (vocals.IndexOf(character) > -1)
                        count++;
                }
                return count;
            });

            Console.WriteLine($"Number of extracted vocals: {extractVocalTask.Result}");
        }

        public static async Task<string> DownloadHtml(string url)
        {
            using (HttpClient httpClient = new())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        /*
         * L'esempio seguente crea 20 tasks che verranno eseguite in loop finché un contatore non verrà incrementato fino a un valore di 2 milioni. 
         * Quando le prime 10 attività raggiungono i 2 milioni, il token di annullamento viene annullato e tutte le attività i cui contatori 
         * non hanno raggiunto i 2 milioni vengono annullate. 
         * Nell'esempio viene quindi esaminata la proprietà Status di ogni Task per indicare se è stato completato correttamente o se è stato annullato. 
         * */
        private static void ThreeProgram()
        {
            var tasks = new List<Task<int>>();
            var source = new CancellationTokenSource();
            var token = source.Token;
            int completedIterations = 0;

            for (int numberOfTask = 0; numberOfTask <= 20; numberOfTask++)
            {
                tasks.Add(Task.Run(() =>
                {
                    int iterations = 0;
                    for (int index = 1; index <= 1000; index++)
                    {
                        // Lancia un'eccezione se è stata richiesta la cancellazione
                        token.ThrowIfCancellationRequested();
                        iterations++;
                    }
                    // Incremento "safety"
                    Interlocked.Increment(ref completedIterations);

                    /*
                     * Se almeno 10 Tasks hanno completato l'iterazione di 1000 volte, 
                     * gli altri task  che stanno ancora iterando vengono annullati!
                     */
                    if (completedIterations >= 10)
                        source.Cancel();

                    return iterations;
                }, token));
            }

            Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException)
            {
                Console.WriteLine("Status of tasks:\n");
                Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                                  "Status", "Iterations");
                foreach (var task in tasks)
                {
                    Console.WriteLine("{0,10} {1,20} {2,14}",
                                      task.Id,
                                      task.Status,
                                      // N0: per la formattazione del numero con i .
                                      task.Status != TaskStatus.Canceled ? task.Result.ToString("N0") : "n/a");
                }
            }
        }
    }
}