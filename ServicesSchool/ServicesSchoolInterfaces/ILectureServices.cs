using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool.ServicesSchoolInterfaces
{
    public interface ILectureServices
    {
        public Lecture GetLectureById(int id);
        public List<Lecture> GetAllLectures();

        public Boolean InsertNewLecture(Lecture lecture);

        public Boolean UpdateLecture(Lecture lecture);

        public Boolean RegisterStudentInLecture(int studentId, int classId);

        public Boolean RegisterTeacherInLecture(int teacherId, int classId);

        public int LastLectureId();

    }
}
