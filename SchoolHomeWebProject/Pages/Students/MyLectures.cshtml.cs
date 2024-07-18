using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;

namespace SchoolHomeWebProject.Pages.Students
{
    public class MyLecturesModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public MyLecturesModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private static IStudentServices _studentServices = new StudentServices();

        [BindProperty]
        public List<Lecture> Lectures { get; set; }

        [BindProperty]

        public Student Student { get; set; }

        public void OnGet()
        {
            Student student = new Student();
            student.StudentID = Convert.ToInt32(_memoryCache.Get("StudentId"));
            int studentId = student.StudentID;
            if (studentId == null) { throw new ArgumentNullException("Invalid studentId"); }
            Student = _studentServices.GetStudentsById(studentId);
            Lectures = _studentServices.GetLectureBySudentId(studentId);
        }


    }
}

