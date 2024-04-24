using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Utilities;

namespace Wild_Project1.Models
{
    internal class Grades
    {
        public int CourseId { get; set; }
        public double Value { get; set; }
        public string Commentary { get; set; }

        public static double CalculateAverageGrade(List<Grades> gradesList)
        {
            if (gradesList == null || gradesList.Count == 0)
            {
                return 0;
            }
            double averageGrade = 0;
            foreach (var grade in gradesList)
            {
                averageGrade += grade.Value;
            }

            double totalGrade = averageGrade / gradesList.Count;
            return Math.Round(totalGrade * 2, MidpointRounding.AwayFromZero) / 2;
        }
        public static void AddGradesStudents(List<Student> students, List<Course> courses)
        {
            Logger.Log("Starting to add grades for a student", "student.log");
            Console.Write("Enter student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Student student = students.Find(s => s.Id == studentId);

            if (student != null)
            {
                Console.WriteLine($"Adding grades for student {student.Name} {student.LastName} (ID: {student.Id})");
                Console.Write("Enter course ID: ");
                int courseId = Convert.ToInt32(Console.ReadLine());

                Course course = courses.FirstOrDefault(c => c.Id == courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                Console.Write("Enter grade value: ");
                double gradeValue = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter commentary (optional): ");
                string commentary = Console.ReadLine();

                Grades newGrade = new Grades
                {
                    CourseId = courseId,
                    Value = gradeValue,
                    Commentary = commentary
                };

                student.GradesList.Add(newGrade);
                Console.WriteLine("Grade added successfully!");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Logger.Log("Grade added successfully", "student.log");
        }

        public static List<string> GeneratePromotions(List<Student> students)
        {
            List<string> promotions = new List<string>();

            foreach (var student in students)
            {
                if (!promotions.Contains(student.Promotion))
                {
                    promotions.Add(student.Promotion);
                }
            }

            return promotions;
        }
    }
}
