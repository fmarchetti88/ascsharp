namespace AssoSw.Lesson3.Inheritance
{
    public sealed class Programmer : Employee
    {
        public Programmer(int code) : base(code) { }

        public override EmployeeSector Sector => EmployeeSector.IT;

        public float MonthBonus { get; set; }

        public override float GetMonthSalary()
        {
            return base.GetMonthSalary() + MonthBonus;
        }
    }
}