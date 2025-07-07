using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            int choice;

            do
            {
                Console.WriteLine("\n===== Student Management Menu =====");
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student:");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                bool isValid = int.TryParse(Console.ReadLine(), out choice);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        List<Student> students = studentManager.GetAllStudents();
                        Console.WriteLine("Student List:");
                        foreach (Student student in students)
                        {
                            Console.WriteLine(student);
                        }
                        break;

                    case 2:
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine();
                        studentManager.AddStudents(id, name, age, dept);
                        Console.WriteLine("Student added successfully.");
                        break;

                    case 3:
                        Console.Write("Enter ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Department: ");
                        string newDept = Console.ReadLine();
                        bool updated = studentManager.UpdateStudents(updateId, newName, newAge, newDept);
                        Console.WriteLine("Update Status: " + (updated ? "Success" : "Failed"));
                        break;

                    case 4:
                        Console.WriteLine("Enter ID to Delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        bool deleted = studentManager.DeleteStudent(deleteId);
                        Console.WriteLine("Deleted Successfully : "+ (deleted ? "Success" : "Failed"));
                        break;

                    case 5:
                        Console.WriteLine("Exiting Program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 5);

            Console.ReadLine();

        }
    }
}
