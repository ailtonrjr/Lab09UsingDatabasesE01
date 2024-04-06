using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab09UsingDatabasesE01
{
    public class Course
    {
        [Required]
        
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Credit { get; set; }

        public Course ()
        {}

        public override string ToString()
        {
            return $"CourseId: {CourseId}\t" +
                $"Name: {Name}\t" +
                $"Credit: {Credit}\t";
        }


    }
}
