namespace AssoSw.Lesson3.Inheritance
{
    public abstract class Employee : Person
    {
        protected const short YearMonths = 12;

        public Employee(int code) : base(code) { }

        public string CompanyName { get; set; }

        public float Salary { get; set; }

        public virtual float GetMonthSalary()
        {
            return Salary / YearMonths;
        }

        public abstract EmployeeSector Sector { get; }
    }

    public enum EmployeeSector
    {
        Medicine,
        Government,
        Finance,
        IT
    }
}
