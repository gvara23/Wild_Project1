namespace Wild_Project1
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Wild_Project1.Models;

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

            List<Student> students = DataManagement.LoadStudents(jsonFile);
            List<Course> courses = DataManagement.LoadCourses();

            MenuManagement.DisplayMainMenu();
            int choice = MenuManagement.AskChoice();

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        MenuManagement.ManageStudentsMenu(students, courses);
                        DataManagement.SaveStudents(jsonFile, students);
                        break;
                    case 2:
                        MenuManagement.ManageCoursesMenu(courses, students);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                MenuManagement.DisplayMainMenu();
                choice = MenuManagement.AskChoice();
            }
            DataManagement.SaveStudents(jsonFile, students);

            List<string> promotions = MenuManagement.GeneratePromotions(students);
            Console.WriteLine("Promotions:");
            foreach (var promotion in promotions)
            {
                Console.WriteLine(promotion);
            }
        }
    }

}
