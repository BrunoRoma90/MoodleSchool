using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace SchoolHomeWebProject.Pages.Shared
{
    public class LogoutModel : PageModel
    {

        private readonly IMemoryCache _memoryCache;

        public LogoutModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        public void OnGet()
        {
        }

      
        public IActionResult OnPostLogout()
        {
            _memoryCache.Remove("StudentId");
            _memoryCache.Remove("TeacherId");
            _memoryCache.Remove("UserName");

            return RedirectToPage("/Index");
        }
    }
}
