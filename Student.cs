using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Project1
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
    }
}
