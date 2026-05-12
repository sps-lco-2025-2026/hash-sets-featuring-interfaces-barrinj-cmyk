namespace Hashset.Lib
{

    
public class Student : SPSStudent 
{
    public string Year { get; set; }
    public string Name {get; set;}
    public string Tutor { get; set; }

    public Student(string name, string year, string tutor)
    {
        Name = name;
        Year = year;
        Tutor = tutor;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Year: {Year}, Tutor: {Tutor}";
    }

     public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

        public bool Equals(SPSStudent? other)
        {
            if (other == null) return false;
            return Name == other.Name && Year == other.Year && Tutor == other.Tutor;
        }
}

public class HashSet<T> : IHashSet<T> where T : SPSStudent, IEquatable<T>
    {
        private List<T> _items = new List<T>();
        private int _length = 0;


        public T Add(T value)
        {
            if (!IsPresent(value))
            {
                _items.Add(value);
                _length++;
            }
            return value;
        }

        public bool IsPresent(T value)
        {
            foreach (var item in _items)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;

        }

        public void Rebalance()
        {
            throw new NotImplementedException();
        }
    }



    public interface IHashSet<T> 
        where T : SPSStudent, IEquatable<T>
    {
        T Add(T value);
        bool IsPresent(T value);
        void Rebalance();
    }

    public interface SPSStudent : IEquatable<SPSStudent>
    {
        string Name { get; }
        string Year { get; }
        string Tutor { get; }
    }
}
