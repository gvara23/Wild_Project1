namespace Wild_Project1
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
                        ManageCoursesMenu();
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
            string jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(jsonFile, jsonData);
        }




    }
}
