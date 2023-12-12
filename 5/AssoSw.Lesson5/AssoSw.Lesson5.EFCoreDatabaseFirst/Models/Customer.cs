namespace AssoSw.Lesson5.EFCoreDatabaseFirst.Models.Generated
{
    public partial class Customer
    {
        public string? FullAddress { get => $"{Address} - {Telephone}"; }
    }
}
