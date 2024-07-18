using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Project.ModelsSchool;
using Project.ServicesSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;

namespace SchoolHomeWebProject.Pages.Teachers
{
    public class MyLecturesModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public MyLecturesModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        
        private static ITeacherServices _teacherServices = new TeacherServices();

        [BindProperty]
        public List<Lecture> Lectures { get; set; }

        [BindProperty]

        public Teacher Teacher { get; set; }
        
        public void OnGet()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
            int teacherId = teacher.TeacherId;
            if (teacherId == null) { throw new ArgumentNullException("Invalid teacherId"); }
            Teacher = _teacherServices.GetTeacherById(teacherId);
            Lectures = _teacherServices.GetLecturesByTeacherId(teacherId);
        }


    }
}
