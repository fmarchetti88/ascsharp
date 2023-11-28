namespace AssoSw.Lesson3.Interfaces
{
    public class ExcelDocument : Document
    {
        public ExcelDocument(string fileName, int length) :
            base(fileName, length)
        { }

        public override string GetInfo => $"excel {FileName}";
    }
}
