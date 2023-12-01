using System;

namespace AssoSw.Lesson3.Generics
{
    internal class PairWithConstraint<T1, T2>
        where T1 : struct
        where T2 : class, ICanDisplay//, new()
    {
        public T1 First { get; set; }

        public T2 Second { get; set; }

        // Costruttore che accetta due parametri generici
        public PairWithConstraint(T1 first, T2 second)
        {
            First = first;
            Second = second;// ?? new T2();
        }

        // Metodo per stampare la coppia di valori
        public void Show()
        {
            Console.WriteLine($"First: {First} - Second: {Second.Display()}");
        }
    }
}
