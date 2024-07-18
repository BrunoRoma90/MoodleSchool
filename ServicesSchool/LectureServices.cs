using Project.ModelsSchool;
using Project.RepositorySchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool
{
    public class LectureServices : ILectureServices
    {
        private ILectureRepository _lectureRepository = new LectureRepository();
        private ISubjectServices _subjectServices = new SubjectServices();
        public Lecture GetLectureById(int id)
        {
            DataTable dt = _lectureRepository.GetLectureById(id);

            if (dt.Rows.Count == 0)
            {
                // Lidar com o caso em que o aula não é encontrada
                return null;
            }

            DataRow dr = dt.Rows[0];

            Subject subject = null;
            if (dr["subjectId"] != DBNull.Value)
            {
                int subjectId = Convert.ToInt32(dr["subjectId"]);
                subject = _subjectServices.GetSubjectById(subjectId);
            }

            Lecture lecture = new Lecture
            {
                ClassId = id,
                ClassName = dr["className"].ToString(),
                StartTime = Convert.ToDateTime(dr["startTime"].ToString()),
                EndTime = Convert.ToDateTime(dr["endTime"].ToString()),
                ClassSubject = subject
            };

            return lecture;
        }

        public List<Lecture> GetAllLectures()
        {
            List<Lecture> lLectures = new List<Lecture>();

            try
            {
                int subjectId;

                DataTable dt = new DataTable();
                dt = _lectureRepository.GetAllLectures();
                foreach (DataRow dr in dt.Rows)
                {

                    Subject subject = new Subject();
                    if (dr["subjectId"] != DBNull.Value)
                    {
                        subjectId = Convert.ToInt32(dr["subjectId"]);
                        subject = _subjectServices.GetSubjectById(subjectId);
                    }




                    Lecture lecture = new Lecture
                    {
                        ClassId = Convert.ToInt32(dr["id"].ToString()),
                        ClassName = dr["className"].ToString(),
                        StartTime = Convert.ToDateTime(dr["startTime"].ToString()),
                        EndTime = Convert.ToDateTime(dr["endTime"].ToString()),
                        ClassSubject = subject
                    };
                    lLectures.Add(lecture);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Is not Working");
            }
            return lLectures;
        }

        public Boolean InsertNewLecture(Lecture newLecture)
        {
            bool inserted = false;
            try
            {
                _lectureRepository.InsertNewLecture(newLecture);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateLecture(Lecture updatedLecture)
        {
            bool updated = false;

            try
            {
                _lectureRepository.UpdateLecture(updatedLecture);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return updated;
        }



        public Boolean RegisterStudentInLecture(int studentId, int classId)
        {
            bool inserted = false;
            try
            {
                _lectureRepository.RegisterStudentInLecture(studentId, classId);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }



        public Boolean RegisterTeacherInLecture(int teacherId, int classId)
        {
            bool inserted = false;
            try
            {
                _lectureRepository.RegisterTeacherInLecture(teacherId, classId);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public int LastLectureId()
        {
            return _lectureRepository.LastLectureId();
        }
    }
}
