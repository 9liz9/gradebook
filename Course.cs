namespace gradebook
{
    public class Course
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        internal Course Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

