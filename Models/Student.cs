using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Utilities;

namespace Wild_Project1.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Grades> GradesList { get; set; }
        public Student()
        {
            GradesList = new List<Grades>();
        }
        public string Promotion { get; set; }

        public static void ListStudents(List<Student> students)
        {
            Console.WriteLine("STUDENTS LIST :");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name} {student.LastName}");
            }
        }
        public static void AddNewStudent(List<Student> students)
        {
            Logger.Log("Starting to add a new student", "student.log");

            Console.WriteLine("ADDING NEW STUDENT:");
            string name;
            do
            {
                Console.Write("Enter student name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            string lastName;
            do
            {
                Console.Write("Enter student last name: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(lastName));

            DateTime dateOfBirth;
            bool isValidDateOfBirth;
            do
            {
                Console.Write("Enter student date of birth (yyyy-MM-dd): ");
                isValidDateOfBirth = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                if (!isValidDateOfBirth)
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
                }
            } while (!isValidDateOfBirth);

            string promotion;
            do
            {
                Console.Write("Enter student promotion: ");
                promotion = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(promotion));

            int newStudentId = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;

            Student newStudent = new Student
            {
                Id = newStudentId,
                Name = name,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Promotion = promotion,
                GradesList = new List<Grades>()
            };

            students.Add(newStudent);
            Logger.Log($"New student added: {newStudent.Name} {newStudent.LastName}", "student.log");
            Console.WriteLine("New student added successfully!");
        }
        public static void ViewStudentsInfo(List<Student> students, List<Course> courses = null)
        {
            Logger.Log("Starting to view student info", "student.log");
            Console.Write("Enter student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Id == studentId);

            if (student != null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Students Info :");
                Console.WriteLine();
                Console.WriteLine($"Name               : {student.Name}");
                Console.WriteLine($"Last Name           : {student.LastName}");
                Console.WriteLine($"Birthday : {student.DateOfBirth.ToString("dd/MM/yyyy")}");
                Console.WriteLine();
                Console.WriteLine("School results :");
                Console.WriteLine();

                if (student.GradesList.Count > 0)
                {
                    foreach (var grade in student.GradesList)
                    {
                        Console.WriteLine($"    Course : {Utility.GetCoursesName(grade.CourseId, courses)}");
                        Console.WriteLine($"        Grade : {grade.Value}/20");
                        Console.WriteLine($"        Commentary : {grade.Commentary}");
                        Console.WriteLine();
                    }
                    double averageGrade = Utility.CalculateAverageGrade(student.GradesList);
                    Console.WriteLine($"    Average : {averageGrade}/20");
                }
                else
                {
                    Console.WriteLine("    No grades available for this student.");
                    Console.WriteLine("    No courses available for this student.");
                }
                Console.WriteLine("----------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Logger.Log("Finished viewing student info", "student.log");
        }
    }
}
