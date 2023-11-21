namespace AssoSw.Lesson2.ExceptionHandling
{
    internal class Car
    {
        public Car(string plate)
        {
            Plate = plate;
            FuelLevel = 10;
        }

        public string Plate { get; set; }

        public double FuelLevel { get; set; }

        public void Accelerate()
        {
            if (FuelLevel == 0)
                throw new NoFuelException(this);
            else
            {
                Console.WriteLine("vroooooom!!!");
                FuelLevel -= 1;
            }
        }

        public void Stop()
        {
            Console.WriteLine("Stop!");
        }
    }
}
