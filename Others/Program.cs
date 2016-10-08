using System;
using System.Collections.Generic;

namespace Others
{
    class Program
    {
        static void Main()
        {
            //Student first = new Student();
            //Student second = new Student();

            //Console.WriteLine(first == second);
            //Console.WriteLine(first.Equals(second));

            //var ob1 = new Employee();
            //var ob2 = new Employee();
            //Console.WriteLine(ob1.Equals(ob2));

            //var a = new Employee();
            //object b = new Employee();
            //Console.WriteLine(a.Equals(b));

            foreach (var i in Numbers(1, 5))
            {
                Console.WriteLine(i);
            }
        }

        private static IEnumerable<int> Numbers(int start, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        } 
    }

    public class Student
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public override bool Equals(object obj)
        {
            var student = (Student) obj;
            return (this.Id == student.Id && this.Name == student.Name);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Name.GetHashCode();
        }
    }

    //Using IEquatable Interface

    class Employee : IEquatable<Employee>
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public bool Equals(Employee other)
        {
            return (this.Id == other.Id && this.Name == other.Name);
        }

        public override bool Equals(object obj)
        {
            var employee = (Employee)obj;
            return (this.Id == employee.Id && this.Name == employee.Name);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Name.GetHashCode();
        }
    }

    class PermanentEmployee : IComparable<PermanentEmployee>
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public int CompareTo(PermanentEmployee other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
