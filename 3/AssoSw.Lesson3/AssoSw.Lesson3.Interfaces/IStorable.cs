namespace AssoSw.Lesson3.Interfaces
{
    public interface IStorable : IComparable<IStorable>
    {
        Status Status { get; }

        void Save();

        void Load();
    }

    public enum Status
    {
        Unknown = 0,
        Success = 1,
        Error = -1,
    }
}
