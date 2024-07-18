using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;

namespace SchoolHomeWebProject.Pages.Students
{
    public class StudentMenuModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public StudentMenuModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        public IStudentServices _studentServices = new StudentServices();
        public Student Student { get; set; }
        public void OnGet()
        {
            Student student = new Student();
            student.StudentID = Convert.ToInt32(_memoryCache.Get("StudentId"));
            int studentId = student.StudentID;
            if (studentId == null) { throw new ArgumentNullException("Invalid studentId"); }
            Student = _studentServices.GetStudentsById(studentId);
        }

        public IActionResult OnPost(string inputChoice)
        {
            if (inputChoice == "consultAllLectures")
            {
                return RedirectToPage("/Students/ConsultAllLectures");
            }
            else if (inputChoice == "AddNewLecture")
            {
                return RedirectToPage("/Students/AddNewLectures");
            }
            else if (inputChoice == "MyLectures")
            {
                return RedirectToPage("/Students/MyLectures");
            }
            else if (inputChoice == "StudentPersonalInformation")
            {
                return RedirectToPage("/Students/StudentPersonalInformation");
            }
            else
            {

                return Page();
            }

        }
    }
}
