using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Student(int Id , string Name , string Department) { 
            this.Id = Id;
            this.Name = Name;
            this.Department = Department;
        }

    }
}
