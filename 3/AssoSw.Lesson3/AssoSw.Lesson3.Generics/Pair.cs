using System;

namespace AssoSw.Lesson3.Generics
{
    // Definizione di una classe generica per la gestione di coppie di valori
    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        // Costruttore che accetta due parametri generici
        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        // Metodo per stampare la coppia di valori
        public void Show()
        {
            Console.WriteLine($"First: {First} - Second: {Second}");
        }
    }
}
