using Azure;
using FileUpload.Data;
using FileUpload.Models;
using FileUploadOperation.Interfaces;
using FileUploadOperation.Models;
using FileUploadOperation.Repositary;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FileUploadOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly Idetails _details;
        private readonly Authentication1 _repository;
        private readonly ApplicationDBContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public HomeController(Idetails details, Authentication1 _respository, ApplicationDBContext db)
        {
            _details = details;
            _repository = _respository;
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var getid = _db.Registers.Find(id);
            return View(id);
        }



        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var getid = _db.Registers.Find(id);
            if (getid != null)
            {
                _db.Registers.Remove(getid);
                ViewBag.Message = id + " Deleted successfully";
                return RedirectToAction("ListPage");
            }
            else
            {
                return View();
            }




            //        if (getid != null)
            //            try
            //            {
            //                _details.DeleteUser(id)
            //;
            //                ViewBag.Message = id + " Deleted successfully";
            //                return RedirectToAction("ListPage");
            //            }
            //            catch (Exception)
            //            {
            //                return View();
            //            }

        }
            public IActionResult Edit(int id)
            {
                try
                {
                    Register user = _db.Registers.Find(id);
                    user.Name = user.Name;
                    user.Email = user.Email;
                    user.Password = user.Password;
                    user.ConfirmPassword = user.ConfirmPassword;
                    return RedirectToAction("Registrationpage", user);
                }
                catch (Exception)
                {

                    return NotFound();
            }


        }
    }
}




