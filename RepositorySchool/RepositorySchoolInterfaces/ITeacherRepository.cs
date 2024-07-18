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
    public interface ITeacherRepository
    {
        public DataTable GetTeacherById(int id);
        public DataTable GetAllTeachers();
        public void InsertNewTeacher(Teacher teacher);
        public DataTable GetSubjectByTeacherId(int teacherId);

        public DataTable GetLectureByTeacherId(int teacherId);

        public DataTable GetTeachersByCredentials(string username, string password);

        public DataTable GetTeacherByEmail(string email);

        public DataTable GetTeacherByUsername(string username);
    }
}
