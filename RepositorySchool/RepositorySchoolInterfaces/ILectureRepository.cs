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
    public interface ILectureRepository
    {
        public DataTable GetLectureById(int id);
        public DataTable GetAllLectures();
        public void InsertNewLecture(Lecture lecture);
        public void UpdateLecture(Lecture lecture);

        public void RegisterStudentInLecture(int studentId, int classId);

        public void RegisterTeacherInLecture(int teacherId, int classId);


        public int LastLectureId();
    }
}
