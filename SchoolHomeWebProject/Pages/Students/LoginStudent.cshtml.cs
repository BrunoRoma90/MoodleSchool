using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;
using Microsoft.Extensions.Caching.Memory;

namespace SchoolHomeWebProject.Pages.Students
{
    public class LoginStudentModel : PageModel
    {
        public LoginStudentModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly IMemoryCache _memoryCache;
        private static IStudentServices _studantServices = new StudentServices();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public Student Student { get; set; }
        public void OnGet()
        {
            if (_memoryCache.Get("StudentId") != null)
                this.Student.StudentID = Convert.ToInt32(_memoryCache.Get("StudentId"));
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessageNullOrEmpty"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage("/Students/LoginStudent");
            }
            Student = _studantServices.LoginStudent(username, password);
            if (Student != null)
            {
                _memoryCache.Set("StudentId", Student.StudentID);
                _memoryCache.Set("UserName", Student.UserName);
                return RedirectToPage("/Students/StudentMenu");
            }
            else
            {
                TempData["ErrorMessage"] = "Incorrect login. Please try again.";
                return RedirectToPage("/Students/LoginStudent");
            }

        }


        public IActionResult OnPostLogout()
        {
            
            _memoryCache.Remove("StudentId");         
            _memoryCache.Remove("UserName");

            return RedirectToPage("/Index");

        }
    }
}
