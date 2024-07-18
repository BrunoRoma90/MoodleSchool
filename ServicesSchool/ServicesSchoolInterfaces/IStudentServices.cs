using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool.ServicesSchoolInterfaces
{
    public interface IStudentServices
    {
        public Student GetStudentsById(int id);
        public List<Student> GetAllStudents();
        public Boolean InsertNewStudent(Student newStudent);
        public List<Subject> GetSubjectsBySudentId(int studentId);

        public List<Lecture> GetLectureBySudentId(int studentId);

        public Student LoginStudent(string username, string password);



    }
}
