using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ModelsSchool
{
    public class Lecture
    {
        

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public Subject ClassSubject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Lecture() { }
        public Lecture(int classId, string className, Subject classSubject, DateTime startTime, DateTime endTime)
        {
            ClassId = classId;
            ClassName = className;
            ClassSubject = classSubject;           
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}
