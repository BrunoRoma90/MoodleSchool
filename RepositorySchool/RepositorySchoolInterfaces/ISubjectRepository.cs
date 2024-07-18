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
    public interface ISubjectRepository
    {
        public DataTable GetSubjectById(int id);
        public DataTable GetAllSubjects();
        public void InsertNewSubject(Subject subject);
        public void UpdateSubject(Subject subject);
        public void RegisterStudentInSubject(int studentId, int subjectId);

        public void RegisterTeacherInSubject(int teacherId, int subjectId);

    }
}
