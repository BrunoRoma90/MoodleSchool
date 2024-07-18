using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ModelsSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using Project.ServicesSchool;
using Microsoft.Extensions.Caching.Memory;

namespace SchoolHomeWebProject.Pages.Teachers
{
    public class TeacherPersonalInformationModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public TeacherPersonalInformationModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private static ITeacherServices _teacherServices = new TeacherServices();

        [BindProperty]
        public Teacher Teacher { get; set; }

        [BindProperty]
        public List<Subject> Subjects { get; set; }    
        public void OnGet()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherId = Convert.ToInt32(_memoryCache.Get("TeacherId"));
            int teacherId = teacher.TeacherId;
            Teacher = _teacherServices.GetTeacherById(teacherId);
            Subjects = _teacherServices.GetSubjectsByTeacherId(teacherId);

        }
    }
}
