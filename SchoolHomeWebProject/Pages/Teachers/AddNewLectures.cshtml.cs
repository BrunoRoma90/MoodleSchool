using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;

namespace SchoolHomeWebProject.Pages
{
    public class AddNewLecturesModel : PageModel
    {

        private readonly IMemoryCache _memoryCache;
        public AddNewLecturesModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        public ITeacherServices _teacherServices = new TeacherServices();
        public ISubjectServices _subjectServices = new SubjectServices();
        public ILectureServices _lectureServices = new LectureServices();

        [BindProperty]
        public Teacher Teacher { get; set; }
        [BindProperty]
        public Lecture Lecture { get; set; }

        
        public List<Subject> Subjects { get; set; }

        public void OnGet()
        {

            Teacher teacher = new Teacher();
            teacher.TeacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
            int teacherId = teacher.TeacherId;
            if (teacherId == null) { throw new ArgumentNullException("Invalid teacherId"); }
            Teacher = _teacherServices.GetTeacherById(teacherId);
            Subjects = _subjectServices.GetAllSubjects();

        }

        public IActionResult OnPost()
        {

            if (string.IsNullOrEmpty(Lecture.ClassName) ||
                    Lecture.StartTime == default(DateTime) ||
                    Lecture.EndTime == default(DateTime) ||
                    Lecture.ClassSubject == null ||
                    Lecture.ClassSubject.SubjectId == 0)
            {
                TempData["ErrorMessage"] = "Please fill in all fields before submitting the form.";
                Subjects = _subjectServices.GetAllSubjects();

                return Page();
                //return RedirectToPage(); //A diferença do RedirectToPage() para Page() é que não perco os dados já escritos mas tenho de chamar a lista de subjects
                
            }
            if (Lecture.EndTime < Lecture.StartTime)
            {
                TempData["ErrorMessage"] = "End Time cannot be earlier than Start Time.";
                return RedirectToPage();
            }
            //Lecture lecture = new Lecture();
            //lecture.ClassSubject = new Subject();

            //bool isAnyFieldEmpty = false;

            //if (!string.IsNullOrEmpty(Lecture.ClassName))
            //{
            //    lecture.ClassName = Lecture.ClassName;
            //}
            //else
            //{
            //    isAnyFieldEmpty = true;
            //}
            //if (Lecture.StartTime != default(DateTime))
            //{
            //    lecture.StartTime = Lecture.StartTime;
            //}
            //else
            //{
            //    isAnyFieldEmpty = true;
            //}
            //if (Lecture.EndTime != default(DateTime))
            //{
            //    lecture.EndTime = Lecture.EndTime;
            //}
            //else
            //{
            //    isAnyFieldEmpty = true;
            //}
            //if (Lecture.ClassSubject != null && Lecture.ClassSubject.SubjectId != 0)
            //{
            //    lecture.ClassSubject.SubjectId = Lecture.ClassSubject.SubjectId;
            //}
            //else
            //{
            //    isAnyFieldEmpty = true;
            //}
            //if (isAnyFieldEmpty)
            //{
            //    TempData["ErrorMessage"] = "Please fill in all fields before submitting the form.";
            //    return Page();
            //}

            //if (lecture.EndTime < lecture.StartTime)
            //{
            //    TempData["ErrorMessage"] = "End Time cannot be earlier than Start Time.";
            //    return Page();
            //}
            ////if (string.IsNullOrEmpty(Lecture.ClassName) ||
            ////Lecture.StartTime == default(DateTime) ||
            ////Lecture.EndTime == default(DateTime) ||
            ////Lecture.ClassSubject.SubjectId == 0)
            ////{
            ////    TempData["ErrorMessage"] = "Please fill in all fields before submitting the form.";
            ////    return Page();
            ////}
            //////if (Lecture.EndTime < Lecture.StartTime)
            //////{
            //////    TempData["ErrorMessage"] = "End Time cannot be earlier than Start Time.";
            //////    return Page();
            //////}



            _lectureServices.InsertNewLecture(Lecture);

            int lectureId = _lectureServices.LastLectureId();
            int teacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
            _lectureServices.RegisterTeacherInLecture(teacherId, lectureId);

            List<Subject> subjects = _teacherServices.GetSubjectsByTeacherId(teacherId);
            bool subjectAlreadyExists = false;
            foreach (Subject subject in subjects)
            {
                if(subject.SubjectId == Lecture.ClassSubject.SubjectId)
                {
                    subjectAlreadyExists = true;
                }
               
            }
            if (!subjectAlreadyExists)
            {
                _subjectServices.RegisterTeacherInSubject(teacherId, Lecture.ClassSubject.SubjectId);
            }
            return RedirectToPage("/Teachers/TeacherMenu");
        }








    }
}
