namespace AssoSw.Lesson3.Interfaces
{
    public abstract class Document : BaseStorable, IEncryptable
    {
        public Document(string fileName, int length)
        {
            FileName = fileName;
            Length = length;
        }

        public string FileName { get; private set; }

        public int Length { get; private set; }

        public abstract string GetInfo { get; }

        public void Decrypt()
        {
            Console.WriteLine($"Decrypting document {GetInfo}...");
        }

        public void Encrypt()
        {
            Console.WriteLine($"Encrypting document {GetInfo}...");
        }

        public override void Load()
        {
            Console.WriteLine($"Loading document {GetInfo} from file...");
        }

        public override void Save()
        {
            Console.WriteLine($"Saving document {GetInfo} from file...");
            Status = Status.Success;
        }
    }
}
