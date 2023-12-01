namespace AssoSw.Lesson3.Generics
{
    internal class Smartphone
    {
        public Smartphone(string content)
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
