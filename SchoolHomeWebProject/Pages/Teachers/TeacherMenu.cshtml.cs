using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;

namespace SchoolHomeWebProject.Pages.Teachers
{
    public class TeacherMenuModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public TeacherMenuModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private static ITeacherServices _teacherServices = new TeacherServices();

        public Teacher Teacher { get; set; }
        public void OnGet()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
            int teacherId = teacher.TeacherId;
            if (teacherId == null) { throw new ArgumentNullException("Invalid teacherId"); }
            Teacher = _teacherServices.GetTeacherById(teacherId);
        }

        public IActionResult OnPost(string inputChoice)
        {
            if (inputChoice == "consultAllLectures")
            {
                return RedirectToPage("/Teachers/ConsultAllLectures");
            }
            else if (inputChoice == "AddNewLecture")
            {
                return RedirectToPage("/Teachers/AddNewLectures");
            }
            else if (inputChoice == "MyLectures")
            {
                return RedirectToPage("/Teachers/MyLectures");
            }
            else if (inputChoice == "TeacherPersonalInformation")
            {
                return RedirectToPage("/Teachers/TeacherPersonalInformation");
            }
            else if (inputChoice == "ImageUpload")
            {
                return RedirectToPage("/Teachers/ImageUpload");
            }
            else
            {

                return Page();
            }

        }
    }
}
