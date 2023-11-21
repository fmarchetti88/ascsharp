namespace AssoSw.Lesson2.ExceptionHandling
{
    internal class NoFuelException : Exception
    {
        public Car Car { get; set; }

        public NoFuelException()
        { }

        public NoFuelException(string message)
            : base(message)
        { }

        public NoFuelException(string message, Exception inner)
            : base(message, inner)
        { }

        public NoFuelException(Car vehicle) :
            this("non c'è più benzina")
        {
            Car = vehicle;
        }
    }
}
