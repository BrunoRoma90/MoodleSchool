using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ServicesSchool.ServicesSchoolInterfaces
{
    public interface ISubjectServices
    {
        public Subject GetSubjectById(int id);

        public List<Subject> GetAllSubjects();
        public Boolean InsertNewSubject(Subject subject);

        public Boolean UpdateSubject(Subject updatedSubject);
        public Boolean RegisterStudentInSubject(int studentId, int subjectId);

        public Boolean RegisterTeacherInSubject(int teacherId, int subjectId);
    }
}
