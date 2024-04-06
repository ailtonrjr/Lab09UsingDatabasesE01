using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09UsingDatabasesE01
{
    public class CourseManager
    {
        public string connectionString;

        public CourseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Course> ReadAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var queryGetAll = "SELECT * FROM courses";

                using (var command = new MySqlCommand(queryGetAll, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Credit = Convert.ToInt32(reader["Credit"])
                            });
                        }
                    }
                }

            }
            return courses;
        }

        public void AddCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var queryAdd = "INSERT INTO courses " +
                    "(CourseID, Name, Credit) VALUES (@CourseID, @Name, @Credit)" +
                    " ON DUPLICATE KEY UPDATE Name = VALUES(Name), Credit = VALUES (Credit)";

                using (var command = new MySqlCommand(queryAdd, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", course.CourseId);
                    command.Parameters.AddWithValue("@Name", course.Name);
                    command.Parameters.AddWithValue("@Credit", course.Credit);
                    command.ExecuteNonQuery();
                }

            }
        }

        public void UpdateCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var queryUpdate = "UPDATE courses SET Name = @Name, Credit = @Credit" +
                    " WHERE CourseId = @CourseId";

                using ( var command = new MySqlCommand( queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", course.CourseId);
                    command.Parameters.AddWithValue("@Name", course.Name);
                    command.Parameters.AddWithValue("@Credit", course.Credit);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var queryDelete = "DELETE FROM courses WHERE CourseId = @CourseId";
                using (var command = new MySqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", courseId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
