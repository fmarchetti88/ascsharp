namespace AssoSw.Lesson3.Interfaces
{
    public abstract class BaseStorable : IStorable
    {
        private Status _status;

        public Status Status
        {
            get
            {
                return _status;
            }
            protected set
            {
                _status = value;
            }
        }

        /// <summary>
        /// Indica se l'istanza in input precede, o segue o si trova nella stessa posizione dell'istanza corrente.
        /// - maggiore di 0: l'istanza in input sarà più piccola (precederà) l'istanza corrente
        /// - 0: l'istanza in input è uguale all'istanza corrente
        /// - minore di 0: l'istanza in input sarà più grande (seguirà) l'istanza corrente
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IStorable other)
        {
            if (other == null) return -1;

            if (Status == other.Status)
                return 0;
            else if (Status < other.Status)
                return -1;
            else
                return 1;
        }

        public abstract void Load();

        public abstract void Save();
    }
}
