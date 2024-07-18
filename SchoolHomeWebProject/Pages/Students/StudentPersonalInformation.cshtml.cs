using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;

namespace SchoolHomeWebProject.Pages.Students
{
    public class StudentPersonalInformationModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public StudentPersonalInformationModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private static IStudentServices _studentServices = new StudentServices();

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public List<Subject> Subjects { get; set; }
        public void OnGet()
        {
            Student student = new Student();
            student.StudentID = Convert.ToInt32(_memoryCache.Get("StudentId"));
            int studentId = student.StudentID;
            Student = _studentServices.GetStudentsById(studentId);
            Subjects = _studentServices.GetSubjectsBySudentId(studentId);

        }
    }
}
