using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Project1.Models;

namespace Wild_Project1.Utilities
{
    public static class Utility
    {
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
    }
}
