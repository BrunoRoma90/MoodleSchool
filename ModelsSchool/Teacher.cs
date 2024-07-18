using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ModelsSchool
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public double Salary { get; set; }

        

        public List<Lecture> Lectures { get; set; }
        public List<Subject> Subjects { get; set; }

        public Teacher() { }

        public Teacher(Person person,int teacherId, double salary, List<Lecture> lectures, List<Subject> subjects)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            TeacherId = teacherId;           
            Salary = salary;
            Lectures = lectures;
            Subjects = subjects;
        }

    }
}
