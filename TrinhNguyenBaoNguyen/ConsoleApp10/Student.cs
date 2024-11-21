using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Student
    {
        //data member
        private int id;
        private string name;
        private int age;

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        //getter setter
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void ShowThongTin()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
        }

    }
}

