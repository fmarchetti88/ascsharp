using System;

namespace AssoSw.Lesson6.DelegatesEvents
{
    public class CarMonitor
    {
        public CarMonitor(Car car)
        {
            car.EngineOn += CarEngineOnHandler;
            car.EngineOff += CarEngineOffHandler;
            car.EngineOverheating += CarEngineOverheatingHandler;
        }

        void CarEngineOnHandler(object sender, EventArgs e)
        {
            Car car = sender as Car;
            Console.WriteLine($"Il motore della macchina {car.Model} si è acceso");
        }

        void CarEngineOffHandler(object sender, EventArgs e)
        {
            Car car = sender as Car;
            Console.WriteLine($"Il motore della macchina {car.Model} si è spento");
        }

        void CarEngineOverheatingHandler(object sender, EngineRpmEventArgs args)
        {
            Console.WriteLine("Fuori giri: " + args.NumberOfRpm);
        }
    }
}
