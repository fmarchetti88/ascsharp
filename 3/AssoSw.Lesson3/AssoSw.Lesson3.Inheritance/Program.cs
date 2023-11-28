using AssoSw.Lesson3.Interfaces;

namespace AssoSw.Lesson3.Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Person person = new Person(10); // Errore! Non è possibile istanziare una classe abstract
            Student student = new Student(1)
            {
                FirstName = "Federica",
                LastName = "Rossi",
                University = "Sapienza",
                Gender = Gender.Female
            };
            Console.WriteLine(student.GetFullName());

            Programmer programmer = new Programmer(100)
            {
                FirstName = "Mark",
                LastName = "Zuckerberg",
                CompanyName = "Facebook",
                Gender = Gender.Male,
                Salary = 10000,
                MonthBonus = 100
            };
            Console.WriteLine(programmer.GetFullName());
            Console.WriteLine($"Salary: {programmer.GetMonthSalary()}");

            Customer customer = new Customer(1000)
            {
                FirstName = "Giuseppe",
                LastName = "Verdi",
                VatCode = "123456789"
            };
            Console.WriteLine(customer.GetFullName());

            List<Person> persons = new List<Person>();
            persons.Add(student);
            persons.Add(customer);
            persons.Add(programmer);

            Console.WriteLine($"Nel mio villaggio ci sono {persons.Count} persone!");

            List<Employee> employees = new List<Employee>();
            employees.Add(programmer);
            // employees.Add(customer); // Errore!

            /***** Polimorfismo *****/
            Person person = new Programmer(200)
            {
                FirstName = "Guido",
                LastName = "Rossi",
                Salary = 200000
            };

            if (person is Person)
            {
                Console.WriteLine($"{nameof(person)} è di tipo {typeof(Person)}");
            }
            if (person is Employee)
            {
                Console.WriteLine($"{nameof(person)} è di tipo {typeof(Employee)}");
            }
            if (person is Customer)
            {
                Console.WriteLine($"{nameof(person)} è di tipo {typeof(Customer)}");
            }
            if (person is Programmer prog)
            {
                Console.WriteLine($"{nameof(person)} è di tipo {typeof(Programmer)} ed ha un salario di {prog.Salary}");
            }

            // Cast
            // Programmer convertedProgrammer = person ; // Errore!
            // Safe cast
            Programmer convertedProgrammer = person as Programmer;
            Console.WriteLine($"Valore di convertedProgrammer: {convertedProgrammer?.GetFullName()}");
            Programmer convertedProgrammer1 = (Programmer)person;
            Console.WriteLine($"Valore di convertedProgrammer1: {convertedProgrammer1?.GetFullName()}");
            Customer convertedCustomer = person as Customer;
            Console.WriteLine($"Valore di convertedCustomer: {convertedCustomer?.GetFullName()}");

            // new keyword
            student.Greetings();
            programmer.Greetings();
            customer.Greetings();

            /***** Interfaces *****/
            Console.WriteLine("*************************** INTERFACES ***************************");
            List<IStorable> storableItems = new List<IStorable>();
            IStorable storableWordDocument1 = new WordDocument("pippo.docx", 1024);
            storableItems.Add(storableWordDocument1);
            IStorable storableWordDocument2 = new ExcelDocument("pluto.xlsx", 2048);
            storableItems.Add(storableWordDocument2);
            IStorable storableProgrammer = new Programmer(50)
            {
                FirstName = "Dennis",
                LastName = "Ritchie"
            };
            storableItems.Add(storableProgrammer);

            foreach (var storableItem in storableItems)
            {
                storableItem.Load();
                storableItem.Save();
            }

            IEncryptable encryptableDocument = storableWordDocument1 as IEncryptable;
            encryptableDocument.Encrypt();

            // IEncryptable encryptableProgrammer = storableProgrammer as IEncryptable;
            // encryptableProgrammer.Encrypt(); // Errore!!

            // storableItems.Sort(); // Errore: la prima volta fallisce perché non ho implementato un comparer!
            foreach (var notOrderedSortableItems in storableItems)
            {
                Console.WriteLine($"NOT ORDERED - Status: {notOrderedSortableItems.Status}");
            }

            storableItems.Sort();
            foreach (var orderedSortableItems in storableItems)
            {
                Console.WriteLine($"ORDERED - Status: {orderedSortableItems.Status}");
            }
        }
    }
}