using MySqlConnector;


namespace Lab09UsingDatabasesE01
{
    public class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "Dudato1312*",
                Database = "Students"
            };

            Console.WriteLine(builder.ConnectionString);

            CourseManager courseManager = new CourseManager(builder.ConnectionString);

            //Starting the CRUD instances


            //READ
            Console.WriteLine("Getting the course information from the database! ");
            List<Course> allCourses = courseManager.ReadAllCourses();

            foreach (Course course in allCourses)
            {
                Console.WriteLine("Those are the listed courses in the database: ");
                Console.WriteLine(course);
            }

            //CREATE
            Course newCourse1 = new Course(){CourseId = 1006, Name = "Critical Thinking", Credit = 3};
            Course newCourse2 = new Course(){CourseId = 1007, Name = "Introduction to Network Systems", Credit = 3 };
            Course newCourse3 = new Course(){CourseId = 1008, Name = "Software Testing and Deployment", Credit = 4};
            Course newCourse4 = new Course(){CourseId = 1009, Name = "Software Security", Credit = 4 };
            Course newCourse5 = new Course(){CourseId = 1010, Name = "Mobile Application Development", Credit = 4};

            courseManager.AddCourse(newCourse1);
            courseManager.AddCourse(newCourse2);
            courseManager.AddCourse(newCourse3);
            courseManager.AddCourse(newCourse4);
            courseManager.AddCourse(newCourse5);

            //UPDATE

            Course updatedCourse = allCourses[5];
            updatedCourse.Name = "We have changed this name";
            updatedCourse.Credit = 15;
            courseManager.UpdateCourse(updatedCourse);

            //DELETE
            courseManager.DeleteCourse(1010);

            //READING THE UPDATED LIST
            foreach (Course course in allCourses)
            {
                Console.WriteLine("This is the updated list of courses: ");
                Console.WriteLine(course);
            }

        }
    }
}
