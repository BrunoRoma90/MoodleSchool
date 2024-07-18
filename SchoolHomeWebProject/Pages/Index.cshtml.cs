using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;
using Project.ModelsSchool;
using Microsoft.Extensions.Caching.Memory;
using SchoolHomeWebProject.Pages.Students;


namespace SchoolHomeWebProject.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _memoryCache;

        private static IStudentServices _studentServices = new StudentServices();
        private static ITeacherServices _teacherServices = new TeacherServices();
        public IndexModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        [BindProperty]
        public Teacher Teacher { get; set; }
        [BindProperty]
        public Student Student { get; set; }

        

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public void OnGet()
        {
            if (_memoryCache.Get("Id") != null)
            {
                Teacher = _teacherServices.GetTeacherById(Convert.ToInt32(_memoryCache.Get("Id")));
            }
            if (_memoryCache.Get("Id") != null)
            {
                Student = _studentServices.GetStudentsById(Convert.ToInt32(_memoryCache.Get("Id")));
            }

        }



        public IActionResult OnPost(string loginType)
        {
            if (loginType == "teacher")
            {
                return RedirectToPage("/Teachers/LoginTeacher");
            }
            else if (loginType == "student")
            {
                return RedirectToPage("/Students/LoginStudent");
            }
            else
            {
                
                return Page();
            }

        }
    }
}