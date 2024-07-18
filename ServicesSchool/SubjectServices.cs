using Project.ModelsSchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using Project.RepositorySchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;

namespace Project.ServicesSchool
{
    public class SubjectServices : ISubjectServices
    {

        private ISubjectRepository _subjectRepository = new SubjectRepository();
        public Subject GetSubjectById(int id)
        {


            DataTable dt = _subjectRepository.GetSubjectById(id);


            DataRow dr = dt.Rows[0];
            //Subject subject = new Subject(dr["subjectName"].ToString(), dr["subjectDescription"].ToString());

            Subject subject = new Subject
            {
                SubjectId = id,
                SubjectName = dr["subjectName"].ToString(),
                SubjectDescription = dr["subjectDescription"].ToString(),                
            };

            return subject;



        }

        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                DataTable dt = _subjectRepository.GetAllSubjects();

                foreach (DataRow dr in dt.Rows)
                {
                    Subject subject = new Subject(
                        Convert.ToInt32(dr["id"]),
                        dr["subjectName"].ToString(),
                        dr["subjectDescription"].ToString()
                    );

                    subjects.Add(subject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Is not Working");
            }

            return subjects;
        }

        public Boolean InsertNewSubject(Subject newSubject)
        {
            bool inserted = false;

            try
            {
                
                _subjectRepository.InsertNewSubject(newSubject);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public Boolean UpdateSubject(Subject updatedSubject)
        {
            bool updated = false;

            try
            {
                _subjectRepository.UpdateSubject(updatedSubject);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return updated;
        }

        public Boolean RegisterStudentInSubject(int studentId, int subjectId)
        {
            bool inserted = false;
            try
            {
                _subjectRepository.RegisterStudentInSubject(studentId, subjectId);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public Boolean RegisterTeacherInSubject(int teacherId, int subjectId)
        {
            bool inserted = false;
            try
            {
                _subjectRepository.RegisterTeacherInSubject(teacherId, subjectId);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }
    }
}
