using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ModelsSchool;
using Project.ServicesSchool;
using Project.ServicesSchool.ServicesSchoolInterfaces;

namespace SchoolHomeWebProject.Pages.Teachers
{
    public class ConsultAllLecturesModel : PageModel
    {
        private static ILectureServices _lectureServices = new LectureServices();

        [BindProperty]
        public List<Lecture> Lectures { get; set; }

        public void OnGet()
        {
            Lectures = _lectureServices.GetAllLectures();
        }

    }
}
