using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ModelsSchool
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }


        public Subject() { }

        public Subject(int subjectId, string subjectName, string subjectDescription)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
        }

        public Subject(string subjectName, string subjectDescription) 
        {
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
        }
    }
}
