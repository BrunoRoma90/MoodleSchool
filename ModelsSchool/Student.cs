using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.ModelsSchool
{
    public class Student : Person
    {
        public int StudentID { get; set; }
        public List<Subject> Subjects { get; set; }

        public List<Lecture> Lectures { get; set; }

        public Student() { }

        

        public Student(Person person ,int studentID, List<Subject> subjects, List<Lecture> lectures) 
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            StudentID = studentID;
            Subjects = subjects;
            Lectures = lectures;
        }

    }
}
