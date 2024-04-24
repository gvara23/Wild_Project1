using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Utilities;

namespace Wild_Project1.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static string GetCoursesName(int courseId, List<Course> courses)
        {
            if (courses != null)
            {
                Course course = courses.Find(c => c.Id == courseId);
                if (course != null)
                {
                    return course.Name;
                }
            }
            return "Unknown";
        }

        public static void ListCourse(List<Course> courses)
        {
            Console.WriteLine("COURSES LIST: ");
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
            }
        }

        public static void AddNewCourse(List<Course> courses)
        {
            Console.WriteLine("ADDING NEW COURSE :");
            Console.WriteLine("Please enter course name :");
            string name = Console.ReadLine();
            int NewCourseId = courses.Count > 0 ? courses.Max(c => c.Id) + 1 : 1;
            Course newCourses = new Course
            {
                Id = NewCourseId,
                Name = name
            };

            courses.Add(newCourses);
            Console.WriteLine("Course added successfully !!!");
        }
        public static void DeleteCourse(List<Course> courses, int courseId, List<Student> students)
        {
            Logger.Log($"Starting to delete course with ID: {courseId}", "student.log");
            Course courseToDelete = courses.FirstOrDefault(c => c.Id == courseId);
            if (courseToDelete == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            courses.Remove(courseToDelete);
            foreach (var student in students)
            {
                student.GradesList.RemoveAll(grade => grade.CourseId == courseId);
            }

            Logger.Log($"Course with ID {courseId} deleted successfully", "student.log");
            Console.WriteLine($"Course '{courseToDelete.Name}' deleted successfully!");

        }
    }
}
