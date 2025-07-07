using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    public class Student
    {
        public int id;
        public string name;
        public int age;
        public string Department;
        public Student(int id, string name, int age, string Department)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.Department = Department;
        }
        public override string ToString()
        {
            return $"ID : {id}, Name : {name}, Age : {age}, Department : {Department}";
        }
    }
}
