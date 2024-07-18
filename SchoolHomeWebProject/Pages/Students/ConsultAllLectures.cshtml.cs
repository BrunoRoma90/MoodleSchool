using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;
using Microsoft.Extensions.Caching.Memory;

namespace SchoolHomeWebProject.Pages.Students
{
    public class ConsultAllLecturesModel : PageModel
    {
        private static ILectureServices _lectureServices = new LectureServices();
        private static ISubjectServices _subjectServices = new SubjectServices();
        private static IStudentServices _studentServices = new StudentServices();
        private readonly IMemoryCache _memoryCache;
        public ConsultAllLecturesModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        [BindProperty]
        public List<Lecture> Lectures { get; set; }

        [BindProperty]
        public List<Subject> Subjects { get; set; }

        [BindProperty]
        public Lecture Lecture { get; set; }

        public void OnGet()
        {
            Lectures = _lectureServices.GetAllLectures();
            Subjects = _subjectServices.GetAllSubjects();
        }

        public IActionResult OnPostAddLecture(int ClassId, int SubjectId)
        {
            Lecture lecture = new Lecture();
            lecture.ClassId = ClassId;
            lecture.ClassSubject = new Subject
            {
                SubjectId = SubjectId
            };
            int studentId = Convert.ToInt32(_memoryCache.Get("StudentId"));


            List<Lecture> lectures = _studentServices.GetLectureBySudentId(studentId);
            bool lectureAlreadyExists = false;
            foreach (Lecture existingLecture in lectures)
            {
                if (existingLecture.ClassId == ClassId)
                {
                    TempData["ErrorMessage"] = "You are already registered for this lecture.";
                    lectureAlreadyExists = true;
                    break;
                }
            }
            if (lectureAlreadyExists)
            {
                return RedirectToPage("/Students/ConsultAllLectures");
            }

            bool subjectAlreadyExists = false;            
            List<Subject> subjects = _studentServices.GetSubjectsBySudentId(studentId);
            foreach (Subject subject in subjects)
            {
                if (subject.SubjectId == lecture.ClassSubject.SubjectId)
                {
                    _lectureServices.RegisterStudentInLecture(studentId, ClassId);
                    subjectAlreadyExists = true;
                    TempData["SuccessMessage"] = "You have been registered for the lecture.";
                    break;
                }
            }
            if (!subjectAlreadyExists)
            {

                _lectureServices.RegisterStudentInLecture(studentId, ClassId);
                _subjectServices.RegisterStudentInSubject(studentId, SubjectId);
                TempData["SuccessMessage"] = "You have been registered for the lecture and the subject.";
            }

            return RedirectToPage("/Students/ConsultAllLectures", new { classId = lecture.ClassId.ToString() });
        }
    }
}
