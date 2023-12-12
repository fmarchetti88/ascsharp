using System.Reflection;

namespace AssoSw.Lesson5.Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@$"Digitare:
> 1 - Esempio applicazione che mostra il CurrentThread
> 2 - Esempio di avvio Thread senza parametri
> 3 - Esempio di avvio Thread con parametri
> 4 - Esempio di avvio Thread con lambda expression
> 5 - Esempio di avvio Thread e attesa con Join
> 6 - Esempio di avvio Thread in Foreground
> 7 - Esempio di avvio Thread in Background
> 8 - Esempio di avvio di multiple Threads
> 9 - Esempio sincronizzazione tra Threads con lock
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
                    case 4:
                        FourProgram();
                        break;
                    case 5:
                        FiveProgram();
                        break;
                    case 6:
                        SixProgram();
                        break;
                    case 7:
                        SevenProgram();
                        break;
                    case 8:
                        EightProgram();
                        break;
                    case 9:
                        NineProgram();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Applicazione terminata...");
        }

        private static void OneProgram()
        {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = $"Main thread of {Assembly.GetExecutingAssembly().FullName}";
            Console.WriteLine($"Thread name: {currentThread.Name}");
            Console.WriteLine($"My current thread: {Thread.CurrentThread.Name}");
        }

        private static void TwoProgram()
        {
            Thread newThread = new Thread(Worker);
            newThread.Start();
            Console.WriteLine("Thread principale - Il nuovo thread è stato avviato.");
        }

        static void Worker()
        {
            Console.WriteLine($"Nuovo thread!");
        }

        private static void ThreeProgram()
        {
            string message = "Ciao dal thread principale!";
            Thread newThread = new Thread(WorkerWithParameter);
            newThread.Start(message);
        }

        static void WorkerWithParameter(object? message)
        {
            Console.WriteLine($"Nuovo thread. Questo è il mio messaggio: {message}");
        }

        private static void FourProgram()
        {
            Thread lambdaThread = new Thread((object? message) =>
            {
                Console.WriteLine($"Thread creato con lambda expression. Questo è il mio messaggio: {message}");
            });
            lambdaThread.Start("CIAO!!!");
        }

        private static void FiveProgram()
        {
            Thread threadWithJoin = new Thread(delegate ()
            {
                Console.WriteLine($"Avvio del thread: {Thread.CurrentThread.Name}");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            });
            threadWithJoin.Name = "Thread with Join";
            threadWithJoin.Start();
            threadWithJoin.Join();
        }

        private static void SixProgram()
        {
            Thread foregroundThread = new Thread(() =>
            {
                Console.WriteLine($"Thread in FOREGROUND creato!");
                Thread.Sleep(5000);
                Console.WriteLine($"Thread in FOREGROUND in terminazione...");
            });
            foregroundThread.Start();
        }

        private static void SevenProgram()
        {
            Thread backgroundThread = new Thread(() =>
            {
                Console.WriteLine($"Thread in BACKGROUND creato!");
                Thread.Sleep(5000);
                Console.WriteLine($"Thread in BACKGROUND in terminazione...");
            });
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        private static void EightProgram()
        {
            Thread thread1 = new Thread(SleepWorker)
            {
                Name = "Thread 1"
            };

            Thread thread2 = new Thread(SleepWorker)
            {
                Name = "Thread 2"
            };

            Thread thread3 = new Thread(SleepWorker)
            {
                Name = "Thread 3"
            };

            thread1.Start(5);
            thread2.Start(10);
            thread3.Start(7);
        }

        private static void SleepWorker(object? objectTimes)
        {
            int times = Convert.ToInt32(objectTimes);
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} dorme...");
                Thread.Sleep(1000);
            }
        }

        private static void NineProgram()
        {
            WithoutLock();
            Console.WriteLine("---------------");
            WithLock();
        }

        private static void WithoutLock()
        {
            Thread thread1 = new Thread(PrintCharWithoutLock);
            thread1.Name = "Thread 1";

            Thread thread2 = new Thread(PrintCharWithoutLock);
            thread2.Name = "Thread 2";

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private static void WithLock()
        {
            Thread thread1 = new Thread(PrintCharWithLock);
            thread1.Name = "Thread 1";

            Thread thread2 = new Thread(PrintCharWithLock);
            thread2.Name = "Thread 2";

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        public static void PrintCharWithoutLock()
        {
            string strArray = "Ciao, mi chiamo Filippo!";

            for (int y = 0; y < strArray.Length; y++)
            {
                Console.Write($"{strArray[y]}");
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
            Console.WriteLine();
        }

        private static object lockObject = new object();

        public static void PrintCharWithLock()
        {
            string strArray = "Ciao, mi chiamo Filippo!";
            lock (lockObject)
            {
                for (int y = 0; y < strArray.Length; y++)
                {
                    Console.Write($"{strArray[y]}");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                Console.WriteLine();
            }
        }
    }
}