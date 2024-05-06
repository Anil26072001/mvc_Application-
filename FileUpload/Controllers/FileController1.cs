using FileUploadOperation.Models;
using FileUploadOperation.Repositary;
using Microsoft.AspNetCore.Mvc;

namespace sampleproject.Controllers
{
    public class FileController1 : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IfileUpload _repo;


        public FileController1(IWebHostEnvironment webHostEnvironment, IfileUpload repo)
        {
            _webHostEnvironment = webHostEnvironment;
            _repo = repo;

        }


        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        //public async Task<IActionResult> FileUpload(IFormFile file)
        //{
        //   await _repo.fileupload(file);                              // single file
        //   ViewBag.msg = file.Name + "upload successfully";
        //    return View();
        //}

        [HttpPost]
        //[Route("/File/Upload")]
        public async Task<IActionResult> FileUpload(List<IFormFile> file)
        {
            try
            {
                if (file == null || file.Count == 0)
                {
                    ViewBag.msg = "No file selected for upload.";
                    return View();
                }

                foreach (var files in file)
                {
                    if (files.Length > 0)
                    {

                        await _repo.fileupload(files);
                    }
                }

                ViewBag.msg = $"{file.Count} file uploaded successfully.";
                return RedirectToAction("Listpage");

            }
            catch (Exception ex)
            {

                throw;
            }
        } 
           

        public IActionResult Listpage()
        {
            try
            {
                List<Fileimplementation> list = _repo.Getfiles();

                if (list != null)
                {
                    return View(list);
                }
                return View();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IActionResult Downloadfile(string filename, string filetype)
        {
            try
            {
                var FullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploadfiles", filename);
                var memory = _repo.DownloadFile(FullFilePath);
                return File(memory.ToArray(), filetype, filename);

            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public IActionResult FileChecking(string fileName)
        {
            try
            {
                bool check = _repo.FileCheck(fileName);
                return Ok(new { fileExists = check });


            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

