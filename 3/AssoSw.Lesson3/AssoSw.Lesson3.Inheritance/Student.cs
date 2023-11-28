namespace AssoSw.Lesson3.Inheritance
{
    public class Student : Person
    {
        public Student(int code) : base(code) { }

        public string University { get; set; }

        public override string GetFullName()
        {
            return $"{base.GetFullName()} - University {University}";
        }
    }
}
