using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Models;

namespace Wild_Project1
{
    class DataManagement
    {
        public static List<Student> LoadStudents(string jsonFile)
        {
            if (!File.Exists(jsonFile))
            {
                Console.WriteLine($"File '{jsonFile}' does not exist.");
                return new List<Student>();
            }

            string jsonData = File.ReadAllText(jsonFile);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(jsonData);
            return students;
        }
        public static void SaveStudents(string jsonFile, List<Student> students)
        {
            string jsonData = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, jsonData);
        }
        public static List<Course> LoadCourses()
        {
            List<Course> courses = new List<Course>
            {
                new Course {Id = 1, Name = "Maths"},
                new Course {Id = 2, Name = "English"},
                new Course {Id = 3,Name = "History"},
                new Course {Id = 4,Name = "Science"}
            };
            return courses;
        }
    }
}
