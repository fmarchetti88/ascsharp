using System;

namespace AssoSw.Lesson6.DelegatesEvents
{
    public delegate string Int2StringDelegate(int i);
    public delegate void EmptyDelegate();

    class Converter
    {
        public string ConvertToString(int intVar)
        {
            return intVar.ToString();
        }

        public static string StaticConvertToString(int intVar)
        {
            return intVar.ToString();
        }

        public string ConvertToString(double doubleVar)
        {
            return doubleVar.ToString();
        }

        public string DoubleUpNumber(int intVar)
        {
            return (intVar * 2).ToString();
        }

        public string Int2String(int intVar)
        {
            return intVar.ToString();
        }

        public int StringToInt(string stringVar)
        {
            return int.Parse(stringVar);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /********* Delegate *********/
            Converter converter = new Converter();
            // Istanziazione di un delegate
            Int2StringDelegate intToStringDelegate = new Int2StringDelegate(converter.ConvertToString);
            // Creazione implicita delegate 
            Int2StringDelegate intToStringDelegate2 = converter.ConvertToString;
            // Creazione del delegate tramite metodo statico
            Int2StringDelegate intToStringDelegate3 = (Int2StringDelegate)Delegate.CreateDelegate(typeof(Int2StringDelegate), converter, "ConvertToString");
            intToStringDelegate3(123);

            string str = intToStringDelegate2(123);
            str = intToStringDelegate2.Invoke(123);

            // Ottenere informazioni da un delegate
            Console.WriteLine("Ottenere informazioni sul delegate");
            var method = intToStringDelegate2.Method;
            Console.WriteLine(method.Name);
            var target = intToStringDelegate2.Target;
            Console.WriteLine(target.ToString());

            Console.WriteLine("Ottenere informazioni sul delegate con metodo statico");
            intToStringDelegate2 = Converter.StaticConvertToString;
            Console.WriteLine(intToStringDelegate2.Method);
            Console.WriteLine(intToStringDelegate2.Target);

            UseDelegate(Converter.StaticConvertToString, 1, 2, 3);

            // Multicast delegate
            EmptyDelegate multicast = Method1;
            multicast += Method2;
            multicast += Method2; //un metodo può essere aggiunto più volte
            multicast();
            multicast -= Method2;
            Delegate[] list = multicast.GetInvocationList();
            foreach (Delegate delInstance in list)
            {
                Console.WriteLine("invoco {0}", delInstance.Method);
                (delInstance as EmptyDelegate).Invoke();
            }

            multicast = (EmptyDelegate)Delegate.Combine(new EmptyDelegate(Method1), new EmptyDelegate(Method2));

            multicast -= Method1;
            multicast -= Method2;
            if (multicast != null)
            {
                multicast.Invoke();
            }

            Int2StringDelegate multi = converter.ConvertToString;
            multi += converter.DoubleUpNumber;
            Console.WriteLine(multi(10));

            /********* Events *********/
            Car audiCar = new Car("Audi A3");
            CarMonitor monitor = new CarMonitor(audiCar);
            audiCar.Start();
            audiCar.Accelerate();
            audiCar.Accelerate();
            while (audiCar.IsEngineOn)
                audiCar.Decelerate();

            audiCar.Start();
            for (int i = 0; i < 100; i++)
                audiCar.Accelerate();
        }

        static void UseDelegate(Int2StringDelegate myDelegate, params int[] values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(myDelegate(value));
            }
        }

        static void Method1()
        {
            Console.WriteLine("Metodo 1");
        }

        static void Method2()
        {
            Console.WriteLine("Metodo 2");
        }
    }
}