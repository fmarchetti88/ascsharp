namespace AssoSw.Lesson2.ExceptionHandling
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** System Exception *****/
            int x = 10;
            int y = 0;
            try
            {
                int result = Divide(x, y);
                Console.WriteLine($"Il risultato della divisione è {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Non è possibile dividere un numero per zero!!!");
            }

            int[] numberArray = new int[3] { 1, 2, 3 };
            try
            {
                for (int i = 0; i <= numberArray.Length; i++)
                {
                    Console.WriteLine($"Accesso all'elemento {i}-esimo dell'array: {numberArray[i]}");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Non è possibile accedere all'elemento dell'array!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante la manipolazione dell'array {ex}");
            }

            /***** Custom Exception *****/
            Car car = new Car("EA005GH") { FuelLevel = 5 };
            try
            {
                while (true)
                {
                    car.Accelerate();
                }
            }
            catch (NoFuelException ex) when (ex.Car.Plate == "EA000RU")
            {
                Console.WriteLine("Il veicolo targato {0} non può accelerare: {1}", ex.Car.Plate, ex.Message);
            }
            catch (NoFuelException ex)
            {
                Console.WriteLine("Il veicolo targato {0} non può accelerare: {1}", ex.Car.Plate, ex.Message);
            }
            finally
            {
                car.Stop();
            }
        }

        private static int Divide(int x, int y) => x / y;
    }
}