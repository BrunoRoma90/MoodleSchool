using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool.ServicesSchoolInterfaces
{
    public interface ITeacherServices
    {
        public Teacher GetTeacherById(int id);
        public List<Teacher> GetAllTeachers();
        public Boolean InsertNewTeacher(Teacher newTeacher);

        public List<Subject> GetSubjectsByTeacherId(int teacherId);

        public List<Lecture> GetLecturesByTeacherId(int teacherId);

        public Teacher LoginTeacher(string username, string password);
    }
}
