using AssoSw.Lesson3.Interfaces;

namespace AssoSw.Lesson3.Inheritance
{
    public abstract class Person : BaseStorable
    {
        public Person(int code)
        {
            Code = code;
        }

        public int Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        public virtual string GetFullName() => $"{FirstName} {LastName}";

        public void Greetings() => Console.WriteLine("Hello, i'm a Person!");

        public override void Load()
        {
            Console.WriteLine($"Loading Person {FirstName} {LastName} from Database...");
        }

        public override void Save()
        {
            Console.WriteLine($"Saving Person {FirstName} {LastName} in Database...");
            Status = Status.Error;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
