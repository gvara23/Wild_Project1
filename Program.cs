﻿namespace Wild_Project1
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Newtonsoft.Json;

    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Use: dotnet run <json_file>");
                return;
            }
            string jsonFile = args[0];

            List<Student> students = LoadData(jsonFile);
            List<Course> courses = LoadCourses();

            DisplayMainMenu();
            int choice = AskChoice();

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        ManageStudentsMenu(students);
                        break;
                    case 2:
                        ManageCoursesMenu(courses);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                DisplayMainMenu();
                choice = AskChoice();
            }
            SaveData(jsonFile, students);
        }

        static List<Student> LoadData(string jsonFile)
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

        static void SaveData(string jsonFile, List<Student> students)
        {
            string jsonData = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, jsonData);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("MAIN MENU : ");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Courses");
            Console.WriteLine("0. Quit");
        }
        static int AskChoice()
        {
            Console.Write("Choice : ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static void ManageStudentsMenu(List<Student> students)
        {
            Console.WriteLine("MANAGE STUDENTS :");
            Console.WriteLine("1. List  actual students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. View Students details");
            Console.WriteLine("4. Add grades for student");
            Console.WriteLine("0. Exit");

            int choice = AskChoice();
            switch (choice)
            {
                case 1:
                    ListStudents(students);
                    break;
                case 2:
                    AddNewStudent(students);
                    break;
                case 3:
                    ViewStudentsInfo(students);
                    break;
                case 4:
                    AddGradesStudents(students);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;

            }
        }

        static void ManageCoursesMenu(List<Course> courses)
        {
            Console.WriteLine("MANAGE COURSES :");
            Console.WriteLine("1. List all courses");
            Console.WriteLine("2. Add new courses");
            Console.WriteLine("3. Delete courses");
            Console.WriteLine("0. Back to Main menu");

            int choice = AskChoice();
            switch (choice)
            {
                case 1:
                    ListCourse(courses);
                        break;
                case 2:
                    AddNewCourse(courses);
                        break;
                case 3:
                    DeleteCourse(courses);
                        break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                        break;
            }

        }

        static void ListStudents(List<Student> students)
        {
            Console.WriteLine("STUDENTS LIST :");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name} {student.LastName}");
            }
        }

        static void AddNewStudent(List<Student> students)
        {
            Console.WriteLine("ADDING NEW STUDENT:");
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter student date of birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            int newStudentId = students.Count > 0 ? students.Max(s => s.Id)+ 1 : 1;

            Student newStudent = new Student
            {
                Id = newStudentId,
                Name = name,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                GradesList = new List<Grades>()
            };

            students.Add(newStudent);
            Console.WriteLine("New student added successfully!");
        }

        static void ViewStudentsInfo(List<Student> students)
        {
            Console.Write("Enter student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Student student = students.Find(s => s.Id == studentId);

            if (student != null)
            {
                Console.WriteLine($"STUDENT DETAILS - ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name} {student.LastName}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToString("yyyy-MM-dd")}");
                if (student.GradesList.Count > 0)
                {
                    Console.WriteLine("Grades:");
                    foreach (var grade in student.GradesList)
                    {
                        Console.WriteLine($"Course ID: {grade.CourseId}, Value: {grade.Value}, Commentary: {grade.Commentary}");
                    }
                }
                else
                {
                    Console.WriteLine("No grades available for this student.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void AddGradesStudents(List<Student> students)
        {
            Console.Write("Enter student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Student student = students.Find(s => s.Id == studentId);

            if (student != null)
            {
                Console.WriteLine($"Adding grades for student {student.Name} {student.LastName} (ID: {student.Id})");
                Console.Write("Enter course ID: ");
                int courseId = Convert.ToInt32(Console.ReadLine());
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
        }

        static void ListCourse(List<Course> courses)
        {
            Console.WriteLine("COURSES LIST: ");
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
            }
        }

        static void AddNewCourse(List<Course> courses)
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

        static void DeleteCourse(List<Course> courses)
        {
            Console.WriteLine("DELETE COURSES");
            Console.WriteLine("Please enter the ID of the course you wanna delete : ");
            int courseIdToDelete = Convert.ToInt32(Console.ReadLine());

            Course courseToDelete = courses.Find(c => c.Id == courseIdToDelete);
            if (courseToDelete != null)
            {
                Console.WriteLine($"Are you sure you want to delete the course '{courseToDelete.Name}'? (Y/N)");
                string confirmation = Console.ReadLine().ToUpper();
                if (confirmation == "yes")
                {
                    courses.Remove(courseToDelete);
                    Console.WriteLine($"Course '{courseToDelete.Name}' deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Deletion was cancelled");
                }
            } 
            else
            {
                Console.WriteLine("Sorry but the course you looking for wasn't found");
            }
        }

        static List<Course> LoadCourses()
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

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Grades> GradesList { get; set; }
    }

    class Grades
    {
        public int CourseId { get; set; }
        public double Value { get; set; }
        public string Commentary { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
