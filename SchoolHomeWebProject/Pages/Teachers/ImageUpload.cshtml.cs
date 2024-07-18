using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolHomeWebProject.Pages.Teachers
{
    public class ImageUploadModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageUploadModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public IFormFile ImageFile { get; set; }
        string targetPath = "../wwwroot/Images/";
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Please select an image file.");
                return Page();
            }
            try
            {
                object fileObj = Request.Form.Files[0];
                string fileName = ((FormFile)fileObj).FileName;
                string fileExtention = Path.GetExtension(fileName);
                string newFileName = Guid.NewGuid().ToString() + fileExtention;
                string fileDestination = Path.Combine(_webHostEnvironment.ContentRootPath + "/wwwroot/Images", newFileName);

                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (Stream stream = new FileStream(fileDestination, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream); // Save file in folders
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ImageFile", "An error occurred while uploading the image.");
            }

            return new RedirectToPageResult("ImageUpload");
        }


    }
}
