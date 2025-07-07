using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace StudentApp
{
    public class StudentManager
    {
        private string connectionString = "server=127.0.0.1;port=3306;database=student;uid=root;pwd=1234;";

        public void AddStudents(int id, string name, int age, string Department)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO students (id, name, age, Department) VALUES (@id, @name, @age, @dept)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@dept", Department);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM students";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student(
                            Convert.ToInt32(reader["id"]),
                            reader["name"].ToString(),
                            Convert.ToInt32(reader["age"]),
                            reader["Department"].ToString()
                        ));
                    }
                }
            }
            return students;
        }

        public bool UpdateStudents(int id, string name, int age, string Department)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE students SET name = @name, age = @age, Department = @dept WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@dept", Department);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM students WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
