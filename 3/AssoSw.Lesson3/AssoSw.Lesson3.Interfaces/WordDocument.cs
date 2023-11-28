namespace AssoSw.Lesson3.Interfaces
{
    public class WordDocument : Document
    {
        public WordDocument(string fileName, int length) :
            base(fileName, length)
        { }

        public override string GetInfo => $"word {FileName}";
    }
}
