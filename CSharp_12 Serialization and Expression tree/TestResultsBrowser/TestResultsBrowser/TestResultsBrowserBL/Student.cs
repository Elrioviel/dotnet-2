using System;

namespace Entities
{
    [Serializable]
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Test { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }

        public int CompareTo(Student other)
        {
            int result;
            result = Surname.CompareTo(other.Surname);
            if (result != 0)
            {
                return result;
            }
            result = Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;
            }
            result = Test.CompareTo(other.Test);
            if (result != 0)
            {
                return result;
            }
            result = Date.CompareTo(other.Date);
            if (result != 0)
            {
                return result;
            }
            return Score.CompareTo(other.Score);
        }

        public override string ToString() => $"Name: {Name}, Surname: {Surname}, Test: {Test}, Date: {Date}, Score: {Score}";
    }
}
