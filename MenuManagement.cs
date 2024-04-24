using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Models;
using Wild_Project1.Utilities;

namespace Wild_Project1
{
    class MenuManagement
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("===== MAIN MENU =====");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Courses");
            Console.WriteLine("0. Quit");
            Console.WriteLine("=====================");
        }
        public static int AskChoice()
        {
            Console.Write("Choice : ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void ManageStudentsMenu(List<Student> students, List<Course> courses)
        {
            Logger.Log("Opened students manage menu", "student.log");
            Console.WriteLine("===== MANAGE STUDENTS =====");
            Console.WriteLine("1. List  actual students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. View Students details");
            Console.WriteLine("4. Add grades for student");
            Console.WriteLine("0. Exit");
            Console.WriteLine("============================");

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
                    ViewStudentsInfo(students, courses);
                    break;
                case 4:
                    AddGradesStudents(students, courses);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        public static void ManageCoursesMenu(List<Course> courses, List<Student> students)
        {
            Console.WriteLine("===== MANAGE COURSES =====");
            Console.WriteLine("1. List all courses");
            Console.WriteLine("2. Add new courses");
            Console.WriteLine("3. Delete courses");
            Console.WriteLine("0. Back to Main menu");
            Console.WriteLine("============================");

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
                    Console.WriteLine("Enter the ID of the course you want to delete: ");
                    int courseIdToDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteCourse(courses, courseIdToDelete, students);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
       
    }
}
