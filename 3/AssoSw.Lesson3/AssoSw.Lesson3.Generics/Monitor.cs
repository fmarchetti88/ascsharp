namespace AssoSw.Lesson3.Generics
{
    internal class Monitor : ICanDisplay
    {
        public Monitor(string content)
        {
            Content = content;
        }

        public string Content { get; set; }

        public string Display()
        {
            return Content;
        }
    }
}
