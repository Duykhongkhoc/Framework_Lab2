using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLab2
{
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Ma: {Id} \t Tên: {Name} \t Tuổi: {Age}";
        }
    }
    class Lecture
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Ma: {Id} \t Tên: {Name} \t Tuổi: {Salary}";
        }
    }
    class PersonalManager<T>
    {
        private List<T> listPerson = new List<T>();
        public void Add(T person)
        {
            listPerson.Add(person);
        }
        public void Display()
        {
            foreach (T t in listPerson)
            {
                Console.WriteLine($"{t}");
            }
        }
    }
    class Advanced_Generic
    {
        static void Main(string[] args)
        {
            Console.Title = "BTHH2";
            Console.OutputEncoding = Encoding.UTF8;
            PersonalManager<Lecture> lectures = new PersonalManager<Lecture>();
            lectures.Add(new Lecture { Id = "L01", Name = "Ted", Salary = 200 });
            lectures.Add(new Lecture { Id = "L02", Name = "Robin", Salary = 500 });
            lectures.Add(new Lecture { Id = "L03", Name = "Batman", Salary = 1000 });

            PersonalManager<Student> students = new PersonalManager<Student>();
            students.Add(new Student { Id = "S01", Name = "King Kong", Age = 10 });
            students.Add(new Student { Id = "S02", Name = "T-Rex", Age = 15 });
            students.Add(new Student { Id = "S03", Name = "Shark", Age = 16 });
            Console.WriteLine("Thong tin Lecture: ");
            lectures.Display();
            Console.WriteLine("Thong tin Student: ");
            students.Display();
        }
    }
}
