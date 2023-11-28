using System;
using System.Collections;
using System.Collections.Generic;

namespace AssoSw.Lesson3.Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /***** Senza i generics *****/
            // La classe ArrayList può contenere al suo interno qualunque tipo di oggetto
            /*
             * C'è un primo problema: quello prestazionale! A ogni inserimento
             * della lista deve essere eseguito un "boxing" di un value type, 
             * oppure un cast verso object nel caso di istanze di tipi riferimento.
             * Al contrario, volendo utilizzare i valori presenti nella lista, 
             * estraendoli da essa, si dovrà eseguire il processo contrario di 
             * unboxing o di cast verso il tipo originale!
             * L'altra limitazione è la mancanza di controllo a livello di sicurezza dei tipi.
             * Potendo inserire un qualunque oggetto, nulla garantisce sul tipo degli elementi
             * presenti in una raccolta. Supponendo, ad esempio, di voler fare una somma degli
             * elementi presenti nella lista sotto, verrà lanciata l'eccezione InvalidCastException!
             */
            ArrayList nonGenericList = new ArrayList();
            nonGenericList.Add(1);
            nonGenericList.Add(2);
            nonGenericList.Add("questa è una stringa");
            try
            {
                int sum = 0;
                foreach (object element in nonGenericList)
                {
                    sum += (int)element;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Errore nel calcolo della somma!");
            }

            /***** Con i generics *****/
            List<int> genericList = new List<int>();
            genericList.Add(1);
            genericList.Add(2);
            // genericList.Add("questa è una stringa"); // Errore
            int genericSum = 0;
            foreach (int element in genericList)
            {
                genericSum += element;
            }
            Console.WriteLine($"La somma della collection che utilizza i generics è {genericSum}");

            /***** Utilizzo dei generics con una classe senza vincoli *****/
            // Creazione di una coppia di stringhe
            Pair<string, string> stringPair = new Pair<string, string>("Hello", "World");

            // Creazione di una coppia di interi
            Pair<int, double> numericPair = new Pair<int, double>(42, 3.14);

            // Stampa delle coppie
            stringPair.Show();
            numericPair.Show();

            /***** Utilizzo dei generics con una classe con vincoli *****/
            // PairWithConstraint<string, string> pairWithConstraint = new PairWithConstraint<string, string>("Hello", "World");
            Monitor monitor = new Monitor("Ciao sono un Monitor!");
            PairWithConstraint<double, Monitor> pairWithConstraint = new PairWithConstraint<double, Monitor>(256.897, monitor);
            pairWithConstraint.Show();

            /***** Utilizzo dei generics con un metodo *****/
            // Dichiarazione di due variabili di tipo int
            int firstIntVar = 1;
            int secondIntVar = 2;

            // Scambio dei valori delle variabili
            Swap<int>(ref firstIntVar, ref secondIntVar);
            Console.WriteLine(firstIntVar); // 2
            Console.WriteLine(secondIntVar); // 1

            var intElements = new List<int> { 1, 2, 3, 4, 5, 6 };
            var stringElements = new List<string> { "sky", "blue", "war", "toy", "tick" };

            Shuffle<int>(intElements);
            Shuffle<string>(stringElements);

            foreach (var intElement in intElements)
            {
                Console.Write($"{intElement} ");
            }

            Console.WriteLine("\n-----------------------");

            foreach (var stringElement in stringElements)
            {
                Console.Write($"{stringElement} ");
            }

            Console.WriteLine();

            /***** Utilizzo del default con i generics *****/
            string stringDefault = GetDefaultValue<string>();
            int intDefault = GetDefaultValue<int>();
            bool boolDefault = GetDefaultValue<bool>();
            Console.WriteLine($@"Defaults:
- string: {stringDefault}
- int: {intDefault}
- bool: {boolDefault}");
        }

        // Definizione di un metodo statico che sfrutta i generics
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        // Definizione di un metodo generico che mescola i valori all'interno di una lista
        public static void Shuffle<T>(IList<T> elements)
        {
            int n = elements.Count;
            var rng = new Random();

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = elements[k];
                elements[k] = elements[n];
                elements[n] = value;
            }
        }

        /*
         * Restituisce il valore predefinito di un tipo qualunque, secondo le seguenti regole:
         * - per un reference type, T, default(T) restituisce null;
         * - per un tipo valore numerico, default(T) restituisce il valore zero;
         * - per un tipo valore struct, default(T) inizializza i membri con null o zero
         *   a seconda che essi siano rispettivamente di tipo riferimento o valore.
         */
        public static U GetDefaultValue<U>()
        {
            return default(U);
        }
    }
}