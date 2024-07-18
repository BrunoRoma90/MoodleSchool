using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;

namespace SchoolHomeWebProject.Pages.Students
{
    public class LoginTeacherModel : PageModel
    {
        public LoginTeacherModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly IMemoryCache _memoryCache;
        private static ITeacherServices _teacherServices = new TeacherServices();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public Teacher Teacher { get; set; }


        public void OnGet()
        {
            if (_memoryCache.Get("TeacherId") != null)
                this.Teacher.TeacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessageNullOrEmpty"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage("/Teachers/LoginTeacher");
            }
            Teacher = _teacherServices.LoginTeacher(username, password);
            if (Teacher != null)
            {
                _memoryCache.Set("TeacherId", Teacher.TeacherId);               
                _memoryCache.Set("UserName", Teacher.UserName);
                return RedirectToPage("/Teachers/TeacherMenu");
            }
            else
            {
                TempData["ErrorMessage"] = "Incorrect login. Please try again.";
                return RedirectToPage("/Teachers/LoginTeacher");
            }

        }


        public IActionResult OnPostLogout()
        {
            _memoryCache.Remove("TeacherId");            
            _memoryCache.Remove("UserName");
            return RedirectToPage("/Index");

        }
    }
}
