namespace AssoSw.Lesson2
{
    internal struct CustomerStruct
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public short Age { get; set; }

        public DateTime? ValidityDate { get; set; }

        public bool IsActive()
        {
            return !ValidityDate.HasValue || ValidityDate.Value > DateTime.Now;
        }
    }
}
