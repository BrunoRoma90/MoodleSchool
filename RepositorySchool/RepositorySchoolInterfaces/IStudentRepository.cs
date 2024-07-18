using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositorySchool.RepositorySchoolInterfaces
{
    public interface IStudentRepository
    {
        public DataTable GetStudentById(int id);
        public DataTable GetAllStudents();
        public void InsertNewStudent(Student student);

        public DataTable GetSubjectByStudentId(int studentId);

        public DataTable GetLectureByStudentId(int studentId);

        public DataTable GetStudentsByCredentials(string username, string password);

    }
}
